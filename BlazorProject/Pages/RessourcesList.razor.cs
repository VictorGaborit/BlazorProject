using Blazorise.DataGrid;
using BlazorProject.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorProject.Pages
{
    public partial class RessourcesList
    {
        private List<Ressource> toutesLesRessources;

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
            List<Ressource> toutesLesRessources = new List<Ressource>();

            var response = await Http.GetAsync($"{NavigationManager.BaseUri}fake-data.json");

            if (!e.CancellationToken.IsCancellationRequested)
            {
                using (Stream stream = await response.Content.ReadAsStreamAsync())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.TypeNameHandling = TypeNameHandling.Auto;
                        toutesLesRessources = (List<Ressource>)serializer.Deserialize(reader, typeof(List<Ressource>));
                        nombreDeRessources = toutesLesRessources.Count;
                    }
                }
            }
        }
    }
}
