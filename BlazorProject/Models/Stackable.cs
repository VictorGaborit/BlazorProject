using System.Text.Json.Serialization;

namespace BlazorProject.Models
{
    public abstract class Stackable : Ressource
    {
        public int StackSize { get; set; }
        public int StackMax { get; set; }

        [JsonConstructor]
        protected Stackable(int id, string name, string ressourceId, DateTime createdDate, DateTime updatedDate,
            int stackSize, int stackMax)
            : base(id, name, ressourceId, createdDate, updatedDate)
        {
            StackSize = stackSize;
            StackMax = stackMax;
        }
    }
}
