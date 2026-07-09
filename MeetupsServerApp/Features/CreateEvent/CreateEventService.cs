using MeetupsServerApp.Data;
using MeetupsServerApp.Features.ViewCreatedEvents;
using Microsoft.EntityFrameworkCore;

namespace MeetupsServerApp.Features.CreateEvent
{
    public class CreateEventService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;

        public CreateEventService(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateEventAsync(EventViewModel eventViewModel)
        {
            using var context = await _dbContext.CreateDbContextAsync();

            await context.Events.AddAsync(new Data.Entities.Event
            {
                Title = eventViewModel.Title,
                Desription = eventViewModel.Desription,
                BeginDate = eventViewModel.BeginDate,
                BeginTime = eventViewModel.BeginTime,
                EndDate = eventViewModel.EndDate,
                EndTime = eventViewModel.EndTime,
                Location = eventViewModel.Location,
                MeetupLink = eventViewModel.MeetupLink,
                Category= eventViewModel.Category,
                Capacity = eventViewModel.Capacity,
                OrganizerId = eventViewModel.OrganizerId,
            });

            await context.SaveChangesAsync();
        }
    }
}
