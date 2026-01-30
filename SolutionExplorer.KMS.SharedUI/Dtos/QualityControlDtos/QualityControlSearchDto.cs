using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.QualityControlDtos
{
    public class QualityControlSearchDto : BaseSearchDto
    {
        public int? QualityControlBaseInfoId { get; set; }

        [Display(Name = "مشخصات فیزیکی")]
        public string? PhysicalSpecification { get; set; }
        [Display(Name = "انجام دهنده")]
        public int? PerformedByUserId { get; set; }
        [Display(Name = "تایید کننده")]
        public int? FirstConfirmerUserId { get; set; }
        [Display(Name = "تصدیق کننده")]
        public int? SecondConfirmerUserId { get; set; }
        [Display(Name = "نتیجه نهایی")]
        public int? FinalCondition { get; set; }
    }
}
