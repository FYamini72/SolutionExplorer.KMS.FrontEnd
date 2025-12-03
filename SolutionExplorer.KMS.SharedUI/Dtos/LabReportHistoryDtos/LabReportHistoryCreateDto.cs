using SolutionExplorer.KMS.SharedUI.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.LabReportHistoryDtos
{
    public class LabReportHistoryCreateDto : BaseDto
    {
        //public DateTime ReportDateTime 
        //{ 
        //    get 
        //    {
        //        if (ReportTime.HasValue)
        //            ReportDate.AddMinutes(ReportTime.Value.TotalMinutes);

        //        return ReportDate;
        //    }
        //    set
        //    {
        //        ReportDate = value.Date;
        //        ReportTime = value.Date.TimeOfDay;
        //    }
        //}

        public DateTime ReportDateTime
        {
            get
            {
                var date = ReportDate.Date;
                if (ReportTime.HasValue)
                    date = date.Add(ReportTime.Value);
                return date;
            }
            set
            {
                ReportDate = value.Date;
                ReportTime = value.TimeOfDay;
            }
        }

        [Display(Name = "تاریخ گزارش")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public DateTime ReportDate { get; set; } = DateTime.Now;

        [Display(Name = "ساعت گزارش")]
        public TimeSpan? ReportTime { get; set; } = DateTime.Now.TimeOfDay;

        [Display(Name = "گزارش‌دهنده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public int ReporterUserId { get; set; }

        [Display(Name = "دریافت‌کننده")]
        public int? ReceiverUserId { get; set; }

        [Display(Name = "نام بیمار")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string PatientName { get; set; }

        [Display(Name = "شماره پذیرش")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string AdmissionNumber { get; set; }

        [Display(Name = "وضعیت بحرانی")]
        public bool IsCritical { get; set; }

        [Display(Name = "شرح آزمایش")]
        public string? Description { get; set; }

        [Display(Name = "توضیحات گزارش‌دهنده")]
        public string? ReporterComment { get; set; }

        [Display(Name = "تأییدکننده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public int FirstConfirmerUserId { get; set; }

        [Display(Name = "تصدیق‌کننده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public int SecondConfirmerUserId { get; set; }
    }
}