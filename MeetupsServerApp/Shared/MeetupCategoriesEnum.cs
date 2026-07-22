using System.ComponentModel.DataAnnotations;

namespace MeetupsServerApp.Shared
{
    public enum MeetupCategoriesEnum
    {
        [Display(Name = "حضوری")]
        InPerson,

        [Display(Name = "آنلاین")]
        Online
    }
}
