using BlazorProject.Models;
using BlazorProject.Pages;
using BlazorProject.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BlazorProject.Components
{
    public partial class Items
    {
        [Inject]
        public IStringLocalizer<Inventaire> Localizer { get; set; }
        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        string Text { get; set; }

        [Parameter]
        public List<Item> ListItems { get; set; }

        List<Item> itemsTrouve = new List<Item>();
        bool haveAnyItem = true;

        private void searching()
        {
            if (Text is null || Text.Length == 0)
            {
                itemsTrouve.Clear();
                itemsTrouve.AddRange(ListItems);
                haveAnyItem = true;
            }
            else
            {
                itemsTrouve.Clear();
                foreach (var item in ListItems)
                {
                    if ((item.Name.ToLower().Contains(Text.ToLower())) && !itemsTrouve.Contains(item))
                    {
                        Console.WriteLine(item.Name);
                        if (item.Name.ToLower().Equals(Text.ToLower()))
                        {
                            itemsTrouve.Insert(0, item);
                        }
                        else
                        {
                            itemsTrouve.Add(item);
                        }

                    }
                }
            }
            if (itemsTrouve.Count > 0)
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
