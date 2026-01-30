using SolutionExplorer.KMS.SharedUI.Dtos.PhysicalSpecificationDtos;
using SolutionExplorer.KMS.SharedUI.Dtos.QualityControlResultDtos;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.QualityControlDtos
{
    public class QualityControlCreateDto : BaseDto
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
        [Display(Name = "شرایط نگهداری")]
        public int StorageConditionId { get; set; }
        //public string? StorageConditionText { get; set; }
        //[Display(Name = "مشخصات فیزیکی")]
        //public string? PhysicalSpecification { get; set; }
        [Display(Name = "انجام دهنده")]
        public int? PerformedByUserId { get; set; }
        [Display(Name = "تایید کننده")]
        public int FirstConfirmerUserId { get; set; }
        [Display(Name = "تصدیق کننده")]
        public int SecondConfirmerUserId { get; set; }
        [Display(Name = "نتیجه نهایی")]
        public bool IsConfirmed { get; set; }
        //[Display(Name = "توضیحات/اقدامات اصلاحی")]
        //public string? FinalResultNotes { get; set; }
        //[Display(Name = "نتیجه")]
        //public string? FinalResult { get; set; }


        public List<QualityControlResultCreateDto> QualityControlResults { get; set; }
        public List<PhysicalSpecificationCreateDto> PhysicalSpecifications { get; set; }
    }    
}
