using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.PersonnelColorBlindnessTestDtos
{
    public class PersonnelColorBlindnessTestSearchDto : BaseSearchDto
    {
        [Display(Name = "پرسنل")]
        public int? PersonnelId { get; set; }
        [Display(Name = "تاریخ استخدام")]
        public DateTime? TestDate { get; set; }
        [Display(Name = "نتیجه")]
        public int? IsConfirmed { get; set; }
    }
}
