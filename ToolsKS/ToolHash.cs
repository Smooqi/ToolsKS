using System.Security.Cryptography;
using System.Text;

namespace ToolsKS
{
    public class ToolHash
    {
        public string? HashedPassword {  get; set; }
        public string? Password { get; set; }
        public string? ErrorMessage {  get; set; }
        public string? StatusMessage {  get; set; }
        public string PasswordToHash(string password)
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
            var hash = PasswordToHash(password);
            return hash == passwordHash;
        }

        public void SavePasswordToFile(string password, string pathFile)
        {
            if (!File.Exists(pathFile))
                File.Create(pathFile).Close();

            using (var writer = new StreamWriter(pathFile, true))
            {
                writer.WriteLine(password);
            }
            this.StatusMessage = "Zapisano z powodzeniem.";
        }

        public void LoadPasswordFromFile(string pathFile)
        {
            if (File.Exists(pathFile))
            {
                using (var reader = new StreamReader(pathFile))
                {
                    this.HashedPassword = reader.ReadToEnd();
                }
                this.StatusMessage = "Odczyt poprawny";
            }
            else
            {
                this.ErrorMessage = "Brak pliku do odczytu";
                this.StatusMessage = "brak";
            }
        }
        public string Info() 
        {
            return "Dll Version: 2.00\n" +
                "Autor:       Krzysztof Szwajka\n" +
                "Tel.:        +48 785 192 785\n" +
                "e-mail:      k.szwajka@gmail.com";
        }
    }
}
