using Blazorise.DataGrid;
using BlazorProject.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorProject.Pages
{
    public partial class RessourcesList
    {
        private List<Ressource> lesRessources;

        private int nombreDeRessources;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async Task OnReadData(DataGridReadDataEventArgs<Ressource> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            var response = (await Http.GetFromJsonAsync<Item[]>($"{NavigationManager.BaseUri}fake-data.json")).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();

            if (!e.CancellationToken.IsCancellationRequested)
            {
                nombreDeRessources = (await Http.GetFromJsonAsync<List<Item>>($"{NavigationManager.BaseUri}fake-data.json")).Count;
                lesRessources = new List<Ressource>(response);
            }
        }
    }
}
