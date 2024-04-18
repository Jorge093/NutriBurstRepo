using System.ComponentModel.DataAnnotations;

namespace NutriBurst.Web.Models.Entities
{
    public class PatientsNb
    {
        [Key]
        public Guid PatientsId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal BodyMassIndex { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }
}
