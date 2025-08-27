using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.UserDtos
{
    public class UserCreateDto : BaseDto
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string Password { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string? FirstName { get; set; }
        
        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }
    }
}
