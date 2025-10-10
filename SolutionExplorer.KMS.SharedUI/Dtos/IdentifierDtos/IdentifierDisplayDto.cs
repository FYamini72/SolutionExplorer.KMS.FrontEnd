using SolutionExplorer.KMS.SharedUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.IdentifierDtos
{
    public class IdentifierDisplayDto : BaseDto
    {
        [Display(Name = "اسم سند")]
        public string? Title { get; set; }

        [Display(Name = "شماره سند")]
        public string? DocumentNumber { get; set; }
        
        [Display(Name = "دسته بندی سند")]
        public DocumentCategory Category { get; set; }
        
        [Display(Name = "شماره ویرایش")]
        public string? EditNo { get; set; }
        
        [Display(Name = "شناسه دیتابیسی کاربر تهیه کننده")]
        public int? ProducerUserId { get; set; }
        [Display(Name = "تهیه کننده")]
        public string? ProducerUserFullName { get; set; }

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
