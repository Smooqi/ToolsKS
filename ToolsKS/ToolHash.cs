using System.Security.Cryptography;
using System.Text;

namespace ToolsKS
{
    public class ToolHash
    {
        public string? HashedPassword {  get; set; }
        public string? Password { get; set; }
        public string PasswordHash(string password)
        {
            using(var sha256 = SHA256.Create() )
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes); 
                return Convert.ToBase64String(hash);
            }
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            var hash = PasswordHash(password);
            return hash == passwordHash;
        }

        public string Info() 
        {
            return "Dll Version: 1.00\n" +
                "Autor:       Krzysztof Szwajka\n" +
                "Tel.:        +48 785 192 785\n" +
                "e-mail:      k.szwajka@gmail.com";
        }
    }
}
