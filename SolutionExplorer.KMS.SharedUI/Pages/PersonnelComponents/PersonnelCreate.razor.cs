using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SolutionExplorer.KMS.SharedUI.Dtos;
using SolutionExplorer.KMS.SharedUI.Dtos.PersonnelDtos;
using SolutionExplorer.KMS.SharedUI.Dtos.UserDtos;
using SolutionExplorer.KMS.SharedUI.Enums;
using SolutionExplorer.KMS.SharedUI.Services.Interfaces;
using SolutionExplorer.KMS.SharedUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionExplorer.KMS.SharedUI.Pages.PersonnelComponents
{
    public partial class PersonnelCreate : ComponentBase
    {
        [Inject] private IHttpService _httpService { get; set; }
        [Inject] private IJSRuntime _jsRuntime { get; set; }

        [Parameter] public EventCallback<bool> OnSavedChanges { get; set; }
        [Parameter] public int? Id { get; set; }

        // مدل فرم
        public PersonnelCreateDto Model { get; set; } = new()
        {
            RoleIds = new(),
            OrganizationalChart = "مسئول فنی: \r\nمسئول بخش: \r\nکارکنان بخش: \r\n"
        };

        // لیست کاربران برای Dropdown
        private List<KeyValuePair<int, string>> UsersKeyValue = new();
        private List<KeyValuePair<int, string>> RolesKeyValue = new();

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


            // گرفتن لیست کاربران
            var roleApiResult = await _httpService
                .GetByFilterAsync<RoleSearchDto, ApiResult<List<KeyValuePair<int, string>>>>(
                    "api/Role/GetByFilterForDropDown", new());

            RolesKeyValue = roleApiResult?.Data?.ToList() ?? new();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (!Id.HasValue) return;

            showSpinner = true;
            try
            {
                var apiResult = await _httpService.GetAsync<ApiResult<PersonnelCreateDto>>($"api/Personnel/{Id}");
                if (apiResult?.IsSuccess ?? false)
                    Model = apiResult.Data ?? new PersonnelCreateDto();
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
                ApiResult<PersonnelCreateDto> apiResult = null;

                if (Model.Id > 0)
                    apiResult = await _httpService.PutMultipartAsync<PersonnelCreateDto, ApiResult<PersonnelCreateDto>>(
                        "api/Personnel", Model);
                else
                    apiResult = await _httpService.PostMultipartAsync<PersonnelCreateDto, ApiResult<PersonnelCreateDto>>(
                        "api/Personnel", Model);

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

        private async Task HandleProfileFileSelected(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file == null) return;

            using var ms = new MemoryStream();
            await file.OpenReadStream(maxAllowedSize: 20 * 1024 * 1024).CopyToAsync(ms);

            Model.ProfileSelectedFile = new BaseFileInfo
            {
                SelectedFile = file,
                SelectedFileBytes = ms.ToArray(),
                SelectedFileName = file.Name,
                SelectedFileContentType = file.ContentType
            };
        }

        private async Task HandleSignatureFileSelected(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file == null) return;

            using var ms = new MemoryStream();
            await file.OpenReadStream(maxAllowedSize: 20 * 1024 * 1024).CopyToAsync(ms);

            Model.SignatureSelectedFile = new BaseFileInfo
            {
                SelectedFile = file,
                SelectedFileBytes = ms.ToArray(),
                SelectedFileName = file.Name,
                SelectedFileContentType = file.ContentType
            };
        }

        //private void OnRoleSelectionChanged(ChangeEventArgs e)
        //{
        //    if (e.Value is IEnumerable<string> selectedValues)
        //    {
        //        Model.RoleIds = selectedValues
        //            .Where(v => !string.IsNullOrEmpty(v))
        //            .Select(int.Parse)
        //            .ToList();
        //    }
        //    else
        //    {
        //        Model.RoleIds = new List<int>();
        //    }
        //}

        //private void OnRoleSelectionChanged(ChangeEventArgs e)
        //{
        //    var selected = e.Value?.ToString();

        //    if (string.IsNullOrEmpty(selected))
        //    {
        //        Model.RoleIds = new();
        //        return;
        //    }

        //    Model.RoleIds = selected
        //        .Split(',', StringSplitOptions.RemoveEmptyEntries)
        //        .Select(int.Parse)
        //        .ToList();
        //}

        private void OnRoleSelectionChanged(ChangeEventArgs e)
        {
            switch (e.Value)
            {
                case string[] values:
                    Model.RoleIds = values
                        .Where(v => !string.IsNullOrWhiteSpace(v))
                        .Select(int.Parse)
                        .ToList();
                    break;

                case string singleValue:
                    Model.RoleIds = new List<int> { int.Parse(singleValue) };
                    break;

                default:
                    Model.RoleIds = new List<int>();
                    break;
            }
        }

        private Task Cancel() => OnSavedChanges.InvokeAsync(false);

        private Task ShowMessage() => _jsRuntime.InvokeVoidAsync("showToast", ClassName.ToDisplay(), MessageBody).AsTask();
    }
}
