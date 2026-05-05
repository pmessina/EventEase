# 🎉 EventEase - Event Management Web Application

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?logo=blazor)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

A modern, full-featured event management web application built with **Blazor Server** and **.NET 10**. EventEase allows users to browse, search, and register for corporate and social events through an intuitive and responsive interface.

![EventEase Banner](https://via.placeholder.com/1200x300/512BD4/FFFFFF?text=EventEase+-+Event+Management+Made+Easy)

---

## ✨ Features

### 🎯 Core Functionality
- **📅 Event Browsing** - Browse all available events with detailed information
- **🔍 Real-time Search** - Filter events by name, location, or category as you type
- **📝 Event Details** - View comprehensive event information including date, location, capacity, and pricing
- **✅ Event Registration** - Register for events with form validation and confirmation
- **🎨 Modern UI/UX** - Beautiful, responsive design with smooth animations

### 🛠️ Technical Features
- **Component-Based Architecture** - Reusable EventCard component
- **Data Binding** - One-way, two-way, parameter, and event binding patterns
- **Form Validation** - DataAnnotations with real-time validation feedback
- **Routing** - Static and dynamic routes with parameters
- **Service Layer** - Dependency injection with mock data service
- **Responsive Design** - Mobile-first design that works on all devices
- **CSS Isolation** - Scoped styling for each component

---

## 🚀 Quick Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- [Visual Studio 2026](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- A modern web browser (Edge, Chrome, Firefox, Safari)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/EventEase.git
   cd EventEase
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the project**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   cd EventEase
   dotnet run
   ```

5. **Open your browser**
   - Navigate to `https://localhost:5001` or `http://localhost:5000`
   - Or use the URL displayed in the terminal

### Using Visual Studio

1. Open `EventEase.sln` in Visual Studio 2026
2. Press `F5` to run the application
3. The application will open in your default browser

---

## 📁 Project Structure

```
EventEase/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor          # Main layout wrapper
│   │   ├── NavMenu.razor              # Navigation menu
│   │   └── *.css                      # Layout styles
│   ├── Pages/
│   │   ├── Home.razor                 # Landing page
│   │   ├── Events.razor               # Events list with search
│   │   ├── EventDetails.razor         # Event details page
│   │   ├── EventRegistration.razor    # Registration form
│   │   └── *.css                      # Page-specific styles
│   ├── Shared/
│   │   ├── EventCard.razor            # Reusable event card component
│   │   └── EventCard.razor.css        # Component styles
│   ├── _Imports.razor                 # Global using directives
│   ├── App.razor                      # Root component
│   └── Routes.razor                   # Routing configuration
├── Models/
│   └── Event.cs                       # Event data model
├── Services/
│   └── EventService.cs                # Data service with mock events
├── wwwroot/                           # Static assets
├── Program.cs                         # Application entry point
├── appsettings.json                   # Configuration
└── EventEase.csproj                   # Project file
```

---

## 🎮 Usage Guide

### Browse Events
1. Navigate to the **Browse Events** page from the navigation menu
2. View all available events displayed as cards
3. See event details including name, date, location, price, and description

### Search Events
1. On the Events page, use the search box at the top
2. Type any keyword (event name, location, or category)
3. Results filter in real-time as you type
4. Clear the search to show all events again

### View Event Details
1. Click **View Details** on any event card
2. See comprehensive information about the event
3. Access registration directly from the details page

### Register for an Event
1. Click **Register** or **Register Now**
2. Fill out the registration form:
   - **Required:** First Name, Last Name, Email, Phone Number
   - **Optional:** Company/Organization, Special Requirements
3. Click **Complete Registration**
4. View confirmation screen with your registration details

---

## 🏗️ Architecture

### Component Hierarchy

```
App.razor
└── MainLayout.razor
    ├── NavMenu.razor
    └── @Body (Routed Pages)
        ├── Home.razor (/)
        ├── Events.razor (/events)
        │   └── EventCard.razor (×6)
        ├── EventDetails.razor (/events/{id})
        └── EventRegistration.razor (/events/{id}/register)
```

### Data Flow

```
EventService (DI)
    ↓
Pages (Inject Service)
    ↓
Components (Parameter Binding)
    ↓
UI Rendering
```

### Key Design Patterns

- **Repository Pattern** - EventService abstracts data access
- **Component Pattern** - Reusable, self-contained components
- **Service Pattern** - Dependency injection for services
- **Form Pattern** - EditForm with DataAnnotations validation
- **Navigation Pattern** - Multiple navigation strategies

---

## 🎨 Sample Events

The application includes 6 diverse sample events:

1. **Tech Innovation Summit 2025** - Technology conference in San Francisco ($299.99)
2. **Annual Corporate Gala** - Corporate event in New York ($150.00)
3. **Summer Music Festival** - Entertainment in Austin ($75.00)
4. **Business Leadership Workshop** - Business training in Chicago ($499.99)
5. **Charity Fundraising Dinner** - Charity event in Seattle ($125.00)
6. **Product Launch Event** - Free corporate event in Boston (FREE)

---

## 🧪 Testing

### Manual Testing
See [TESTING_GUIDE.md](TESTING_GUIDE.md) for comprehensive test scenarios including:
- Home page navigation
- Event list and search functionality
- Event card display
- Event details page
- Registration form validation
- Form submission flow

### Running Tests
```bash
dotnet test
```

---

## 🔧 Technologies Used

| Technology | Purpose |
|------------|---------|
| **.NET 10** | Framework |
| **Blazor Server** | Interactive web UI |
| **C# 13** | Programming language |
| **Razor** | Component syntax |
| **CSS3** | Styling with isolation |
| **Bootstrap Icons** | Icon library |
| **SignalR** | Real-time communication |

---

## 📚 Documentation

- **[README.md](README.md)** - This file (overview and quick start)
- **[IMPLEMENTATION_SUMMARY.md](IMPLEMENTATION_SUMMARY.md)** - Detailed implementation guide
- **[TESTING_GUIDE.md](TESTING_GUIDE.md)** - Comprehensive testing scenarios
- **[ARCHITECTURE.md](ARCHITECTURE.md)** - Visual diagrams and architecture
- **[BLAZOR_QUICK_REFERENCE.md](BLAZOR_QUICK_REFERENCE.md)** - Blazor syntax cheat sheet
- **[INTERACTIVITY_FIX.md](INTERACTIVITY_FIX.md)** - Render mode explanation

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Development Guidelines

- Follow C# coding conventions
- Use meaningful commit messages
- Add tests for new features
- Update documentation as needed
- Ensure the build passes before submitting PR

---

## 🐛 Known Issues

- Form submission currently simulates API calls (no backend)
- Event data is mock data (not persisted)
- No authentication/authorization implemented yet

---

## 🚧 Future Enhancements

- [ ] Backend API integration
- [ ] User authentication and authorization
- [ ] Event CRUD operations for admins
- [ ] Payment processing integration
- [ ] Email notifications
- [ ] Event calendar view
- [ ] Category filtering
- [ ] User profile and registration history
- [ ] Event capacity tracking
- [ ] Photo uploads for events
- [ ] Social sharing features

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Author

**Your Name**
- GitHub: [@yourusername](https://github.com/yourusername)
- LinkedIn: [Your LinkedIn](https://linkedin.com/in/yourprofile)

---

## 🙏 Acknowledgments

- Built with [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- Icons from [Bootstrap Icons](https://icons.getbootstrap.com/)
- Developed with assistance from [Microsoft Copilot](https://copilot.microsoft.com/)

---

## 📞 Support

If you encounter any issues or have questions:

1. Check the [documentation](IMPLEMENTATION_SUMMARY.md)
2. Search [existing issues](https://github.com/yourusername/EventEase/issues)
3. Create a [new issue](https://github.com/yourusername/EventEase/issues/new)

---

## ⭐ Show Your Support

Give a ⭐️ if this project helped you learn Blazor or build something awesome!

---

<p align="center">
  Made with ❤️ using Blazor and .NET 10
</p>

<p align="center">
  <a href="#-eventease---event-management-web-application">Back to Top</a>
</p>

