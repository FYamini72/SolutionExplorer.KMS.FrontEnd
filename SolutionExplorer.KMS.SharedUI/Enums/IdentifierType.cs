using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Enums
{
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
        ReportAnswer,
        [Display(Name = "منابع")]
        References
    }
}
