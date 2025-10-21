using System.ComponentModel.DataAnnotations;

namespace Assisgment.Dto
{
    public class CoachDtoGet
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Specilzation { get; set; }
 
        public int ExperinceYears { get; set; }
        public TeamDtoGet Team { get; set; }
    }
    public class CoachDtoGetByid
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Specilzation { get; set; }

        public int ExperinceYears { get; set; }
        public TeamDtoGet Team { get; set; }
        public int TotalPlayers { get; set; }
    }
}
