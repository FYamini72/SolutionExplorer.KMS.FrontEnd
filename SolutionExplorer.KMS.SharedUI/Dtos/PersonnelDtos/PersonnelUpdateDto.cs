using SolutionExplorer.KMS.SharedUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.PersonnelDtos
{
    public class PersonnelUpdateDto : BaseDto
    {
        #region Fields Of User Table

        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        public string? RePassword { get; set; }

        [Display(Name = "نام")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [Display(Name = "نقش‌های کاربری")]
        public List<int>? RoleIds { get; set; }

        [Display(Name = "تصویر پروفایل")]
        public BaseFileInfo? ProfileSelectedFile { get; set; }

        [Display(Name = "تصویر امضا")]
        public BaseFileInfo? SignatureSelectedFile { get; set; }

        #endregion

        [Display(Name = "پیشوند")]
        public Prefix? Prefix { get; set; }

        [Display(Name = "جنسیت")]
        public Gender? Gender { get; set; }

        [Display(Name = "سمت شغلی")]
        public Position? Position { get; set; }

        [Display(Name = "مدرک تحصیلی")]
        public EducationalDegree? EducationalDegree { get; set; }

        [Display(Name = "رشته تحصیلی")]
        public string? EducationalField { get; set; }

        [Display(Name = "تایید کننده")]
        public int? FirstConfirmerUserId { get; set; }

        [Display(Name = "تصدیق کننده")]
        public int? SecondConfirmerUserId { get; set; }

        [Display(Name = "جانشین")]
        public int? SuccessorUserId { get; set; }

        [Display(Name = "چارت سازمانی")]
        public string? OrganizationalChart { get; set; }
    }
}
