using AutoMapper;
using MeetupsServerApp.Data;
using MeetupsServerApp.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeetupsServerApp.Features.DeleteEvent
{
    public class DeleteEventService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;

        public DeleteEventService(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsEventDeletableAsync(int? eventId)
        {
            await using var context = await _dbContext.CreateDbContextAsync();

            if (eventId is null)
            {
                return false;
            }

            var eventEntity = await context.Events?.FirstOrDefaultAsync(e => e.EventId == eventId);

            if (eventEntity is null)
            {
                return false;
            }

            var beginDateTime = eventEntity.BeginDate.Value.Date + eventEntity.BeginTime.Value;

            if (beginDateTime < DateTime.Now)
            {
                return false;
            }


            return true;
        }

        public async Task<bool> DeleteEventAsync(int? eventId)
        {
            await using var context = await _dbContext.CreateDbContextAsync();

            if (eventId is null)
            {
                return false;
            }

            var eventEntity = await context.Events.FindAsync(eventId);

            if (eventEntity is null)
            {
                return false;
            }

            context.Events.Remove(eventEntity);

            //From EF Core 7 
            //await context.Events
            //    .Where(x => x.EventId == eventId)
            //    .ExecuteDeleteAsync();


            await context.SaveChangesAsync();

            return true;
        }
    }
}
