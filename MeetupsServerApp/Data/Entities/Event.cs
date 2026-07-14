using MeetupsServerApp.Features.ViewCreatedEvents;
using System.ComponentModel.DataAnnotations;

namespace MeetupsServerApp.Data.Entities
{
    public class Event
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string? Title { get; set; }

        [StringLength(maximumLength: 4000)]
        public string? Desription { get; set; }

        [Required]
        public DateTime? BeginDate { get; set; }
        [Required]
        public TimeSpan? BeginTime { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        public TimeSpan? EndTime { get; set; }

        public string? Location { get; set; }
        public string? MeetupLink { get; set; }

        [Required]
        public string? Category { get; set; }

        public string? ImageUrl { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        public int OrganizerId { get; set; }
    }
}
