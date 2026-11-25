using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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
        //TODO Este context trabaja como una lista que es basicamente la lista de la base de datos
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
        public async Task<ResponseDto<EmployeeOneDto>> GetOneById(Guid Id)//TODO siempre se debe mapear la entidad al dto o viceversa
        {
            var entity = await _context.Employees.FirstOrDefaultAsync(e => e.id == Id);

            if(entity == null)
            {
                return new ResponseDto<EmployeeOneDto>
                {
                  StatusCode = HttpStatusCode.NotFound,
                  Status = false,
                  Message =   ResponseMessageConstant.NotFound,
                };
            }


            return new ResponseDto<EmployeeOneDto>
            {
                 StatusCode = HttpStatusCode.Ok,
                 Status = true,
                 Message = ResponseMessageConstant.Ok,
                 Data = new EmployeeOneDto
                 {
                     id = entity.id,
                     FirstName = entity.FirstName,
                     LastName = entity.LastName,
                     DNI = entity.DNI,
                     Gender = entity.Gender
                 }
            };

        }

        public async Task<ResponseDto<EmployeeActionResponseDto>> CreateAsync(EmployeeCreateDto dto)
        {
            // TODO Metodos asincronos, programacion asincrona
            //TODO Este codigo se puede usar como base es decir es protable debido a que no hay ningun string ni valor exacto a en el.
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
                StatusCode = HttpStatusCode.Created,
                Status = true,
                //Message = $"{ResponseMessageConstant.Created}".Replace("@Entidad", "empleado"),//string mágico forma de hacerlo
                Message = ResponseMessageConstant.Created,
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