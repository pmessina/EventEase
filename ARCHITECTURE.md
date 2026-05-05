# EventEase Application Architecture

## Component Hierarchy

```
App.razor
└── MainLayout.razor
    ├── NavMenu.razor (Navigation)
    │   ├── Home (/)
    │   ├── Browse Events (/events)
    │   ├── Counter (/counter)
    │   └── Weather (/weather)
    │
    └── @Body (Page Content)
        ├── Home.razor (/)
        │   └── Links to /events
        │
        ├── Events.razor (/events)
        │   ├── Search Input (two-way binding)
        │   └── EventCard.razor (×6) [Reusable Component]
        │       ├── Event Data (one-way binding)
        │       ├── → /events/{id} (View Details)
        │       └── → /events/{id}/register (Register)
        │
        ├── EventDetails.razor (/events/{id})
        │   ├── Route Parameter: [Parameter] int Id
        │   ├── ← Back to /events
        │   ├── → /events/{id}/register (Register Now)
        │   └── Share Event (placeholder)
        │
        └── EventRegistration.razor (/events/{id}/register)
            ├── Route Parameter: [Parameter] int Id
            ├── EditForm (two-way binding)
            │   ├── FirstName
            │   ├── LastName
            │   ├── Email (validated)
            │   ├── PhoneNumber (validated)
            │   ├── Company (optional)
            │   └── SpecialRequirements (optional)
            ├── Validation (DataAnnotations)
            ├── ← Back to /events/{id}
            └── Success Confirmation
                ├── → /events (Browse More)
                └── → /events/{id} (View Details)
```

---

## Navigation Flow Diagram

```
┌─────────────────────────────────────────────────────────────────┐
│                        Home Page (/)                             │
│  • Hero section with CTA                                         │
│  • Features showcase                                             │
│  • "Browse Events" → /events                                     │
└─────────────┬───────────────────────────────────────────────────┘
              │
              ▼
┌─────────────────────────────────────────────────────────────────┐
│                    Events List (/events)                         │
│  • Search box (real-time filtering)                              │
│  • EventCard × 6 components                                      │
│  • "View Details" → /events/{id}                                 │
│  • "Register" → /events/{id}/register                            │
└─────┬───────────────────────────┬─────────────────────────────┬─┘
      │                           │                             │
      │ View Details              │ Direct Register             │
      ▼                           │                             │
┌─────────────────────────────────▼───────────────────────────  │
│           Event Details (/events/{id})                │        │
│  • Full event information                             │        │
│  • "Register Now" → /events/{id}/register             │        │
│  • "Back to Events" ← /events                         │        │
└────────────────────────┬──────────────────────────────┘        │
                         │                                       │
                         ▼                                       │
┌─────────────────────────────────────────────────────────────┐◄┘
│         Event Registration (/events/{id}/register)           │
│  • Event summary header                                      │
│  • Registration form with validation                         │
│  • "Complete Registration" → Success screen                  │
│  • "Back to Event Details" ← /events/{id}                    │
│                                                               │
│  Success Screen:                                             │
│  • "Browse More Events" → /events                            │
│  • "View Event Details" → /events/{id}                       │
└───────────────────────────────────────────────────────────────┘
```

---

## Data Flow Diagram

```
┌──────────────────────────────────────────────────────────────────┐
│                         EventService                              │
│  • GetAllEventsAsync()                                            │
│  • GetEventByIdAsync(int id)                                      │
│  • SearchEventsAsync(string term)                                 │
│  • Mock Data: 6 Events                                            │
└────────────┬─────────────────────────────────────────────────────┘
             │ Injected via DI
             │
     ┌───────┴────────┬─────────────┬────────────────┐
     │                │             │                │
     ▼                ▼             ▼                ▼
┌─────────┐    ┌──────────┐   ┌──────────┐   ┌──────────────┐
│ Events  │    │  Event   │   │  Event   │   │  EventCard   │
│ .razor  │    │ Details  │   │  Regis-  │   │  Component   │
│         │    │ .razor   │   │  tration │   │              │
│ List[6] │    │ Event?   │   │ .razor   │   │ [Parameter]  │
│ Events  │    │ eventItem│   │ Event?   │   │ EventData    │
└─────────┘    └──────────┘   └──────────┘   └──────────────┘
     │              │               │                │
     │              │               │                │
     └──────────────┴───────────────┴────────────────┘
                    │
                    ▼
            ┌────────────────┐
            │  Event Model   │
            │  • Id          │
            │  • Name        │
            │  • Date        │
            │  • Location    │
            │  • Description │
            │  • Category    │
            │  • Capacity    │
            │  • Price       │
            └────────────────┘
```

---

## Data Binding Patterns

### 1. One-Way Binding (Display)
```
EventService → Event Model → Component Display
   (data)    ↓   (object)   ↓   (rendered HTML)
```

**Example:**
```razor
@eventItem.Name
@EventData.Date.ToString("MMM dd, yyyy")
```

---

### 2. Two-Way Binding (Forms)
```
User Input ↔ Component Property ↔ Form Field
          (synchronization)
```

**Example:**
```razor
<InputText @bind-Value="registration.Email" />
```

---

### 3. Parameter Binding (Parent → Child)
```
Parent Component → [Parameter] → Child Component
   (EventData)        (prop)      (displays data)
```

**Example:**
```razor
<!-- Parent -->
<EventCard EventData="@eventItem" ShowActions="true" />

<!-- Child -->
@code {
    [Parameter]
    public Event EventData { get; set; }
}
```

---

### 4. Event Binding (User Interaction)
```
User Action → Event Handler → State Change → Re-render
  (@onclick)    (method)      (variable)    (UI update)
```

**Example:**
```razor
<input @bind="searchTerm" @onkeyup="HandleSearch" />

@code {
    private string searchTerm = "";

    private async Task HandleSearch() {
        // Filter logic
    }
}
```

---

## Route Configuration

### Static Routes
```
/           → Home.razor
/events     → Events.razor
/counter    → Counter.razor
/weather    → Weather.razor
```

### Dynamic Routes (with parameters)
```
/events/{id:int}                → EventDetails.razor
/events/{id:int}/register       → EventRegistration.razor
```

**Route Parameter Binding:**
```csharp
[Parameter]
public int Id { get; set; }  // Automatically populated from URL
```

---

## Component Lifecycle Flow

```
┌────────────────────────────────────────────────────────────┐
│                  Component Instantiation                    │
└─────────────────────┬──────────────────────────────────────┘
                      │
                      ▼
┌────────────────────────────────────────────────────────────┐
│  SetParametersAsync (Parameters received from parent/route)│
└─────────────────────┬──────────────────────────────────────┘
                      │
                      ▼
┌────────────────────────────────────────────────────────────┐
│  OnInitializedAsync() - Load data, initialize state        │
│  • EventService.GetAllEventsAsync()                         │
│  • EventService.GetEventByIdAsync(Id)                       │
└─────────────────────┬──────────────────────────────────────┘
                      │
                      ▼
┌────────────────────────────────────────────────────────────┐
│  OnParametersSetAsync() - React to parameter changes        │
└─────────────────────┬──────────────────────────────────────┘
                      │
                      ▼
┌────────────────────────────────────────────────────────────┐
│  Render (HTML is generated and displayed)                  │
└─────────────────────┬──────────────────────────────────────┘
                      │
                      ▼
┌────────────────────────────────────────────────────────────┐
│  OnAfterRenderAsync() - DOM is ready                        │
└─────────────────────┬──────────────────────────────────────┘
                      │
                      │  User Interaction
                      ▼
┌────────────────────────────────────────────────────────────┐
│  Event Handlers (@onclick, @onkeyup, etc.)                 │
│  • StateHasChanged() - Trigger re-render                    │
└────────────────────────────────────────────────────────────┘
```

---

## Dependency Injection Flow

```
Program.cs
   │
   │ builder.Services.AddSingleton<EventService>();
   │
   └─────────────────────────────────────────────────┐
                                                      │
                                                      ▼
                                           ┌──────────────────┐
                                           │  DI Container    │
                                           │  (EventService)  │
                                           └────────┬─────────┘
                                                    │
                                   ┌────────────────┼────────────────┐
                                   │                │                │
                                   ▼                ▼                ▼
                            ┌────────────┐  ┌────────────┐  ┌────────────┐
                            │  Events    │  │   Event    │  │   Event    │
                            │  .razor    │  │  Details   │  │ Registration│
                            └────────────┘  └────────────┘  └────────────┘
                            @inject         @inject         @inject
                            EventService    EventService    EventService
```

---

## Form Validation Flow

```
User Input
   │
   ▼
┌──────────────────────────────────────┐
│  <InputText @bind-Value="..." />     │
└───────────────┬──────────────────────┘
                │
                ▼
┌──────────────────────────────────────┐
│  Property with [Required], etc.      │
└───────────────┬──────────────────────┘
                │
                ▼
┌──────────────────────────────────────┐
│  DataAnnotationsValidator            │
│  • Validates on submit                │
│  • Validates on field blur            │
└───────────────┬──────────────────────┘
                │
        ┌───────┴────────┐
        │                │
    Valid?           Invalid?
        │                │
        ▼                ▼
┌────────────┐    ┌────────────────────┐
│  OnValid   │    │  ValidationMessage │
│  Submit    │    │  Display errors    │
└────────────┘    └────────────────────┘
```

---

## Key Design Patterns Used

### 1. Component Pattern
- **EventCard.razor** - Reusable, self-contained component
- Receives data via `[Parameter]`
- Emits navigation via anchor tags

### 2. Service Pattern
- **EventService** - Centralized data access
- Registered with DI container
- Injected into components

### 3. Repository Pattern (simplified)
- EventService acts as a data repository
- Abstracts data source (currently mock data)
- Could be swapped for API calls later

### 4. Form Pattern
- **EditForm** with validation
- Model binding with DataAnnotations
- Submit handling with validation

### 5. Navigation Pattern
- Route parameters for dynamic pages
- NavLink for menu navigation
- NavigationManager for programmatic navigation

---

This architecture provides a solid foundation for the EventEase application with:
- ✅ Clear separation of concerns
- ✅ Reusable components
- ✅ Type-safe routing
- ✅ Proper data flow
- ✅ Validation and error handling
- ✅ Dependency injection
