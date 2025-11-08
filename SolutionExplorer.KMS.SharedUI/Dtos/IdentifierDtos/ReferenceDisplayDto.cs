using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.IdentifierDtos
{
    public class ReferenceDisplayDto : BaseDto 
    {
        [Display(Name = "شناسنامه")]
        public int IdentifierId { get; set; }
        [Display(Name = "عنوان منبع")]
        public string? Title { get; set; }

        [Display(Name = "فایل پیوست")]
        public int? AttachmentFileId { get; set; }
        public string? AttachmentFileName { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
    }
}
