using System.ComponentModel.DataAnnotations;

namespace Assisgment.Model
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }

        public Coach Coach { get; set; }
        public int CoachId { get; set; }
        public List<Player> Players { get; set; }
        public List<Competition> Competitions { get; set; }
    }
}
