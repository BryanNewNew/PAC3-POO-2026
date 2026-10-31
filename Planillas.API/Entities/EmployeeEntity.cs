namespace Planillas.API.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        public string? FirstName {get; set;}

        public string? LastName {get; set;}

        // x = First name get
        // First name = "Juan" set
        //Con el get se pude modificar todo el objeto y con el set se puede utilizar para valorar una verificacion o validacion

        //formamasrapida con prop
        public string? DNI { get; set; }
        public string? Gender { get; set; }
    }
}