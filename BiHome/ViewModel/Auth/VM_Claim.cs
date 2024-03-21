using System.ComponentModel.DataAnnotations;

namespace BiHome.ViewModel.Auth
{
    public class VM_Claim
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        [MaxLength(48)]
        public string? Firstname { get; set; } = null!;

        [MaxLength(48)]
        public string? Lastname { get; set; } = null!;

        [MaxLength(78)]
        public string? ProfilePicture { get; set; }

        public bool? Gender { get; set; }
    }
}
