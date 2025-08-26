using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.UserDtos
{
    public class UserChangePasswordDto : BaseDto
    {
        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [MinLength(6, ErrorMessage = "حداقل طول مجاز برای این فیلد 6 کاراکتر می‌باشد.")]
        public string NewPassword { get; set; }
    }
}
