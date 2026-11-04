using Planillas.API.Entities;

namespace Planillas.API.Services.Employees
{
    public class EmployeeServes : IEmployeeService
    {
        public EmployeeEntity GetOneEmployee(int Id)
        {
            throw new NotImplementedException();
            //Esta prohibido devolver la entidad en un api, se debe devolver un dto, para no exponer la entidad y que se pueda modificar
        } 
    }
}