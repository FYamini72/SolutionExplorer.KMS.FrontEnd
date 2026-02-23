using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SolutionExplorer.KMS.SharedUI.Dtos;
using SolutionExplorer.KMS.SharedUI.Dtos.PersonnelTrainingCourseDtos;
using SolutionExplorer.KMS.SharedUI.Dtos.UserDtos;
using SolutionExplorer.KMS.SharedUI.Enums;
using SolutionExplorer.KMS.SharedUI.Services.Interfaces;
using SolutionExplorer.KMS.SharedUI.Utilities;

namespace SolutionExplorer.KMS.SharedUI.Pages.PersonnelTrainingCourseComponents
{
    public partial class PersonnelTrainingCourseCreate : ComponentBase
    {
        [Inject] private IHttpService _httpService { get; set; }
        [Inject] private IJSRuntime _jsRuntime { get; set; }

        [Parameter] public EventCallback<bool> OnSavedChanges { get; set; }
        [Parameter] public int? Id { get; set; }

        // مدل فرم
        public PersonnelTrainingCourseCreateDto Model { get; set; } = new();

        // لیست کاربران برای Dropdown
        private List<KeyValuePair<int, string>> UsersKeyValue = new();

        // مدیریت Spinner و پیام‌ها
        private bool showSpinner;
        private NotificationClassName ClassName = NotificationClassName.Success;
        private string MessageBody = "عملیات با موفقیت انجام شد.";

        protected override async Task OnInitializedAsync()
        {
            // گرفتن لیست کاربران
            var userApiResult = await _httpService
                .GetByFilterAsync<UserSearchDto, ApiResult<List<KeyValuePair<int, string>>>>(
                    "api/User/GetByFilterForDropDown", new());

            UsersKeyValue = userApiResult?.Data?.ToList() ?? new();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (!Id.HasValue) return;

            showSpinner = true;
            try
            {
                var apiResult = await _httpService.GetAsync<ApiResult<PersonnelTrainingCourseCreateDto>>($"api/PersonnelTrainingCourse/{Id}");
                if (apiResult?.IsSuccess ?? false)
                    Model = apiResult.Data ?? new PersonnelTrainingCourseCreateDto();
                else
                {
                    ClassName = NotificationClassName.Error;
                    MessageBody = apiResult?.Message ?? "خطایی رخ داده است.";
                    await ShowMessage();
                }
            }
            catch
            {
                ClassName = NotificationClassName.Error;
                MessageBody = "خطا در دریافت اطلاعات پرسنل.";
                await ShowMessage();
            }
            finally
            {
                showSpinner = false;
            }
        }

        private async Task HandleValidSubmit()
        {
            showSpinner = true;
            try
            {
                ApiResult<PersonnelTrainingCourseDisplayDto> apiResult = null;

                if (Model.Id > 0)
                    apiResult = await _httpService.PutAsync<PersonnelTrainingCourseCreateDto, ApiResult<PersonnelTrainingCourseDisplayDto>>(
                        "api/PersonnelTrainingCourse", Model);
                else
                    apiResult = await _httpService.PostAsync<PersonnelTrainingCourseCreateDto, ApiResult<PersonnelTrainingCourseDisplayDto>>(
                        "api/PersonnelTrainingCourse", Model);

                if (!apiResult?.IsSuccess ?? true)
                {
                    ClassName = NotificationClassName.Error;
                    MessageBody = apiResult?.Message ?? "خطایی رخ داده است.";
                    await ShowMessage();
                    return;
                }

                await OnSavedChanges.InvokeAsync(true);
            }
            catch
            {
                ClassName = NotificationClassName.Error;
                MessageBody = "خطایی رخ داده است.";
                await ShowMessage();
            }
            finally
            {
                showSpinner = false;
            }
        }

        private Task Cancel() => OnSavedChanges.InvokeAsync(false);

        private Task ShowMessage() => _jsRuntime.InvokeVoidAsync("showToast", ClassName.ToDisplay(), MessageBody).AsTask();
    }
}
