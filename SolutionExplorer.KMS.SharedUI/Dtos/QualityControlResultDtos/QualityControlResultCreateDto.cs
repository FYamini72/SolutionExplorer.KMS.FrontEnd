using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.QualityControlResultDtos
{
    public class QualityControlResultCreateDto : BaseDto
    {
        public int QCBaseInfoExpectedResultId { get; set; }
        public int QualityControlId { get; set; }
        public bool IsConfirmed { get; set; }
        public string? CorrectiveActions { get; set; }

        [Display(Name = "ارگانیسم کنترل")]
        public string ATCCControlOrganism { get; set; }

        [Display(Name = "نتیجه مورد انتظار")]
        public string ExpectedResult { get; set; }

        [Display(Name = "قطر هاله براساس میلی‌متر")]
        public string? HaloDiameter { get; set; }

        [Display(Name = "پلی گروه A")]
        public string? PoliGroup_A { get; set; }

        [Display(Name = "پلی گروه B")]
        public string? PoliGroup_B { get; set; }

        [Display(Name = "پلی گروه C")]
        public string? PoliGroup_C { get; set; }

        [Display(Name = "پلی گروه D")]
        public string? PoliGroup_D { get; set; }
    }
}
