using Microsoft.AspNetCore.Components.Forms;

namespace SolutionExplorer.KMS.SharedUI.Dtos
{
    public class BaseFileInfo
    {
        public IBrowserFile? SelectedFile { get; set; }
        public byte[]? SelectedFileBytes { get; set; }          // برای ارسال به سرور
        public string? SelectedFileName { get; set; }
        public string? SelectedFileContentType { get; set; }
    }
}
