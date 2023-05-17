using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Tesing2.Client.Pages.Main_Index.Confirm
{
	public partial  class ConfirmDialog
	{
		[CascadingParameter] MudDialogInstance MudDialog { get; set; }

		[Parameter] public string ContentText { get; set; }

		[Parameter] public string ButtonText { get; set; }

		void Submit() => MudDialog.Close(DialogResult.Ok(true));
		void Cancel() => MudDialog.Cancel();
	}
}
