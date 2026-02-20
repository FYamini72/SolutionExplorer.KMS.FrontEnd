using SolutionExplorer.KMS.SharedUI.Dtos.PersonnelDtos;
using SolutionExplorer.KMS.SharedUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.PersonnelColorBlindnessTestDtos
{
    public class PersonnelColorBlindnessTestDisplayDto : BaseDto
    {
        [Display(Name = "پرسنل")]
        public int PersonnelId { get; set; }
        [Display(Name = "تاریخ استخدام")]
        public DateTime? EmploymentDate { get; set; }
        [Display(Name = "شماره پرسنلی")]
        public string PersonnelNumber { get; set; }
        [Display(Name = "پیشوند")]
        public Prefix Prefix { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        public string? PersonnelFullName { get; set; }

        [Display(Name = "تاریخ انجام")]
        public DateTime TestDate { get; set; }
        [Display(Name = "تشخیص رنگ قرمز")]
        public bool RedColorDetection { get; set; }
        [Display(Name = "تشخیص رنگ آبی")]
        public bool BlueColorDetection { get; set; }
        [Display(Name = "تشخیص رنگ زرد")]
        public bool YellowColorDetection { get; set; }
        [Display(Name = "نتیجه")]
        public bool IsConfirmed { get; set; }

        [Display(Name = "کاربر تایید کننده")]
        public int? FirstConfirmerUserId { get; set; }
        [Display(Name = "کاربر تایید کننده")]
        public string? FirstConfirmerUserFullName { get; set; }

        [Display(Name = "کاربر تصدیق کننده")]
        public int? SecondConfirmerUserId { get; set; }
        [Display(Name = "کاربر تصدیق کننده")]
        public string? SecondConfirmerUserFullName { get; set; }
    }
}
