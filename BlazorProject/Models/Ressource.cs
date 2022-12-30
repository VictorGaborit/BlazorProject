using System.Text.Json.Serialization;

namespace BlazorProject.Models
{
    [Serializable]
    class Ressource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RessourceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
       
        [JsonConstructor]
        public Ressource(int id, string name, string ressourceId, DateTime createdDate, DateTime updatedDate)
        {
            Id = id;
            Name = name;
            RessourceId = ressourceId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }
    }
}
