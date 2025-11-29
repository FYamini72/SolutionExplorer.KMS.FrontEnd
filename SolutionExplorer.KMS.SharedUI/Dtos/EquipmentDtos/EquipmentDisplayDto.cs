using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.EquipmentDtos
{
    public class EquipmentDisplayDto : BaseDto
    {
        [Display(Name = "شناسنامه")]
        public int? IdentifierId { get; set; }

        [Display(Name = "نام دستگاه")]
        public string? Title { get; set; }

        [Display(Name = "کد دستگاه")]
        public string? Code { get; set; }

        [Display(Name = "مدل")]
        public string? EquipmentModel { get; set; }

        [Display(Name = "شماره سریال")]
        public string? SerialNo { get; set; }

        [Display(Name = "سازنده")]
        public string? Manufacturer { get; set; }

        [Display(Name = "کشور سازنده")]
        public string? ManufactureCountry { get; set; }

        [Display(Name = "شناسه دیتابیسی کاربر تایید کننده")]
        public int? FirstConfirmerUserId { get; set; }

        [Display(Name = "تایید کننده")]
        public string? FirstConfirmerUserFullName { get; set; }

        [Display(Name = "شناسه دیتابیسی کاربر تصدیق کننده")]
        public int? SecondConfirmerUserId { get; set; }

        [Display(Name = "تصدیق کننده")]
        public string? SecondConfirmerUserFullName { get; set; }
    }
}
