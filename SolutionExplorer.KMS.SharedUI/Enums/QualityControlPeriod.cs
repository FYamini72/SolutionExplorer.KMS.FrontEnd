using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Enums
{
    public enum QualityControlPeriod
    {
        [Display(Name = "روزانه")]
        Daily,
        [Display(Name = "ماهانه")]
        Monthly,
        [Display(Name = "سه ماهه")]
        Quarterly,
        [Display(Name = "دوره ای")]
        Periodic
    }
}
