using AutoMapper;
using MeetupsServerApp.Data;
using MeetupsServerApp.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeetupsServerApp.Features.CreateEvent
{
    public class CreateEventService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMapper _mapper;

        public CreateEventService(IDbContextFactory<ApplicationDbContext> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateEventAsync(EventViewModel eventViewModel)
        {
            using var context = await _dbContext.CreateDbContextAsync();

            var eventEntity = _mapper.Map<Data.Entities.Event>(eventViewModel);

            await context.Events.AddAsync(eventEntity);

            await context.SaveChangesAsync();
        }
    }
}
