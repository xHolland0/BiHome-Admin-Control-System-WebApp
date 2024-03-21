using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiHome.ViewModel.Auth
{
    public class VM_ChangePassword
    {
        [DisplayName("Eski Şifre")]
        [Required(ErrorMessage ="'Eski Şifre' alanı boş bırakılamaz.")]
        [MinLength(10, ErrorMessage ="Şifre uzunluğu en az 10 karakter olması gereklidir.")]
        [DataType(DataType.Password)]
        public string PasswordOld { get; set; }

        [DisplayName("Yeni Şifre")]
        [Required(ErrorMessage = "'Yeni Şifre' alanı boş bırakılamaz\"")]
        [MinLength(10,ErrorMessage ="Şifre uzunluğu en az 10 karakter olması gereklidir.")]
        [DataType(DataType.Password)]
        public string PasswordNew { get; set; }

        [DisplayName("Yeni Şifre Tekrar")]
        [Required(ErrorMessage ="'Şifre Tekrar' alanı boş bırakılamaz\"")]
        [Compare(nameof(PasswordNew), ErrorMessage ="Şifreler uyuşmuyor")]
        [MinLength(10,ErrorMessage ="Şifre uzunluğu en az 10 karakter olması gereklidir.")]
        [DataType(DataType.Password)]
        public string PasswordNewConfirm { get; set; }
    }
}
