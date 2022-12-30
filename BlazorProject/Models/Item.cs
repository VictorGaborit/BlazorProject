using System.Text.Json.Serialization;

namespace BlazorProject.Models
{
    class Item : Stackable
    {
        [JsonConstructor]
        public Item(int id, string name, string ressourceId, DateTime createdDate, DateTime updatedDate,
            int stackSize, int stackMax)
            : base(id, name, ressourceId, createdDate, updatedDate, stackSize, stackMax)
        {
        }
    }
}
