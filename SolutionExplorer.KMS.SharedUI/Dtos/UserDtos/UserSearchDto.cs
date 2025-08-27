using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.UserDtos
{
    public class UserSearchDto : BaseSearchDto
    {
        [Display(Name = "نام کاربری")]
        public string? UserName { get; set; }
        
        [Display(Name = "نام")]
        public string? FirstName { get; set; }
 
        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [Display(Name = "نقش")]
        public int? RoleId { get; set; }
    }
}
