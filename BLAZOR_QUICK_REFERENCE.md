# Blazor Quick Reference - EventEase

## 🔥 Data Binding Syntax

### One-Way Binding (Display Only)
```razor
@EventData.Name
@EventData.Date.ToString("MMM dd, yyyy")
@registration.Email
```
**Use when:** Displaying data that doesn't change from UI

---

### Two-Way Binding (Forms)
```razor
<InputText @bind-Value="registration.FirstName" />
<InputText @bind-Value="registration.Email" />
```
**Use when:** User input needs to update a variable automatically

---

### Event Binding (Custom Timing)
```razor
<input @bind="searchTerm" 
       @bind:event="oninput" 
       @onkeyup="HandleSearch" />
```
**Use when:** Need to trigger logic on specific events (keyup, blur, etc.)

---

### Parameter Binding (Component to Component)
```razor
<!-- Parent Component -->
<EventCard EventData="@eventItem" ShowActions="true" />

<!-- Child Component -->
@code {
    [Parameter]
    public Event EventData { get; set; }

    [Parameter]
    public bool ShowActions { get; set; }
}
```
**Use when:** Passing data from parent to child component

---

## 🔀 Routing Patterns

### Static Route
```razor
@page "/events"
```
**URL:** `http://localhost:5264/events`

---

### Dynamic Route with Parameter
```razor
@page "/events/{id:int}"

@code {
    [Parameter]
    public int Id { get; set; }
}
```
**URL:** `http://localhost:5264/events/3`
**Parameter:** `Id = 3`

---

### Multiple Parameters
```razor
@page "/events/{id:int}/sessions/{sessionId:int}"

@code {
    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public int SessionId { get; set; }
}
```

---

## 🧭 Navigation Methods

### 1. Anchor Tag
```razor
<a href="/events">Browse Events</a>
<a href="/events/@eventItem.Id">View Details</a>
```

### 2. NavLink Component (with active state)
```razor
<NavLink class="nav-link" href="events">
    Browse Events
</NavLink>
```

### 3. Programmatic Navigation
```razor
@inject NavigationManager Navigation

@code {
    private void NavigateToDetails()
    {
        Navigation.NavigateTo($"/events/{eventId}");
    }
}
```

---

## 📝 Form Patterns

### EditForm with Validation
```razor
<EditForm Model="@registration" OnValidSubmit="@HandleSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <InputText @bind-Value="registration.Email" />
    <ValidationMessage For="@(() => registration.Email)" />

    <button type="submit">Submit</button>
</EditForm>

@code {
    private Registration registration = new();

    private async Task HandleSubmit()
    {
        // Form is valid here
    }

    public class Registration
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
```

---

## 💉 Dependency Injection

### Register Service (Program.cs)
```csharp
builder.Services.AddSingleton<EventService>();
```

### Inject into Component
```razor
@inject EventService EventService

@code {
    protected override async Task OnInitializedAsync()
    {
        var events = await EventService.GetAllEventsAsync();
    }
}
```

---

## 🔄 Component Lifecycle

### Common Lifecycle Methods
```csharp
@code {
    // 1. Runs once when component first loads
    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    // 2. Runs every time parameters change
    protected override async Task OnParametersSetAsync()
    {
        await ReloadData();
    }

    // 3. Runs after component renders
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // JavaScript interop here
        }
    }
}
```

---

## 🎨 Conditional Rendering

### If/Else
```razor
@if (isLoading)
{
    <p>Loading...</p>
}
else if (events.Count == 0)
{
    <p>No events found</p>
}
else
{
    @foreach (var evt in events)
    {
        <EventCard EventData="@evt" />
    }
}
```

### Ternary Operator
```razor
<span class="@(IsActive ? "active" : "inactive")">Status</span>
```

---

## 🔁 Loops

### Foreach Loop
```razor
@foreach (var eventItem in events)
{
    <div>@eventItem.Name</div>
}
```

### For Loop
```razor
@for (int i = 0; i < 10; i++)
{
    <div>Item @i</div>
}
```

---

## ⚡ Event Handlers

### Click Events
```razor
<button @onclick="HandleClick">Click Me</button>
<button @onclick="() => Delete(id)">Delete</button>

@code {
    private void HandleClick()
    {
        // Handle click
    }

    private void Delete(int id)
    {
        // Delete item
    }
}
```

### Input Events
```razor
<input @onkeyup="HandleKeyUp" 
       @onblur="HandleBlur"
       @onfocus="HandleFocus" />
```

---

## 🔧 State Management

### Component State
```razor
@code {
    private bool isLoading = false;
    private List<Event> events = new();

    private async Task LoadData()
    {
        isLoading = true;
        events = await EventService.GetAllEventsAsync();
        isLoading = false;
        StateHasChanged(); // Force re-render (usually automatic)
    }
}
```

---

## ✅ Validation Attributes

```csharp
public class Registration
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email")]
    public string Email { get; set; }

    [Phone]
    public string Phone { get; set; }

    [Range(1, 100)]
    public int Age { get; set; }

    [StringLength(50, MinimumLength = 3)]
    public string Title { get; set; }

    [Url]
    public string Website { get; set; }

    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
```

---

## 📦 Component Communication

### Parent to Child (Parameter)
```razor
<!-- Parent -->
<ChildComponent Title="@myTitle" />

<!-- Child -->
@code {
    [Parameter]
    public string Title { get; set; }
}
```

### Child to Parent (EventCallback)
```razor
<!-- Child -->
<button @onclick="NotifyParent">Click</button>

@code {
    [Parameter]
    public EventCallback OnClick { get; set; }

    private async Task NotifyParent()
    {
        await OnClick.InvokeAsync();
    }
}

<!-- Parent -->
<ChildComponent OnClick="@HandleChildClick" />

@code {
    private void HandleChildClick()
    {
        // Handle event from child
    }
}
```

---

## 🎯 Common Patterns in EventEase

### Loading Pattern
```razor
@if (isLoading)
{
    <div class="spinner"></div>
}
else
{
    <!-- Content -->
}

@code {
    private bool isLoading = true;

    protected override async Task OnInitializedAsync()
    {
        isLoading = true;
        await LoadData();
        isLoading = false;
    }
}
```

---

### Search/Filter Pattern
```razor
<input @bind="searchTerm" @bind:event="oninput" @onkeyup="FilterItems" />

@code {
    private string searchTerm = "";
    private List<Event> allEvents = new();
    private List<Event> filteredEvents = new();

    private void FilterItems()
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            filteredEvents = allEvents;
        }
        else
        {
            filteredEvents = allEvents
                .Where(e => e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
```

---

### Form Submission Pattern
```razor
<EditForm Model="@model" OnValidSubmit="@HandleSubmit">
    <DataAnnotationsValidator />
    <!-- Form fields -->
    <button type="submit" disabled="@isSubmitting">
        @if (isSubmitting)
        {
            <span>Processing...</span>
        }
        else
        {
            <span>Submit</span>
        }
    </button>
</EditForm>

@code {
    private Model model = new();
    private bool isSubmitting = false;

    private async Task HandleSubmit()
    {
        isSubmitting = true;
        await SaveData();
        isSubmitting = false;
    }
}
```

---

## 🔐 Code Block Types

### Single Line
```razor
@code { private int count = 0; }
```

### Multi-Line
```razor
@code {
    private int count = 0;

    private void IncrementCount()
    {
        count++;
    }
}
```

### Inline Expression
```razor
<div>@(count * 2)</div>
<div>@DateTime.Now.ToString("yyyy-MM-dd")</div>
```

---

## 📱 CSS Isolation

### Component.razor
```razor
<div class="card">Content</div>
```

### Component.razor.css
```css
.card {
    /* Scoped to this component only */
    background: white;
}
```

**Output:** Class becomes `.card[b-abc123]` automatically

---

## 🛠️ Debugging Tips

### Set Breakpoints
```csharp
protected override async Task OnInitializedAsync()
{
    var events = await EventService.GetAllEventsAsync(); // ← Set breakpoint here
    filteredEvents = events;
}
```

### Watch Variables
- Watch: `eventItem`
- Watch: `registration.Email`
- Watch: `isLoading`

### Inspect State
```razor
<p>Debug: searchTerm = @searchTerm</p>
<p>Debug: count = @filteredEvents.Count</p>
```

---

## 📚 EventEase Examples

### EventCard Component Usage
```razor
<!-- In Events.razor -->
@foreach (var eventItem in filteredEvents)
{
    <EventCard EventData="@eventItem" ShowActions="true" />
}
```

### Service Injection Pattern
```razor
@page "/events"
@inject EventService EventService

@code {
    private List<Event> events = new();

    protected override async Task OnInitializedAsync()
    {
        events = await EventService.GetAllEventsAsync();
    }
}
```

### Route Parameter Pattern
```razor
@page "/events/{id:int}"
@inject EventService EventService

@code {
    [Parameter]
    public int Id { get; set; }

    private Event? eventItem;

    protected override async Task OnInitializedAsync()
    {
        eventItem = await EventService.GetEventByIdAsync(Id);
    }
}
```

---

## 🎓 Key Concepts Summary

| Concept | Syntax | Example |
|---------|--------|---------|
| Display Data | `@variable` | `@eventItem.Name` |
| Two-Way Bind | `@bind-Value` | `<InputText @bind-Value="email" />` |
| Event Handler | `@onclick` | `<button @onclick="Save">` |
| Route | `@page "/path"` | `@page "/events"` |
| Parameter | `[Parameter]` | `[Parameter] public int Id { get; set; }` |
| Inject | `@inject` | `@inject EventService Service` |
| Condition | `@if (condition)` | `@if (isLoading) { }` |
| Loop | `@foreach (var item in list)` | `@foreach (var evt in events)` |

---

**Print this page and keep it handy while working with Blazor!** 📄✨
