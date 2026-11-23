using Planillas.API.Dtos;
using Planillas.API.Dtos.Common;
using Planillas.API.Dtos.Employees;
using Planillas.API.Entities;

namespace Planillas.API.Services.Employees
{
    public class EmployeeServes : IEmployeeService
    {
         public ResponseDto<PageDto<List<EmployeeDto>>> GetPage()
        {
            throw new NotImplementedException();
        }
        public ResponseDto<EmployeeOneDto> GetOneById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ResponseDto<EmployeeActionResponseDto> Create(EmployeeCreateDto dto)
        {
            throw new NotImplementedException();
        }
        
        public ResponseDto<EmployeeActionResponseDto> Edit(Guid id, EmployeeEditDto dto)
        {
            throw new NotImplementedException();
        }

        public ResponseDto<EmployeeActionResponseDto> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
        //Esta prohibido devolver la entidad en un api, se debe devolver un dto, para no exponer la entidad y que se pueda modificar       
    }
}