using Microsoft.AspNetCore.Components.Forms;
using SolutionExplorer.KMS.SharedUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.SharedUI.Dtos.IdentifierDtos
{
    public class ReferenceCreateDto : BaseDto
    {
        [Display(Name = "عنوان منبع")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string? Title { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        /// <summary>
        /// فایل پیوست شده
        /// </summary>
        [Display(Name = "فایل پیوست")]
        public BaseFileInfo? SelectedFile { get; set; }

    }
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

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        /// <summary>
        /// فایل پیوست شده
        /// </summary>
        [Display(Name = "فایل پیوست")]
        public BaseFileInfo? SelectedFile { get; set; }

        [Display(Name = "نوع شناسنامه")]
        public IdentifierType IdentifierType { get; set; }
    }

    public class BaseFileInfo
    {
        public IBrowserFile? SelectedFile { get; set; }
        public byte[]? SelectedFileBytes { get; set; }          // برای ارسال به سرور
        public string? SelectedFileName { get; set; }
        public string? SelectedFileContentType { get; set; }
    }
}
