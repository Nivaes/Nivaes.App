namespace Nivaes.App
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    public static class EncryptHelper
    {
        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        private static readonly byte[] SaltBytes = new byte[] { 21, 203, 33, 47, 5, 216, 127, 68 };

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="plainText">String to be encrypted</param>
        /// <param name="password">Password</param>
        public static async Task<string?> Encrypt(string plainText, string password)
        {
            if (plainText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = string.Empty;
            }

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = await Encrypt(bytesToBeEncrypted, passwordBytes).ConfigureAwait(false);

            return Convert.ToBase64String(bytesEncrypted);
        }

        /// <summary>
        /// Decrypt a string.
        /// </summary>
        /// <param name="encryptedText">String to be decrypted</param>
        /// <param name="password">Password used during encryption</param>
        /// <exception cref="FormatException"></exception>
        public static async Task<string?> Decrypt(string encryptedText, string password)
        {
            if (encryptedText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = string.Empty;
            }

            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = await Decrypt(bytesToBeDecrypted, passwordBytes).ConfigureAwait(false);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        private static async Task<byte[]> Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[]? encryptedBytes = null;



            using (MemoryStream ms = new MemoryStream())
            {
                using (var aes = Aes.Create())
                {
                    using var key = new Rfc2898DeriveBytes(passwordBytes, SaltBytes, 1000, HashAlgorithmName.SHA256);

                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);

                    aes.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        await cs.WriteAsync(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length).ConfigureAwait(false);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private static async Task<byte[]> Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[]? decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (var aes = Aes.Create())
                {
                    using var key = new Rfc2898DeriveBytes(passwordBytes, SaltBytes, 1000, HashAlgorithmName.SHA256);

                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);
                    aes.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        await cs.WriteAsync(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length).ConfigureAwait(false);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}
