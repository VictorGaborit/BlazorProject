using Blazorise.DataGrid;
using BlazorProject.Models;
using BlazorProject.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorProject.Pages
{
    public partial class NewInventory
    {
        string? TextValue { get; set; }
        
        bool haveAnyItem = true;
        
        private List<Item> itemsFound = new List<Item>();

        private List<Item> items;
        private List<Item> allItems;

        private int totalItem;

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
                allItems = await DataService.List(0, 100000000);
                totalItem = await DataService.Count();
            }
        }
        private void searching()
        {
            if (TextValue is null || TextValue.Length == 0)
            {
                itemsFound.Clear();
                itemsFound.AddRange(items);
                haveAnyItem = true;
            }
            else
            {
                itemsFound.Clear();
                foreach (var item in allItems)
                {
                    if ((item.Name.ToLower().Contains(TextValue.ToLower())) && !itemsFound.Contains(item))
                    {
                        if (item.Name.ToLower().Equals(TextValue.ToLower()))
                        {
                            itemsFound.Insert(0, item);
                        }
                        else
                        {
                            itemsFound.Add(item);
                        }
                            
                    }
                }
            }
            if(itemsFound.Count > 0)
            {
                haveAnyItem = true;
            }
            else
            {
                haveAnyItem = false;
            }
        }
    }
}
