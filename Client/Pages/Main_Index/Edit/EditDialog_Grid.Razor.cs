using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using Tesing2.Client.Pages.Main_Index.Confirm;
using Tesing2.Shared;

namespace Tesing2.Client.Pages.Main_Index.Edit
{
	public partial class EditDialog_Grid
	{
		[CascadingParameter] MudDialogInstance MudDialog { get; set; }

		[Parameter] public HocSinh item { get; set; }

		protected async Task Edit()
		{
			var response = await Http.PutAsJsonAsync($"api/hocsinh/{item.id}" , @item);
			bool editResponse = await response.Content.ReadFromJsonAsync<bool>();
			if (editResponse)
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
			if (!result.Cancelled && bool.TryParse(result.Data.ToString(), out bool resultbool)) Edit();
		}
	}
}
