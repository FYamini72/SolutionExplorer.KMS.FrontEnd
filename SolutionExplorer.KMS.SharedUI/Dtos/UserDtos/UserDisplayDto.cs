using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.UserDtos
{
    public class UserDisplayDto : BaseDto
    {
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "نقش‌ها")]
        public List<UserRoleDisplayDto> UserRoles { get; set; }

        [Display(Name = "شناسه تصویر پروفایل")]
        public int? ProfileId { get; set; }

        [Display(Name = "آدرس تصویر پروفایل")]
        public string? AttachmentUrl { get; set; }
    }
}
