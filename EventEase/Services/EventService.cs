using EventEase.Models;

namespace EventEase.Services;

public class EventService
{
    private readonly List<Event> _events;

    public EventService()
    {
        _events = new List<Event>
        {
            new Event
            {
                Id = 1,
                Name = "Tech Innovation Summit 2025",
                Date = new DateTime(2025, 3, 15, 9, 0, 0),
                Location = "Convention Center, San Francisco",
                Description = "Join industry leaders for a day of innovation and networking. Discover the latest trends in technology and digital transformation.",
                Category = "Technology",
                Capacity = 500,
                Price = 299.99m
            },
            new Event
            {
                Id = 2,
                Name = "Annual Corporate Gala",
                Date = new DateTime(2025, 4, 20, 18, 30, 0),
                Location = "Grand Ballroom, New York",
                Description = "An elegant evening celebrating corporate excellence with dinner, entertainment, and awards ceremony.",
                Category = "Corporate",
                Capacity = 300,
                Price = 150.00m
            },
            new Event
            {
                Id = 3,
                Name = "Summer Music Festival",
                Date = new DateTime(2025, 6, 10, 12, 0, 0),
                Location = "Central Park, Austin",
                Description = "Experience live performances from top artists in a vibrant outdoor setting. Food trucks and activities for all ages.",
                Category = "Entertainment",
                Capacity = 2000,
                Price = 75.00m
            },
            new Event
            {
                Id = 4,
                Name = "Business Leadership Workshop",
                Date = new DateTime(2025, 5, 5, 10, 0, 0),
                Location = "Hilton Conference Room, Chicago",
                Description = "Intensive workshop focusing on leadership skills, team management, and strategic planning for business professionals.",
                Category = "Business",
                Capacity = 50,
                Price = 499.99m
            },
            new Event
            {
                Id = 5,
                Name = "Charity Fundraising Dinner",
                Date = new DateTime(2025, 7, 14, 19, 0, 0),
                Location = "Riverside Hotel, Seattle",
                Description = "Support local communities with a sophisticated dinner event featuring guest speakers and live auction.",
                Category = "Charity",
                Capacity = 200,
                Price = 125.00m
            },
            new Event
            {
                Id = 6,
                Name = "Product Launch Event",
                Date = new DateTime(2025, 8, 22, 14, 0, 0),
                Location = "Innovation Hub, Boston",
                Description = "Be the first to experience our revolutionary new product line with live demonstrations and exclusive offers.",
                Category = "Corporate",
                Capacity = 150,
                Price = 0.00m
            }
        };
    }

    public Task<List<Event>> GetAllEventsAsync()
    {
        return Task.FromResult(_events.ToList());
    }

    public Task<Event?> GetEventByIdAsync(int id)
    {
        var eventItem = _events.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(eventItem);
    }

    public Task<List<Event>> SearchEventsAsync(string searchTerm)
    {
        var filteredEvents = _events
            .Where(e => e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                       e.Location.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                       e.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Task.FromResult(filteredEvents);
    }
}
