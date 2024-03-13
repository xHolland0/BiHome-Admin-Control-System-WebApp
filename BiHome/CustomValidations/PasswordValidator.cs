using BiHome.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace BiHome.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {

            //Şifre içerisinde kullanıcı adı bulunamaz

            var errors = new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new()
                {
                    Code = "PasswordContainUsername",
                    Description = "Şifre alanı kullanıcı adı ile aynı olamaz"
                });
            }


            //Şifre içerisinde 1234 bulunamaz

            //if (password!.ToLower().StartsWith("1234"))
            //{
            //    errors.Add(new()
            //    {
            //        Code = "PasswordContain1234",
            //        Description = "Şifre alanı 1234 içeremez"
            //    });
            //}



            //Hata Yok İse Başarılı Var İse Başarısız
            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
