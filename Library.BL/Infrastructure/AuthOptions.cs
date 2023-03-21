using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Library.BLL.Infrastructure
{
    public static class AuthOptions
    {
        public const string ISSUER = "LibraryAPI";
        public const string AUDIENCE = "AuthClient";
        const string KEY = "secret_LIBRARY_API!2023";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}