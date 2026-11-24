using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planillas.API.Entities
{
    [Table("employees")]
    public class EmployeeEntity : BaseEntity
    {
        [Required]
        [Column("first_name")]
        public string? FirstName {get; set;}
        [Required]
        [Column("last_name")]
        public string? LastName {get; set;}

        // x = First name get
        // First name = "Juan" set
        //Con el get se pude modificar todo el objeto y con el set se puede utilizar para valorar una verificacion o validacion

        //formamasrapida con prop
        [Required]
        [Column("dni")]
        public string? DNI { get; set; }
        [Required]
        [Column("gender")]
        public string? Gender { get; set; }
    }
}