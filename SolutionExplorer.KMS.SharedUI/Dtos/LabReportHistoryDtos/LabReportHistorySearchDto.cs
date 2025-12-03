using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.LabReportHistoryDtos
{
    public class LabReportHistorySearchDto : BaseSearchDto
    {
        [Display(Name = "نام بیمار")]
        public string? PatientName { get; set; }

        [Display(Name = "شماره پذیرش")]
        public string? AdmissionNumber { get; set; }

        [Display(Name = "گزارش‌دهنده")]
        public int? ReporterUserId { get; set; }

        [Display(Name = "دریافت‌کننده")]
        public int? ReceiverUserId { get; set; }

        [Display(Name = "وضعیت بحرانی")]
        public int IsCritical { get; set; }

        [Display(Name = "از تاریخ")]
        public DateTime? FromReportDate { get; set; }

        [Display(Name = "تا تاریخ")]
        public DateTime? ToReportDate { get; set; }
    }
}