using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiHome.Models.Identity
{
    public class AppUser:IdentityUser
    {
        [MaxLength(48)]
        public string? Firstname { get; set; } = null!;

        [MaxLength(48)]
        public string? Lastname { get; set; } = null!;

        public bool? Gender { get; set; }

        [MaxLength(78)]
        public string? ProfilePicture { get; set; } = "DefaultUserPicture.jpg";

        public DateTimeOffset? CREATED_DATE { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? MODIFIED_DATE { get; set; }

        [DefaultValue(true)]
        public bool? IS_ACTIVE { get; set; } = true;

        [DefaultValue(false)]
        public bool? IS_DELETED { get; set; } = true;
    }
}
