namespace Planillas.API.Dtos.Employees
{
    public class EmployeeDto
    {
        //Listado de campos que se van a mostrar en la interfaz de usuario
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? DNI { get; set; }
        public string? Gender { get; set; }
    }
}