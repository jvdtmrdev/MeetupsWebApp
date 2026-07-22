using System.ComponentModel.DataAnnotations;

namespace MeetupsServerApp.Shared.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            BeginDate = DateTime.Now.Date;
            BeginTime = DateTime.Now.TimeOfDay;
            EndDate = DateTime.Now.Date;
            EndTime = DateTime.Now.TimeOfDay;

            ImageUrl = "/images/image-placeholder.png";
        }

        [Required]
        public int EventId { get; set; }

        [Required(ErrorMessage = "واردنمودن عنوان رویداد الزامی است.")]
        [StringLength(maximumLength: 100, ErrorMessage = "عنوان رویداد حداکثر ۱۰۰ کارکتر میتواند باشد.")]
        public string? Title { get; set; }

        [StringLength(maximumLength: 4000)]
        public string? Desription { get; set; }

        [Required]
        public DateTime? BeginDate { get; set; }
        [Required]
        public TimeSpan? BeginTime { get; set; }

        public string BeginDateTime
        {
            get
            {
                if (!BeginDate.HasValue || !BeginTime.HasValue)
                {
                    return "";
                }

                return (BeginDate.Value.Date + BeginTime.Value).ToString("yyyy/MM/dd HH:mm");
            }
        }

        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        public TimeSpan? EndTime { get; set; }

        public string EndDateTime
        {
            get
            {
                if (!EndDate.HasValue || !EndTime.HasValue)
                {
                    return "";
                }

                return (EndDate.Value.Date + EndTime.Value).ToString("yyyy/MM/dd HH:mm");
            }
        }


        public string? Location { get; set; }
        public string? MeetupLink { get; set; }

        [Required(ErrorMessage = "دسته‌بندی رویداد الزامی است.")]
        public string? Category { get; set; }

        public string CategoryDisplayName => Category?.ToLowerInvariant() switch
        {
            "inperson" => "حضوری",
            "online" => "آنلاین",
            _ => string.Empty
        };


        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        public string CapacityDisplay
        {
            get
            {
                if (Capacity == 0)
                    return "نامحدود";

                var formattedNumber = PersianFormat.NumberGroupping(Capacity.ToString());

                return PersianFormat.En2Fa(formattedNumber);
            }
        }

        public int OrganizerId { get; set; }

        public string? ImageUrl { get; set; }

        public string? Validate()
        {
            string? errorMesagge = string.Empty;

            errorMesagge = ValidateDates();
            if (!string.IsNullOrEmpty(errorMesagge))
            {
                return errorMesagge;
            }

            errorMesagge = ValidateLocation();
            if (!string.IsNullOrEmpty(errorMesagge))
            {
                return errorMesagge;
            }

            errorMesagge = ValidateMeetupLink();
            if (!string.IsNullOrEmpty(errorMesagge))
            {
                return errorMesagge;
            }

            return string.Empty;
        }

        public string? ValidateDates()
        {
            if (!BeginDate.HasValue || !EndDate.HasValue || !BeginTime.HasValue || !EndTime.HasValue)
            {
                return null;
            }

            var beginDateTime = BeginDate.Value.Date + BeginTime.Value;
            var endDateTime = EndDate.Value.Date + EndTime.Value;

            if (beginDateTime >= endDateTime)
            {
                return "زمان شروع باید قبل از زمان پایان باشد.";
            }

            if (beginDateTime < DateTime.Now)
            {
                return "زمان شروع نمی‌تواند در گذشته باشد.";
            }

            if (endDateTime - beginDateTime > TimeSpan.FromDays(1))
            {
                return "مدت زمان رویداد نباید بیش از ۲۴ ساعت باشد.";
            }

            return null;
        }

        public string? ValidateLocation()
        {
            if (Category == MeetupCategoriesEnum.InPerson.ToString() && string.IsNullOrEmpty(Location))
            {
                return "وارد نمودن مکان برگزاری رویداد حضوری الزامی است.";
            }

            return string.Empty;
        }

        public string? ValidateMeetupLink()
        {
            if (Category == MeetupCategoriesEnum.Online.ToString() && string.IsNullOrEmpty(MeetupLink))
            {
                return "وارد نمودن لینک برگزاری رویداد آنلاین الزامی است.";
            }

            return string.Empty;
        }
    }
}
