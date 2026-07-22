using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MeetupsServerApp.Shared
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            if (value is null)
                return string.Empty;

            var field = value.GetType().GetField(value.ToString());
            if (field is null)
                return value.ToString();

            var attribute = field.GetCustomAttribute<DisplayAttribute>();
            return attribute?.GetName() ?? value.ToString();
        }

    }
}
