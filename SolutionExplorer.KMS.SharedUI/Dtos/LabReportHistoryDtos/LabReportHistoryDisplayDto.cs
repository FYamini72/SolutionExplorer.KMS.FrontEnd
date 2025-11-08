using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.LabReportHistoryDtos
{
    public class LabReportHistoryDisplayDto : BaseDto
    {
        [Display(Name = "تاریخ و ساعت گزارش")]
        public DateTime ReportDateTime { get; set; }

        [Display(Name = "وضعیت بحرانی")]
        public bool IsCritical { get; set; }

        [Display(Name = "شناسه گزارش‌دهنده")]
        public int ReporterUserId { get; set; }

        [Display(Name = "گزارش‌دهنده")]
        public string? ReporterUserFullName { get; set; }

        [Display(Name = "شناسه دریافت‌کننده")]
        public int? ReceiverUserId { get; set; }

        [Display(Name = "دریافت‌کننده")]
        public string? ReceiverUserFullName { get; set; }

        [Display(Name = "نام بیمار")]
        public string PatientName { get; set; }

        [Display(Name = "شماره پذیرش")]
        public string AdmissionNumber { get; set; }

        [Display(Name = "شرح آزمایش")]
        public string? Description { get; set; }

        [Display(Name = "توضیحات گزارش‌دهنده")]
        public string? ReporterComment { get; set; }

        [Display(Name = "شناسه تأییدکننده")]
        public int FirstConfirmerUserId { get; set; }

        [Display(Name = "تأییدکننده")]
        public string? FirstConfirmerUserFullName { get; set; }

        [Display(Name = "شناسه تصدیق‌کننده")]
        public int SecondConfirmerUserId { get; set; }

        [Display(Name = "تصدیق‌کننده")]
        public string? SecondConfirmerUserFullName { get; set; }
    }
}