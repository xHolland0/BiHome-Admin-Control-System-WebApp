using BiHome.CustomValidations;
using BiHome.Localizations;
using BiHome.Models;
using BiHome.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using System;

namespace BiHome.Extensions
{
    public static class StartupExtensions
    {
        public static void AddIdentityWithExtensions(this IServiceCollection services)
        {
			IFileProvider physicalProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
			services.AddSingleton<IFileProvider>(physicalProvider);


			services.AddIdentity<AppUser, AppRole>(options =>
            {
                //Kullanıcı Tarafında Yapılan Ayarlar (options)
                options.User.RequireUniqueEmail = true;

                //Şifre Tarafında Yapılan Ayarlar (options)
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;



                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;




                //AddPasswordValidator'ü Identity'e Tanıtıyoruz
            }).AddPasswordValidator<PasswordValidator>().AddUserValidator<UserValidator>()
            .AddErrorDescriber<LocalizationsIdentityDescriber>().AddEntityFrameworkStores<BiHomeContext>();
        }
    }
}


