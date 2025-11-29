using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.EquipmentDtos
{
    public class EquipmentCreateDto : BaseDto
    {
        [Display(Name = "شناسنامه")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public int? IdentifierId { get; set; }

        [Display(Name = "نام دستگاه")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string? Title { get; set; }

        [Display(Name = "کد دستگاه")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string? Code { get; set; }

        [Display(Name = "مدل")]
        public string? EquipmentModel { get; set; }

        [Display(Name = "شماره سریال")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string? SerialNo { get; set; }

        [Display(Name = "سازنده")]
        public string? Manufacturer { get; set; }

        [Display(Name = "کشور سازنده")]
        public string? ManufactureCountry { get; set; }

        [Display(Name = "تایید کننده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public int? FirstConfirmerUserId { get; set; }

        [Display(Name = "تصدیق کننده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public int? SecondConfirmerUserId { get; set; }
    }
}
