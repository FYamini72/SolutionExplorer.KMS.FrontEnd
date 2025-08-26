using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.UserDtos
{
    public class UserUpdateDto : BaseDto
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        public string? NewPassword { get; set; }
    }
}
