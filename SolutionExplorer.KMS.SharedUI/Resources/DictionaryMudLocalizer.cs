using Microsoft.Extensions.Localization;
using MudBlazor;

namespace SolutionExplorer.KMS.SharedUI.Resources
{
    public class DictionaryMudLocalizer : MudLocalizer
    {
        private Dictionary<string, string> _localization;

        public DictionaryMudLocalizer()
        {
            _localization = new()
            {
                { "MudDataGrid_Apply", "اعمال" },
                { "MudDataGrid_Clear", "پاک کردن" },
                { "MudDataGrid_AddFilter", "افزودن فیلتر" },
                { "MudDataGrid_Cancel", "انصراف" },
                { "MudDataGrid_Loading", "در حال بارگذاری..." },
                { "MudDataGrid_Save", "ذخیره" },
                { "MudDataGrid_HideAll", "مخفی کردن همه" },
                { "MudDataGrid_ShowAll", "نمایش همه" },
                { "MudDataGrid_Columns", "ستون‌ها" },
                { "MudDataGrid_ExpandAllGroups", "باز کردن همه گروه‌ها" },
                { "MudDataGrid_CollapseAllGroups", "بستن همه گروه‌ها" },
                { "MudDataGrid_RefreshData", "تازه‌کردن داده" },
                { "MudDataGrid_True", "صحیح" },
                { "MudDataGrid_False", "غلط" },
                { "MudDataGrid_Unsort", "حذف مرتب‌سازی" },
                { "MudDataGrid_Filter", "فیلتر" },
                { "MudDataGrid_Hide", "مخفی کردن" },
                { "MudDataGrid_Ungroup", "حذف گروه‌بندی" },
                { "MudDataGrid_Group", "گروه‌بندی" },
                { "MudDataGrid_FilterValue", "مقدار فیلتر" },
                { "MudDataGrid_Contains", "شامل" },
                { "MudDataGrid_NotContains", "شامل نباشد" },
                { "MudDataGrid_Equals", "برابر با" },
                { "MudDataGrid_NotEquals", "مخالف با" },
                { "MudDataGrid_StartsWith", "شروع با" },
                { "MudDataGrid_EndsWith", "پایان با" },
                { "MudDataGrid_IsEmpty", "خالی است" },
                { "MudDataGrid_IsNotEmpty", "خالی نیست" },
                { "MudDataGrid_EqualSign", "=" },
                { "MudDataGrid_NotEqualSign", "!=" },
                { "MudDataGrid_GreaterThanSign", ">" },
                { "MudDataGrid_GreaterThanOrEqualSign", ">=" },
                { "MudDataGrid_LessThanSign", "<" },
                { "MudDataGrid_LessThanOrEqualSign", "<=" },
                { "MudDataGrid_Is", "است" },
                { "MudDataGrid_IsNot", "نیست" },
                { "MudDataGrid_IsAfter", "بعد از" },
                { "MudDataGrid_IsOnOrAfter", "در یا بعد از" },
                { "MudDataGrid_IsBefore", "قبل از" },
                { "MudDataGrid_IsOnOrBefore", "در یا قبل از" },
                { "MudDataGrid_Column", "ستون" },
                { "MudDataGrid_Operator", "عملگر" },
                { "MudDataGrid_Value", "مقدار" },
                { "MudDataGrid_MoveDown", "انتقال به پایین" },
                { "MudDataGrid_MoveUp", "انتقال به بالا" },
                { "MudDataGrid_Sort", "مرتب‌سازی" },
                { "MudNavGroup_ToggleExpand", "تغییر وضعیت {0}" },
                { "MudAlert_Close", "بستن" },
                { "MudChip_Close", "بستن" },
                { "MudColorPicker_Close", "بستن" },
                { "MudColorPicker_SpectrumView", "طیف" },
                { "MudColorPicker_GridView", "جدول" },
                { "MudColorPicker_PaletteView", "پالت" },
                { "MudColorPicker_ShowSwatches", "نمایش نمونه‌رنگ‌ها" },
                { "MudColorPicker_HideSwatches", "مخفی کردن نمونه‌رنگ‌ها" },
                { "MudColorPicker_HueSlider", "نوار لغزنده رنگ" },
                { "MudColorPicker_AlphaSlider", "نوار لغزنده شفافیت" },
                { "MudColorPicker_ModeSwitch", "تغییر حالت" },
                { "MudBaseDatePicker_PrevYear", "سال قبل {0}" },
                { "MudBaseDatePicker_NextYear", "سال بعد {0}" },
                { "MudBaseDatePicker_PrevMonth", "ماه قبل {0}" },
                { "MudBaseDatePicker_NextMonth", "ماه بعد {0}" },
                { "MudPagination_CurrentPage", "صفحه جاری {0}" },
                { "MudPagination_FirstPage", "صفحه اول" },
                { "MudPagination_LastPage", "صفحه آخر" },
                { "MudPagination_NextPage", "صفحه بعد" },
                { "MudPagination_PageIndex", "صفحه {0}" },
                { "MudPagination_PreviousPage", "صفحه قبل" },
                { "MudRatingItem_Label", "امتیاز {0}" },
                { "MudCarousel_Index", "اندیس {0}" },
                { "MudCarousel_Next", "بعدی" },
                { "MudCarousel_Previous", "قبلی" },
                { "MudDialog_Close", "بستن" },
                { "MudInput_Clear", "پاک کردن" },
                { "MudInput_Decrement", "کاهش" },
                { "MudInput_Increment", "افزایش" },
                { "MudPageContentNavigation_NavMenu", "محتوا" },
                { "MudTablePager_FirstPage", "صفحه اول" },
                { "MudTablePager_LastPage", "صفحه آخر" },
                { "MudTablePager_NextPage", "صفحه بعد" },
                { "MudTablePager_PreviousPage", "صفحه قبل" },
                { "MudSnackbar_Close", "بستن" },
                { "MudDataGridPager_RowsPerPage", "ردیف در صفحه:" },
                { "MudDataGridPager_AllItems", "همه" },
                { "MudDataGridPager_InfoFormat", "{0}-{1} از {2}" },
                { "MudStepper_Next", "بعدی" },
                { "MudStepper_Previous", "قبلی" },
                { "MudStepper_Skip", "رد کردن" },
                { "MudStepper_Reset", "بازنشانی" },
                { "MudStepper_Complete", "تکمیل" },
                { "MudDataGrid_ClearFilter", "پاک کردن فیلتر" },
                { "MudDataGrid_OpenFilters", "باز کردن فیلترها" },
                { "MudDataGrid_ToggleGroupExpansion", "تغییر وضعیت گروه" },
                { "MudDataGrid_RemoveFilter", "حذف فیلتر" },
                { "MudDataGridPager_FirstPage", "صفحه اول" },
                { "MudDataGridPager_PreviousPage", "صفحه قبل" },
                { "MudDataGridPager_NextPage", "صفحه بعد" },
                { "MudDataGridPager_LastPage", "صفحه آخر" },
                { "MudDataGrid_ShowColumnOptions", "گزینه‌های ستون" },
                { "Converter_InvalidBoolean", "مقدار بولی معتبر نیست" },
                { "Converter_InvalidNumber", "عدد معتبر نیست" },
                { "Converter_InvalidGUID", "GUID معتبر نیست" },
                { "Converter_NotValueOf", "مقداری از {0} نیست" },
                { "Converter_InvalidDateTime", "تاریخ/زمان معتبر نیست" },
                { "Converter_InvalidTimeSpan", "بازه زمانی معتبر نیست" },
                { "Converter_InvalidType", "{0} معتبر نیست" },
                { "Converter_ConversionNotImplemented", "تبدیل به نوع {0} پیاده‌سازی نشده" },
                { "Converter_ConversionError", "خطای تبدیل: {0}" },
                { "Converter_ConversionFailed", "تبدیل از {0} به {1} ناموفق بود: {2}" },
                { "Converter_UnableToConvert", "عدم توانایی در تبدیل به {0} از نوع {1}" },
                { "HeatMap_Less", "کمتر" },
                { "HeatMap_More", "بیشتر" },
                { "MudTreeView_ExpandItem", "باز کردن" },
                { "MudTreeView_CollapseItem", "بستن" },
                { "MudTimePicker_Open", "باز کردن" },
                { "MudBaseDatePicker_Open", "باز کردن" },
                { "MudColorPicker_Open", "باز کردن" },
                { "MudFileUpload_FileSizeError", "فایل '{0}' از حداکثر اندازه مجاز {1} بایت بیشتر است." }
            };
        }

        public override LocalizedString this[string key]
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentUICulture;

                // بررسی هم به صورت "fa" و هم "fa-IR"
                if ((currentCulture.TwoLetterISOLanguageName.Equals("fa", StringComparison.OrdinalIgnoreCase) ||
                    (currentCulture.Name.Equals("fa-IR", StringComparison.OrdinalIgnoreCase))))
                {
                    if (_localization.TryGetValue(key, out var res))
                    {
                        return new(key, res);
                    }
                }

                // اگر فارسی نبود یا کلید پیدا نشد، متن اصلی برگردانده می‌شود
                return new(key, key, resourceNotFound: true);
            }
        }
    }
}
