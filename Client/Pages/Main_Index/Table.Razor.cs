using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using Tesing2.Client.Pages.Main_Index.Add;
using Tesing2.Client.Pages.Main_Index.Delete;
using Tesing2.Client.Pages.Main_Index.Edit;
using Tesing2.Shared;

namespace Tesing2.Client.Pages.Main_Index
{
    public partial class Table
    {
		private bool enabled = true;
		private bool dense = true;
		private string searchString1 = "";


		[Parameter]
		public string? id { get; set; }
		public List<HocSinh> hocsinhs = new List<HocSinh>();

		private HashSet<HocSinh> selectedItems = new HashSet<HocSinh>();

		protected override async Task OnInitializedAsync()
		{
			hocsinhs = await Client.GetFromJsonAsync<List<HocSinh>>("api/HocSinh");
		}

		private bool FilterFunc1(HocSinh timkiem) => FilterFunc(timkiem, searchString1);

		private bool FilterFunc(HocSinh timkiem, string searchString)
		{
			if (string.IsNullOrWhiteSpace(searchString))
				return true;
			if (timkiem.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
			if ($"{timkiem.id} {timkiem.Name} {timkiem.Class}".Contains(searchString))
				return true;
			return false;
		}

		private bool striped = true;

		private void DeleteDialog(HocSinh item)
		{
			var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };
			var parameters = new DialogParameters { ["item"] = item };
			DialogService.Show<DeleteDialog_Table>("Delete Dialog", parameters, options);
		}

		private void AddDialog()
		{
			var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };
			DialogService.Show<AddDialog_Table>("Add Dialog", options);
		}
		private void EditDialog(int id )
		{
			var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };
			var parameters = new DialogParameters { ["id"] = id };
			DialogService.Show<EditDialogTable>("Edit Dialog", parameters, options);
		}
	}

}
