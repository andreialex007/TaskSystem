using System.Linq;
using System.Security.Claims;

namespace TaskSystem.BL.Utils
{
    public class CommonValues
    {
        public static string SuperSystemKnowleadgeBaseUrl { get; set; }

        public static string SuperSystemPassword
        {
            get
            {
                var identity = (ClaimsIdentity)ServiceProviders.HttpContext.User.Identity;
                var value = identity.Claims.SingleOrDefault(x => x.Type == "SuperSystemPassword");
                if (value == null)
                    return string.Empty;
                return value.Value;
            }
        }
    }
}