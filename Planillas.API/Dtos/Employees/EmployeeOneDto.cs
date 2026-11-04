using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planillas.API.Dtos.Employees
{
    public class EmployeeOneDto
    {
         public Guid id { get; set; } 
         public string? FirstName {get; set;}

         public string? FullName { get ; set; }

        public string? LastName {get => $"{}{FirstName} {LastName}";}} 

        public string? DNI { get; set; }
        public string? Gender { get; set; }

        //Esto es para la interfaz de usuario asi si modifico aca no modifica la base principal
    }
}