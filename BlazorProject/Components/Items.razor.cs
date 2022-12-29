using BlazorProject.Models;
using BlazorProject.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorProject.Components
{
    public partial class Items
    {
        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        string Text { get; set; }

        [Parameter]
        public List<Item> ListItems { get; set; }

        [Parameter]
        public List<Item> ItemsTrouve { get; set; }

        private void search()
        {
            string mot = Text;
            ItemsTrouve = ListItems.Where(item => item.Name.Contains(mot) || item.DisplayName.Contains(mot)).ToList();
        }
    }
}
