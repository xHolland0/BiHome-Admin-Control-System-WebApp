using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BiHome.ViewModel.Auth
{
    public class VM_ForgetPassword
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "'Email' boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Girdiğiniz Email Hatalı!")]
        public string Email { get; set; } = null!; 
    }
}
