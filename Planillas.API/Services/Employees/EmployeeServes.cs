using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Planillas.API.Constants;
using Planillas.API.Database;
using Planillas.API.Dtos;
using Planillas.API.Dtos.Common;
using Planillas.API.Dtos.Employees;
using Planillas.API.Entities;
using Planillas.API.Mappers;

namespace Planillas.API.Services.Employees
{
    public class EmployeeServes : IEmployeeService
    {
        //TODO Este context trabaja como una lista que es basicamente la lista de la base de datos
        private readonly PlanillasDbContext _context;//esta es la instancia el _es para sabar que es una variable de clase
        //o tambien variable global

        private readonly int PAGE_SIZE;
        private readonly int PAGE_SIZE_TYPE;



        public EmployeeServes(PlanillasDbContext context, IConfiguration configuration)//ctor método constructor
        {
            _context = context;//this hace alucion a la variable global;
            PAGE_SIZE = configuration.GetValue<int>("PageSize");//viene de mi appsettings
            PAGE_SIZE_TYPE = configuration.GetValue<int>("PageSizeLimit");
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
                 StatusCode = HttpStatusCode.Found,
                 Status = true,
                 Message = ResponseMessageConstant.Found,
                 Data = EmployeeMapper.EntityToOneDto(entity)

                 //Este se utilizaba por petición del ingeniero:
                 //Message = ResponseMessageConstant.Ok,
                 //StatusCode = HttpStatusCode.Ok,
            };

        }

        public async Task<ResponseDto<EmployeeActionResponseDto>> CreateAsync(EmployeeCreateDto dto)
        {
            // TODO Métodos asíncronos, programación asíncrona
            //TODO Este código se puede usar como base es decir es portable debido a que no hay ningún string ni valor exacto a en el.
            var entity = EmployeeMapper.CreateOneDtoToEntity(dto);

            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();

            return new ResponseDto<EmployeeActionResponseDto>
            {
                StatusCode = HttpStatusCode.Created,
                Status = true,
                //Message = $"{ResponseMessageConstant.Created}".Replace("@Entidad", "empleado"),//string mágico forma de hacerlo
                Message = ResponseMessageConstant.Created,
                Data = EmployeeMapper.EntityToActionResponse(entity)
            };
        }
        
        public async Task<ResponseDto<EmployeeActionResponseDto>> EditAsync(Guid id, EmployeeEditDto dto)
        {
            var entity = await _context.Employees.FirstOrDefaultAsync(e => e.id == id);
            
            if(entity == null)
            {
                return new ResponseDto<EmployeeActionResponseDto>
                {
                  StatusCode = HttpStatusCode.NotFound,
                  Status = false,
                  Message =   ResponseMessageConstant.NotFound,
                };
            }
            
            var entityToUpdate = EmployeeMapper.EditDtoToEntity(dto, entity);
            _context.Employees.Update(entityToUpdate);
            await _context.SaveChangesAsync();

            return new ResponseDto<EmployeeActionResponseDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = ResponseMessageConstant.Ok,
                Data = EmployeeMapper.EntityToActionResponse(entityToUpdate)
            };


        }

        public async Task<ResponseDto<EmployeeActionResponseDto>> DeleteAsync(Guid Id)
        {
            var entity = await _context.Employees.FirstOrDefaultAsync(e => e.id == Id);

            if(entity == null)
            {
                return new ResponseDto<EmployeeActionResponseDto>
                {
                  StatusCode = HttpStatusCode.NotFound,
                  Status = false,
                  Message =   ResponseMessageConstant.NotFound,
                };
            }

            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();

            return new ResponseDto<EmployeeActionResponseDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = ResponseMessageConstant.Ok,
                Data = EmployeeMapper.EntityToActionResponse(entity)
            };
        }
        //Esta prohibido devolver la entidad en un api, se debe devolver un dto, para no exponer la entidad y que se pueda modificar       
    }
}