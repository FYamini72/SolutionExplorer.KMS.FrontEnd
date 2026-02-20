using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.PersonnelColorBlindnessTestDtos
{
    public class PersonnelColorBlindnessTestCreateDto : BaseDto
    {
        [Display(Name = "پرسنل")]
        public int PersonnelId { get; set; }
        [Display(Name = "تاریخ استخدام")]
        public DateTime TestDate { get; set; }
        [Display(Name = "تشخیص رنگ قرمز")]
        public bool RedColorDetection { get; set; }
        [Display(Name = "تشخیص رنگ آبی")]
        public bool BlueColorDetection { get; set; }
        [Display(Name = "تشخیص رنگ زرد")]
        public bool YellowColorDetection { get; set; }
        [Display(Name = "نتیجه")]
        public bool IsConfirmed { get; set; }
        [Display(Name = "کاربر تصدیق کننده")]
        public int? FirstConfirmerUserId { get; set; }
        [Display(Name = "کاربر تصدیق کننده")]
        public int? SecondConfirmerUserId { get; set; }
    }
}
