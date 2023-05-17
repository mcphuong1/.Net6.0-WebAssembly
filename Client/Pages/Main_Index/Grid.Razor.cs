using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using Tesing2.Client.Pages.Main_Index.Add;
using Tesing2.Client.Pages.Main_Index.Delete;
using Tesing2.Client.Pages.Main_Index.Edit;
using Tesing2.Shared;

namespace Tesing2.Client.Pages.Main_Index
{
    public partial class Grid
    {
		private bool _dense = true;
		private bool _striped = true;
		[Parameter] public HocSinh item { get; set; }
		[Parameter] public int id { get; set; }
		public List<HocSinh> hocsinhs = new List<HocSinh>();
		protected override async Task OnInitializedAsync()
		{
			hocsinhs = await Client.GetFromJsonAsync<List<HocSinh>>("api/HocSinh");
		}

		private void AddDialog()
		{
			var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };
			DialogService.Show<AddDialog_Grid>("Add Dialog", options);
		}

		private void DeleteDialog(HocSinh item)
		{
			var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };
			var parameters = new DialogParameters { ["item"] = item };
			DialogService.Show<DeleteDialog_Grid>("Delete Dialog", parameters, options);
		}

		private void EditDialog(HocSinh item)
		{
			var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };
			var parameters = new DialogParameters { ["item"] = item };
			DialogService.Show<EditDialog_Grid>("Edit Dialog", parameters, options);
		}
	}
}
