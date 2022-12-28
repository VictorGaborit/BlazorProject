using System.Text.Json.Serialization;

namespace BlazorProject.Models
{
    public abstract class Weaponry : Ressource
    {
        public int Durability { get; set; }
        public Material Material { get; set; }
        /*private List<Enchant> enchantableWith { get; set; }*/
        public List<string> RepairableWith { get; set; }
       
        [JsonConstructor]
        public Weaponry(int id, string name, string ressourceId, DateTime createdDate, DateTime updatedDate,
            int durability, Material material, List<string> repairableWith)
            : base(id, name, ressourceId, createdDate, updatedDate)
        {
            Durability = durability;
            Material = material;
            RepairableWith = repairableWith;
        }
    }
}
