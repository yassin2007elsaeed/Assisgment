using System.ComponentModel.DataAnnotations;

namespace Assisgment.Model
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
