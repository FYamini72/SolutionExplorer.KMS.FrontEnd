using SolutionExplorer.KMS.SharedUI.Dtos.PhysicalSpecificationDtos;
using SolutionExplorer.KMS.SharedUI.Dtos.QCBaseInfoExpectedResultDtos;
using SolutionExplorer.KMS.SharedUI.Dtos.QualityControlResultDtos;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.QualityControlDtos
{
    public class QualityControlDisplayDto : BaseDto
    {
        public int QualityControlBaseInfoId { get; set; }
     
        [Display(Name = "تاریخ انجام")]
        public DateTime SampleDate { get; set; }
        [Display(Name = "تولید کننده")]
        public string Produces { get; set; }
        [Display(Name = "عنوان")]
        public string? Title { get; set; }
        [Display(Name = "سازنده")]
        public string? Manufacturer { get; set; }
        [Display(Name = "سری")]
        public string? Series { get; set; }
        [Display(Name = "تاریخ تولید")]
        public DateTime ProductionDate { get; set; }
        [Display(Name = "تاریخ انقضا")]
        public DateTime ExpirationDate { get; set; }
        public int? StorageConditionId { get; set; }
        [Display(Name = "شرایط نگهداری")]
        public string? StorageConditionTitle { get; set; }

        [Display(Name = "انجام دهنده")]
        public int? PerformedByUserId { get; set; }
        [Display(Name = "انجام دهنده")]
        public string? PerformedByUserFullName { get; set; }

        [Display(Name = "تایید کننده")]
        public int FirstConfirmerUserId { get; set; }
        [Display(Name = "تایید کننده")]
        public string FirstConfirmerUserFullName { get; set; }

        [Display(Name = "تصدیق کننده")]
        public int SecondConfirmerUserId { get; set; }
        [Display(Name = "تصدیق کننده")]
        public string SecondConfirmerUserFullName { get; set; }

        [Display(Name = "نتیجه نهایی")]
        public bool IsConfirmed { get; set; }



        [Display(Name = "مشخصات فیزیکی")]
        public List<PhysicalSpecificationDisplayDto> PhysicalSpecifications { get; set; }

        [Display(Name = "نتایج")]
        public List<QualityControlResultDisplayDto> QualityControlResults { get; set; }
    }
}
