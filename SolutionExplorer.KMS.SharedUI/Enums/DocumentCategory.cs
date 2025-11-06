using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Enums
{
    public enum DocumentCategory
    {
        /// <summary>
        /// اطلاعات پایه آزمايشگاه ميکروب شناسی
        /// </summary>
        [Display(Name = "اطلاعات پایه آزمايشگاه ميکروب شناسی")]
        BaseInfoMicrobiologyLab
    }

    public enum IdentifierType
    {
        [Display(Name = "تعیین نشده")]
        NotSet,
        [Display(Name = "شناسنامه تجهیزات")]
        Equipment,
        [Display(Name = "شناسنامه آزمایشات")]
        Experiment,
        [Display(Name = "چک لیست ممیزی")]
        AuditChecklist,
        [Display(Name = "گزارش جواب")]
        ReportAnswer
    }
}
