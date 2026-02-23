using SolutionExplorer.KMS.SharedUI.Dtos.UserDtos;
using SolutionExplorer.KMS.SharedUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.PersonnelDtos
{
    public class PersonnelDisplayDto : BaseDto
    {
        [Display(Name = "نام کاربری")]
        public string? UserName { get; set; }
        [Display(Name = "نام")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [Display(Name = "نقش‌های کاربری")]
        public List<UserRoleDisplayDto> UserRoles { get; set; }


        [Display(Name = "شناسه پروفایل")]
        public int? ProfileId { get; set; }

        [Display(Name = "تصویر پروفایل")]
        public string? ProfileAttachmentUrl { get; set; }

        [Display(Name = "شناسه امضا")]
        public int? SignatureId { get; set; }

        [Display(Name = "تصویر امضا")]
        public string? SignatureAttachmentUrl { get; set; }

        [Display(Name = "پیشوند")]
        public Prefix Prefix { get; set; }

        [Display(Name = "جنسیت")]
        public Gender Gender { get; set; }

        [Display(Name = "سمت شغلی")]
        public Position Position { get; set; }

        [Display(Name = "مدرک تحصیلی")]
        public EducationalDegree EducationalDegree { get; set; }

        [Display(Name = "رشته تحصیلی")]
        public string? EducationalField { get; set; }
        [Display(Name = "تایید کننده")]
        public int? FirstConfirmerUserId { get; set; }
        [Display(Name = "تایید کننده")]
        public string? FirstConfirmerUserFullName { get; set; }

        [Display(Name = "تصدیق کننده")]
        public int? SecondConfirmerUserId { get; set; }
        [Display(Name = "تصدیق کننده")]
        public string? SecondConfirmerUserFullName { get; set; }

        [Display(Name = "جانشین")]
        public int? SuccessorUserId { get; set; }
        [Display(Name = "جانشین")]
        public string? SuccessorUserFullName { get; set; }

        [Display(Name = "چارت سازمانی")]
        public string? OrganizationalChart { get; set; }

        [Display(Name = "تاریخ استخدام")]
        public DateTime? EmploymentDate { get; set; }

        [Display(Name = "شماره پرسنلی")]
        public string? PersonnelNumber { get; set; }
    }
}
