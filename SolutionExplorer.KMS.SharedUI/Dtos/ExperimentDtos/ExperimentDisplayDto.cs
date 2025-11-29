using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.ExperimentDtos
{
    public class ExperimentDisplayDto : BaseDto
    {
        [Display(Name = "شناسنامه")]
        public int? IdentifierId { get; set; }

        [Display(Name = "عنوان")]
        public string? Title { get; set; }
        
        [Display(Name = "کد ملی آزمایش")]
        public string? Code { get; set; }
        
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "شناسه دیتابیسی کاربر تایید کننده")]
        public int? FirstConfirmerUserId { get; set; }

        [Display(Name = "تایید کننده")]
        public string? FirstConfirmerUserFullName { get; set; }

        [Display(Name = "شناسه دیتابیسی کاربر تصدیق کننده")]
        public int? SecondConfirmerUserId { get; set; }

        [Display(Name = "تصدیق کننده")]
        public string? SecondConfirmerUserFullName { get; set; }
    }
}
