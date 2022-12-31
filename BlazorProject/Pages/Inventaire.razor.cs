using Blazorise.DataGrid;
using BlazorProject.Models;
using BlazorProject.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace BlazorProject.Pages
{
    public partial class Inventaire
    {
        [Inject]
        public IStringLocalizer<Inventaire> Localizer { get; set; }
        [Inject]
        public IDataService DataService { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRenderAsync(firstRender);

            if (!firstRender)
            {
                return;
            }

            Items = await DataService.List(0, await DataService.Count());

            StateHasChanged();
        }


    }
}
