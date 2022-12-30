using System.Text.Json.Serialization;

namespace BlazorProject.Models
{
    class Weapon : Weaponry
    {
        public WeaponType WeaponType { get; set; }
        
        [JsonConstructor]
        public Weapon(int id, string name, string ressourceId, DateTime createdDate, DateTime updatedDate,
            int durability, Material material, List<string> repairableWith, WeaponType weaponType)
            : base(id, name, ressourceId, createdDate, updatedDate, durability, material, repairableWith)
        {
            WeaponType = weaponType;
        }
    }
}
