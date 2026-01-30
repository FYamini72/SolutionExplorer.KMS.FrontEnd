using SolutionExplorer.KMS.SharedUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.QualityControlBaseInfoDtos
{
    public class QualityControlBaseInfoCreateDto : BaseDto
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }
        //[Display(Name = "سازنده")]
        //public string? Manufacturer { get; set; }
        //[Display(Name = "سری")]
        //public string? Series { get; set; }
        //[Display(Name = "تاریخ تولید")]
        //public DateTime ProductionDate { get; set; }
        //[Display(Name = "تاریخ انقضا")]
        //public DateTime ExpirationDate { get; set; }
        //[Display(Name = "شرایط نگهداری")]
        //public string? StorageConditionText { get; set; }
        [Display(Name = "فاصله زمانی کنترل کیفی")]
        public QualityControlPeriod QualityControlPeriod { get; set; }
        [Display(Name = "هر چند روز؟")]
        public int? DayIntervalCount { get; set; }
        [Display(Name = "تاریخ کنترل کیفی بعدی")]
        public DateTime NextQualityControlTime { get; set; }
        [Display(Name = "دسته بندی")]
        public QCCategory Category { get; set; }
    }
}
