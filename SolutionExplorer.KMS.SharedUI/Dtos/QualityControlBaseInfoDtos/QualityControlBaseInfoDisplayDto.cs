using SolutionExplorer.KMS.SharedUI.Dtos.QCBaseInfoExpectedResultDtos;
using SolutionExplorer.KMS.SharedUI.Dtos.StorageConditionDtos;
using SolutionExplorer.KMS.SharedUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.QualityControlBaseInfoDtos
{
    public class QualityControlBaseInfoDisplayDto : BaseDto
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }
        [Display(Name = "فاصله زمانی کنترل کیفی")]
        public QualityControlPeriod QualityControlPeriod { get; set; }
        [Display(Name = "هر چند روز؟")]
        public int? DayIntervalCount { get; set; }
        [Display(Name = "تاریخ کنترل کیفی بعدی")]
        public DateTime NextQualityControlTime { get; set; }
        [Display(Name = "دسته بندی")]
        public QCCategory Category { get; set; }

        public List<StorageConditionDisplayDto> StorageConditions { get; set; } = new();
        public List<QCBaseInfoExpectedResultDisplayDto> QCBaseInfoExpectedResults { get; set; } = new();
        public List<QCBaseInfoPhysicalSpecificationDisplayDto> QCBaseInfoPhysicalSpecifications { get; set; } = new();
    }
}
