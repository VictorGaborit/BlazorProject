﻿using BlazorProject.Models;
using BlazorProject.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorProject.Pages
{
    public partial class Inventaire
    {
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
