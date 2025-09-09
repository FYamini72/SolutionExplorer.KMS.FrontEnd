using System.Security.Cryptography;

namespace SolutionExplorer.KMS.WinUI.Utilities
{
    public static class EncryptedPdfService
    {
        /// <summary>
        /// مسیر باید مسیر کامل فایل .enc (مثلاً Path.Combine(env.WebRootPath, "EncryptedFiles", fileName)) باشد.
        /// این متد فایل را در حافظه رمزگشایی می‌کند و MemoryStream بازمی‌گرداند.
        /// Caller باید MemoryStream را Dispose کند.
        /// </summary>
        public static MemoryStream DecryptPdfToStream(string fullPath)
        {
            if (!File.Exists(fullPath))
                throw new FileNotFoundException("Encrypted PDF not found.", fullPath);

            MemoryStream decryptedStream = new MemoryStream();

            using (FileStream inputFile = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            using (Aes aes = Aes.Create())
            {
                aes.Key = EncryptionKeys.Key;
                aes.IV = EncryptionKeys.IV;

                // Mode & Padding از پیش‌فرض AES استفاده می‌شود (CBC + PKCS7)
                using (CryptoStream cryptoStream = new CryptoStream(inputFile, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cryptoStream.CopyTo(decryptedStream);
                }
            }

            decryptedStream.Position = 0;
            return decryptedStream;
        }

        public static MemoryStream DecryptPdfToStream(Stream encryptedStream)
        {
            if (encryptedStream == null || encryptedStream.Length == 0)
                throw new ArgumentException("Invalid encrypted stream");

            MemoryStream decryptedStream = new MemoryStream();

            using (Aes aes = Aes.Create())
            {
                aes.Key = EncryptionKeys.Key;
                aes.IV = EncryptionKeys.IV;

                using (CryptoStream cryptoStream = new CryptoStream(encryptedStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cryptoStream.CopyTo(decryptedStream);
                }
            }

            decryptedStream.Position = 0;
            return decryptedStream;
        }
    }
}
