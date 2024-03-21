using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BiHome.ViewModel.Auth
{
    public class VM_UserEdit
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "'Kullanıcı Adı' boş bırakılamaz.")]
        [MaxLength(100)]
        public string UserName { get; set; }


        [DisplayName("Ad")]
        [Required(ErrorMessage = "'Ad' boş bırakılamaz.")]
        [MaxLength(48)]
        public string FirstName { get; set; }



        [DisplayName("Soyad")]
        [Required(ErrorMessage = "'Soyad' boş bırakılamaz.")]
        [MaxLength(48)]
        public string LastName { get; set; }



        [DisplayName("E-Posta")]
        [Required(ErrorMessage = "'E-Posta' boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış.")]
        public string Email { get; set; }



        [DisplayName("Telefon Numarası")]
        [MaxLength(11)]
        [Required(ErrorMessage = "'Telefon Numarası' boş bırakılamaz.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        [DisplayName("Profil Resmi")]
        public IFormFile? ProfilePicture { get; set; }
    }
}
