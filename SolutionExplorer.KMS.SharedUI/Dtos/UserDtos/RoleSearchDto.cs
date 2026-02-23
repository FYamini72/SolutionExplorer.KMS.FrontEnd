using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.UserDtos
{
    public class RoleSearchDto : BaseSearchDto
    {
        [Display(Name = "عنوان نقش")]
        public string? Title { get; set; }
    }
}
