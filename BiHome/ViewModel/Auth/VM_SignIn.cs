using System.ComponentModel.DataAnnotations;

namespace BiHome.ViewModel.Auth
{
    public class VM_SignIn
    {

        public VM_SignIn() { }

        public VM_SignIn(string email, string password) {
            Email = email;
            Password = password;
        }

        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        public string Email { get; set; }


        [Display(Name = "Şifre:")]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [MinLength(10, ErrorMessage = "Şifre uzunluğu en az '10' karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla!")]
        public bool RememberMe { get; set; }
    }
}
