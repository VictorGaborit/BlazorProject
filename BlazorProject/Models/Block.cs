using System.Text.Json.Serialization;

namespace BlazorProject.Models
{
    [Serializable]
    class Block : Stackable
    {
        public double Hardness { get; set; }
       
        [JsonConstructor]
        public Block(int id, string name, string ressourceId, DateTime createdDate, DateTime updatedDate,
            int stackSize, int stackMax, double harness)
            : base(id, name, ressourceId, createdDate, updatedDate, stackSize, stackMax)
        {
            Hardness = harness;
        }
    }
}
