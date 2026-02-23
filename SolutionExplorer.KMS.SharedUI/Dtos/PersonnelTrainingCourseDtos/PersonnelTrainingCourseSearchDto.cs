using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.PersonnelTrainingCourseDtos
{
    public class PersonnelTrainingCourseSearchDto : BaseSearchDto
    {
        [Display(Name = "پرسنل")]
        public int? PersonnelId { get; set; }
        [Display(Name = "وضعیت قبولی")]
        public int? IsConfirmed { get; set; }
    }
}
