using System.ComponentModel.DataAnnotations;

namespace BiHome.ViewModel.Auth
{
    public class VM_SignUp
    {
        public VM_SignUp()
        {

        }
        public VM_SignUp(string username, string email, string phone, string password, string passwordConfirm)
        {
            Username = username;
            Email = email;
            Phone = phone;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }


        [Required(ErrorMessage = "Kullanıcı Ad alanı boş bıraklılamaz.")]
        [Display(Name = "Kullanıcı Ad:")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı boş bıraklılamaz.")]
        [Display(Name = "Email:")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Telefon alanı boş bıraklılamaz.")]
        [Display(Name = "Telefon:")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Şifre alanı boş bıraklılamaz.")]
        [Display(Name = "Şifre:")]
        public string Password { get; set; }



        [Compare(nameof(Password), ErrorMessage = "Girmiş olduğunuz şifre aynı değil.")]
        [Required(ErrorMessage = "Şifre Tekrar alanı boş bıraklılamaz.")]
        [Display(Name = "Şifre Tekrar:")]
        public string PasswordConfirm { get; set; }
    }
}
