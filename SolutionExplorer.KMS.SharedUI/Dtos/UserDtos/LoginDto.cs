using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.UserDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }
    }
}
