using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using Tesing2.Shared;
using System.Net.Http.Json;
using Tesing2.Client;
using Tesing2.Client.Pages.Main_Index.Confirm;

namespace Tesing2.Client.Pages.Main_Index.Delete
{
	public partial class DeleteDialog_Grid
	{
		[CascadingParameter] MudDialogInstance MudDialog { get; set; }

		[Parameter] public HocSinh item { get; set; }

		protected async Task Delete()
		{
			var response = await Http.DeleteAsync("api/hocsinh/" + item.id);
			bool deleteResponse = await response.Content.ReadFromJsonAsync<bool>();
			if (deleteResponse)
			{
                NavigationManager.NavigateTo("/");
                Snackbar.Add("Okela!", Severity.Success);
                NavigationManager.NavigateTo("grid");
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
			if (!result.Cancelled && bool.TryParse(result.Data.ToString(), out bool resultbool)) Delete();
		}
	}
}
