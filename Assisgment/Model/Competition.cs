using System.ComponentModel.DataAnnotations;

namespace Assisgment.Model
{
    public class Competition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Tiitle { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public List<Team> Teams { get; set; }
    }
}
