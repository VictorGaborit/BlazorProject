using Blazorise.DataGrid;
using BlazorProject.Models;
using BlazorProject.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorProject.Pages
{
    public partial class NewInventory
    {
        string Text { get; set; }

        private List<Item> items;

        private int totalItem;

        [Parameter]
        public List<Item> ItemsTrouve { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        private async Task OnReadData(DataGridReadDataEventArgs<Item> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            if (!e.CancellationToken.IsCancellationRequested)
            {
                items = await DataService.List(e.Page, e.PageSize);
                totalItem = await DataService.Count();
            }
        }
        private void search()
        {
            string mot = Text;
            ItemsTrouve = items.Where(item => item.Name.Contains(mot) || item.DisplayName.Contains(mot)).ToList();
        }
    }
}
