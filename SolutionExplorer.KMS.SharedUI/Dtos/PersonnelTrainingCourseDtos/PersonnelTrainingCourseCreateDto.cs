using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.PersonnelTrainingCourseDtos
{
    public class PersonnelTrainingCourseCreateDto : BaseDto
    {
        [Display(Name = "پرسنل")]
        public int PersonnelId { get; set; }
        [Display(Name = "عنوان دوره")]
        public string? Title { get; set; }
        [Display(Name = "مدت دوره (ساعت)")]
        public int? Duration { get; set; }
        [Display(Name = "نام استاد")]
        public string? TeacherFullName { get; set; }
        [Display(Name = "تاریخ برگزاری")]
        public DateTime DateOfEvent { get; set; }
        [Display(Name = "نمره قبولی")]
        public int? QualificationCriteria { get; set; }
        [Display(Name = "نمره کسب شده")]
        public int? ScoreEarned { get; set; }
        [Display(Name = "وضعیت قبولی")]
        public bool IsConfirmed { get; set; }
        [Display(Name = "کاربر تایید کننده")]
        public int? FirstConfirmerUserId { get; set; }
        [Display(Name = "کاربر تصدیق کننده")]
        public int? SecondConfirmerUserId { get; set; }
    }

    public class PersonnelTrainingCourseDisplayDto : BaseDto
    {
        [Display(Name = "پرسنل")]
        public int PersonnelId { get; set; }
        [Display(Name = "شماره پرسنلی")]
        public string PersonnelNumber { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        public string? PersonnelFullName { get; set; }
        [Display(Name = "عنوان دوره")]
        public string? Title { get; set; }
        [Display(Name = "مدت دوره (ساعت)")]
        public int Duration { get; set; }
        [Display(Name = "نام استاد")]
        public string? TeacherFullName { get; set; }
        [Display(Name = "تاریخ برگزاری")]
        public DateTime DateOfEvent { get; set; }
        [Display(Name = "نمره قبولی")]
        public int QualificationCriteria { get; set; }
        [Display(Name = "نمره کسب شده")]
        public int ScoreEarned { get; set; }
        [Display(Name = "وضعیت قبولی")]
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
