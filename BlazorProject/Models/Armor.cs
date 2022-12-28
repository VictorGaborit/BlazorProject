using System.Text.Json.Serialization;

namespace BlazorProject.Models
{
    public class Armor : Weaponry
    {
        public ArmorPiece ArmorPiece { get; set; }

        [JsonConstructor]
        public Armor(int id, string name, string ressourceId, DateTime createdDate, DateTime updatedDate,
            int durability, Material material, List<string> repairableWith, ArmorPiece armorPiece)
            : base(id, name, ressourceId, createdDate, updatedDate, durability, material, repairableWith)
        {
            ArmorPiece = armorPiece;
        }
    }
}
