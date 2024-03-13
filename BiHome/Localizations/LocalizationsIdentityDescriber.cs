using Microsoft.AspNetCore.Identity;

namespace BiHome.Localizations
{
    public class LocalizationsIdentityDescriber :IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new()
            {
                Code = "DuplicateUserName",
                Description = $"Kullanıcı Adı '{userName}' başka birisi tarafından kullanımda"
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new()
            {
                Code = "DuplicateEmail",
                Description = $"Email '{email}' başka birisi tarafından kullanımda"
            };
        }


        public override IdentityError PasswordTooShort(int length)
        {
            return new()
            {
                Code = "PasswordTooShort",
                Description = $"Şifre en az 6 karakter olmalıdır."
            };
        }
    }
}
