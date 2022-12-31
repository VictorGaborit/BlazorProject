using BlazorProject.Models;
using BlazorProject.Components;

namespace BlazorProject.Services
{
    public interface IDataService
    {
        Task Add(ItemModel model);

        Task<int> Count();

        Task<List<Item>> List(int currentPage, int pageSize);
    }
}
