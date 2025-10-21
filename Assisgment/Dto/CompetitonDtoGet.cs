using System.ComponentModel.DataAnnotations;

namespace Assisgment.Dto
{
    public class CompetitonDtoGet
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Tiitle { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public List<TeamDtoGet> teams {  get; set; } 
        public int TotalnumberOfPlayersInTeam { get; set; }
    }
}
