using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using SolutionExplorer.KMS.SharedUI.Dtos;
using SolutionExplorer.KMS.SharedUI.Dtos.PersonnelDtos;
using SolutionExplorer.KMS.SharedUI.Dtos.UserDtos;
using SolutionExplorer.KMS.SharedUI.Services.Interfaces;

namespace SolutionExplorer.KMS.SharedUI.Pages.PersonnelComponents
{
    public partial class PersonnelList : ComponentBase
    {
        [Inject] IHttpService Http { get; set; }
        [Inject] IJSRuntime JS { get; set; }

        FormState FormState = FormState.None;

        int? SelectedId = null;
        PersonnelSearchDto SearchModel = new();
        MudTable<PersonnelDisplayDto> Table;

        List<KeyValuePair<int, string>> UsersKeyValue = new();

        protected override async Task OnInitializedAsync()
        {
            var result = await Http.GetByFilterAsync<UserSearchDto,
                ApiResult<List<KeyValuePair<int, string>>>>(
                "api/User/GetByFilterForDropDown", new());

            UsersKeyValue = result?.Data ?? new();
        }

        async Task<TableData<PersonnelDisplayDto>> LoadServerData(TableState state, CancellationToken token)
        {
            SearchModel.CalculateTakeAndSkip(state.Page, state.PageSize);

            var result = await Http.GetByFilterAsync<PersonnelSearchDto,
                ApiResult<BaseGridDto<PersonnelDisplayDto>>>(
                "api/Personnel/GetByFilter", SearchModel);

            return new()
            {
                Items = result?.Data?.Data ?? Enumerable.Empty<PersonnelDisplayDto>(),
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

        async Task HandleCompleted(bool saved)
        {
            FormState = FormState.None;
            if (saved)
                await Table.ReloadServerData();
        }
    }
    enum FormState { None, Create, Edit }

}
