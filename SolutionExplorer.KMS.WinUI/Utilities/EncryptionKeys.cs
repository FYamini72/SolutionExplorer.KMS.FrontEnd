using System.Text;

namespace SolutionExplorer.KMS.WinUI.Utilities
{
    public static class EncryptionKeys
    {
        // همان کلید و IV که قبلاً استفاده می‌کردی
        public static readonly byte[] Key = Encoding.UTF8.GetBytes("MySecretKey12345"); // 16 بایت
        public static readonly byte[] IV = Encoding.UTF8.GetBytes("MySecretIV123456");  // 16 بایت
    }
}
