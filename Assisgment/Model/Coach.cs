using System.ComponentModel.DataAnnotations;

namespace Assisgment.Model
{
    public class Coach
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Specilzation { get; set; }
        [Required]
        public int ExperinceYears { get; set; }
       
        public Team Team { get; set; }
    }
}
