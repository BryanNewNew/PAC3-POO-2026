using Microsoft.AspNetCore.Http.HttpResults;
using Planillas.API.Constants;
using Planillas.API.Database;
using Planillas.API.Dtos;
using Planillas.API.Dtos.Common;
using Planillas.API.Dtos.Employees;
using Planillas.API.Entities;

namespace Planillas.API.Services.Employees
{
    public class EmployeeServes : IEmployeeService
    {
        private readonly PlanillasDbContext _context;//esta es la instancia el _es para sabar que es una variable de clase
        //o tambien variable global

        public EmployeeServes(PlanillasDbContext context)//ctor metodo constructor
        {
            _context = context;//this hace alucion a la variable globa;
        }
         public ResponseDto<PageDto<List<EmployeeDto>>> GetPage(string searchTerm = "", int page = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }
        public ResponseDto<EmployeeOneDto> GetOneById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<EmployeeActionResponseDto>> CreateAsync(EmployeeCreateDto dto)
        {
            // TODO Metodos asincronos, programacion asincrona
            var employee = new EmployeeEntity
            {
                id = Guid.NewGuid(),//se genera el guid
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DNI = dto.DNI,
                Gender = dto.Gender

            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return new ResponseDto<EmployeeActionResponseDto>
            {
                StatusCode = HttpStatusCode.Create,
                Status = true,
                Message = "El registro se ha creado exitosamente",
                Data = new EmployeeActionResponseDto
                {
                    Id = employee.id
                }
            };
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