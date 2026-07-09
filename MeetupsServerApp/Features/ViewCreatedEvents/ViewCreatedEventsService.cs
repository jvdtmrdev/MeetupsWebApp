using MeetupsServerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetupsServerApp.Features.ViewCreatedEvents
{
    public class ViewCreatedEventsService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;

        public ViewCreatedEventsService(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EventViewModel>> GetEventsAsync()
        {
            using var context = await _dbContext.CreateDbContextAsync();

            var events = await context.Events
                .Select(e => new EventViewModel
                {
                    EventId = e.EventId,
                    Title = e.Title,
                    Desription = e.Desription,
                    BeginDate = e.BeginDate,
                    BeginTime = e.BeginTime,
                    EndDate = e.EndDate,
                    EndTime = e.EndTime,
                    Location = e.Location,
                    MeetupLink = e.MeetupLink,
                    Category = e.Category,
                    Capacity = e.Capacity,
                    OrganizerId = e.OrganizerId
                })
                .ToListAsync() ?? new List<EventViewModel>();

            return events;
        }
    }
}
