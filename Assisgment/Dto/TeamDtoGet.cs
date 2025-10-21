using System.ComponentModel.DataAnnotations;

namespace Assisgment.Dto
{
    public class TeamDtoGet
    {

        public int Id { get; set; }
  
        public string Name { get; set; }
        public string City { get; set; }

    }
    public class TeamDtoAdd
    {
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        [Required]
        public int CouchId { get; set; }
    }
    public class TeamDtoGetAll
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public int PlayerCount { get; set; }
    }
}
