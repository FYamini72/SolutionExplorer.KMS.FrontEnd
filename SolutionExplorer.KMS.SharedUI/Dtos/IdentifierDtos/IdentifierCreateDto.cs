using SolutionExplorer.KMS.SharedUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.IdentifierDtos
{
    public class IdentifierCreateDto : BaseDto
    {
        [Display(Name = "اسم سند")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string? Title { get; set; }

        [Display(Name = "شماره سند")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string? DocumentNumber { get; set; }

        [Display(Name = "دسته بندی سند")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public DocumentCategory? Category { get; set; }

        [Display(Name = "شماره ویرایش")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string? EditNo { get; set; }

        [Display(Name = "تهیه کننده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public int? ProducerUserId { get; set; }

        [Display(Name = "تایید کننده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public int? FirstConfirmerUserId { get; set; }

        [Display(Name = "تصدیق کننده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public int? SecondConfirmerUserId { get; set; }
    }
}
