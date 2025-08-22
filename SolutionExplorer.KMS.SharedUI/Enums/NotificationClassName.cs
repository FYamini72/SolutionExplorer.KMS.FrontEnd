using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Enums
{
    public enum NotificationClassName
    {
        [Display(Name = "success")]
        Success,
        [Display(Name = "error")]
        Error,
        [Display(Name = "warning")]
        Warning,
        [Display(Name = "info")]
        Info,
        [Display(Name = "question")]
        question
    }
}
