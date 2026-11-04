using Planillas.API.Entities;

namespace Planillas.API.Services.Employees
{
    public interface IEmployeeService
    {
        //Definir conractos de servicios para empleados va conectada a la capa de datos y a la capa de controladores

        EmployeeEntity GetOneEmployee(int employeeId);
        //No va logica si se puede no es recomendable

    }
}