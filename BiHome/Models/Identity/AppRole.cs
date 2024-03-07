using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace BiHome.Models.Identity
{
    public class AppRole:IdentityRole
    {
        // AUDIT COLUMNS

        [DefaultValue(true)]
        public bool? IS_ACTIVE { get; set; }

        [DefaultValue(false)]
        public bool? IS_DELETED { get; set; }

        public DateTimeOffset? CREATED_DATE { get; set; } = DateTimeOffset.UtcNow;

        public int? CREATED_USER_ID { get; set; }

        public DateTimeOffset? MODIFIED_DATE { get; set; }

        public int? MODIFIED_USER_ID { get; set; }
    }
}
