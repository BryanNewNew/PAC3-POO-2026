using Planillas.API.Dtos;
using Planillas.API.Dtos.Common;
using Planillas.API.Dtos.Employees;
using Planillas.API.Entities;

namespace Planillas.API.Services.Employees
{
    public interface IEmployeeService
    {
        //Definir contratos de servicios para empleados va conectada a la capa de datos y a la capa de controladores
        ResponseDto<PageDto<List<EmployeeDto>>> GetPage(string searchTerm = "", int page = 1, int pageSize = 10); // Esto llevara ciertos cambios
        ResponseDto<EmployeeOneDto> GetOneById(Guid Id);
        //No va lógica si se puede no es recomendable
        //Actualmente es sin base de datos
        ResponseDto<EmployeeActionResponseDto> Create(EmployeeCreateDto dto);
        ResponseDto<EmployeeActionResponseDto> Edit(Guid id, EmployeeEditDto dto);
        ResponseDto<EmployeeActionResponseDto> Delete(Guid Id);



    }
}