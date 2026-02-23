using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using SolutionExplorer.KMS.SharedUI.Dtos;
using SolutionExplorer.KMS.SharedUI.Dtos.PersonnelColorBlindnessTestDtos;
using SolutionExplorer.KMS.SharedUI.Dtos.UserDtos;
using SolutionExplorer.KMS.SharedUI.Enums;
using SolutionExplorer.KMS.SharedUI.Services.Interfaces;
using SolutionExplorer.KMS.SharedUI.Utilities;

namespace SolutionExplorer.KMS.SharedUI.Pages.PersonnelColorBlindnessTestComponents
{
    public partial class PersonnelColorBlindnessTestList : ComponentBase
    {
        [Inject] IHttpService Http { get; set; }
        [Inject] IJSRuntime JS { get; set; }

        FormState FormState = FormState.None;

        int? SelectedId = null;
        PersonnelColorBlindnessTestSearchDto SearchModel = new();
        MudTable<PersonnelColorBlindnessTestDisplayDto> Table;

        NotificationClassName ClassName = NotificationClassName.Success;
        string MessageBody = "عملیات با موفقت انجام شد.";

        List<KeyValuePair<int, string>> UsersKeyValue = new();

        protected override async Task OnInitializedAsync()
        {
            var result = await Http.GetByFilterAsync<UserSearchDto,
                ApiResult<List<KeyValuePair<int, string>>>>(
                "api/User/GetByFilterForDropDown", new());

            UsersKeyValue = result?.Data ?? new();
        }

        async Task<TableData<PersonnelColorBlindnessTestDisplayDto>> LoadServerData(TableState state, CancellationToken token)
        {
            SearchModel.CalculateTakeAndSkip(state.Page, state.PageSize);

            var result = await Http.GetByFilterAsync<PersonnelColorBlindnessTestSearchDto,
                ApiResult<BaseGridDto<PersonnelColorBlindnessTestDisplayDto>>>(
                "api/PersonnelColorBlindnessTest/GetByFilter", SearchModel);

            return new()
            {
                Items = result?.Data?.Data ?? Enumerable.Empty<PersonnelColorBlindnessTestDisplayDto>(),
                TotalItems = result?.Data?.TotalCount ?? 0
            };
        }

        void OnSearch() => Table.ReloadServerData();
        void ClearForm() { SearchModel = new(); OnSearch(); }

        void CreateNew()
        {
            SelectedId = null;
            FormState = FormState.Create;
        }

        void Edit(int id)
        {
            SelectedId = id;
            FormState = FormState.Edit;
        }

        private async Task DeleteItem(int itemId)
        {
            this.SelectedId = itemId;
            FormState = FormState.None;

            var confirmResult = await JS.InvokeAsync<bool>("confirmDelete", "آیا از حذف این آیتم اطمینان دارید؟");
            if (confirmResult)
            {
                var apiResult = await Http.DeleteAsync<ApiResult>($"api/PersonnelColorBlindnessTest?id={this.SelectedId}");

                if (apiResult?.IsSuccess ?? false)
                {
                    ClassName = NotificationClassName.Success;
                    MessageBody = "عملیات با موفقت انجام شد.";
                }
                else
                {
                    ClassName = NotificationClassName.Error;
                    MessageBody = apiResult?.Message ?? "خطایی رخ داده است. لطفا با پشتیبانی تماس بگیرید.";
                }

                await ShowMessage();
                await Table.ReloadServerData();
            }
        }

        private Task ShowMessage() => JS.InvokeVoidAsync("showToast", ClassName.ToDisplay(), MessageBody).AsTask();

        async Task HandleCompleted(bool saved)
        {
            FormState = FormState.None;
            if (saved)
                await Table.ReloadServerData();
        }
    }
    enum FormState { None, Create, Edit }
}
