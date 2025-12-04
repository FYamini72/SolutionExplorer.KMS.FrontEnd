using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.QualityControlBaseInfoDtos
{
    public class QCBaseInfoPhysicalSpecificationDisplayDto : BaseDto
    {
        public int QualityControlBaseInfoId { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "وضعیت")]
        public bool IsChecked { get; set; }
    }
}
