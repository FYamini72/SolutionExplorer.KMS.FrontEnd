using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.IdentifierDtos
{
    public class ReferenceSearchDto : BaseSearchDto
    {

        [Display(Name = "عنوان منبع")]
        public string? Title { get; set; }

        [Display(Name = "شناسنامه")]
        public int? IdentifierId { get; set; }
    }
}
