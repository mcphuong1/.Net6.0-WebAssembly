using Tesing2.Shared;
using MudBlazor;
using System.Net.Http.Json;
using Tesing2.Client;
using Tesing2.Client.Pages.Main_Index.Confirm;
using Microsoft.AspNetCore.Components;

namespace Tesing2.Client.Pages.Main_Index.Add
{
    public partial class AddDialog_Table
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        HocSinh hs = new HocSinh();
        protected async Task Save()
        {
            var response = await Http.PostAsJsonAsync("api/HocSinh", @hs);
            HocSinh AddResponse = await response.Content.ReadFromJsonAsync<HocSinh>();
            if (AddResponse?.id > 0)
            {
                NavigationManager.NavigateTo("/");
                Snackbar.Add("Okela!", Severity.Success);
                NavigationManager.NavigateTo("table");
            }
        }
        void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task Confirm()
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you want to confirm?");
            parameters.Add("ButtonText", "Yes");
            var dialogresult = DialogService.Show<ConfirmDialog>("Confirm", parameters);
            var result = await dialogresult.Result;
            if (!result.Cancelled && bool.TryParse(result.Data.ToString(), out bool resultbool)) Save();
        }
    }
}
