using System.ComponentModel.DataAnnotations;

namespace Assisgment.Dto
{
    public class PlayerDtoUpdate
    {
        [Required]
        public string Position { get; set; }
    }
    public class PlayerDtoGet
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        
    }
    public class PlayerDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
    }
    
}
