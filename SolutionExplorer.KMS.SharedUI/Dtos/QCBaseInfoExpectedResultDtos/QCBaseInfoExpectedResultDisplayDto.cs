using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.SharedUI.Dtos.QCBaseInfoExpectedResultDtos
{
    public class QCBaseInfoExpectedResultDisplayDto : BaseDto
    {
        public int QualityControlBaseInfoId { get; set; }

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
