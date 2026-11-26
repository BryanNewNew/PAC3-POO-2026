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
        private readonly int PAGE_SIZE_LIMIT;



        public EmployeeServes(PlanillasDbContext context, IConfiguration configuration)//ctor método constructor
        {
            _context = context;//*this hace alucion a la variable global;
            PAGE_SIZE = configuration.GetValue<int>("PageSize");//*viene de mi appsettings
            PAGE_SIZE_LIMIT = configuration.GetValue<int>("PageSizeLimit");
        }
         public async Task<ResponseDto<PageDto<List<EmployeeDto>>>> GetPageAsync(string searchTerm = "", int page = 1, int pageSize = 10)
        {
            page = Math.Abs(page);//*valor absoluto porque no existen paginas negativas
            pageSize = Math.Abs(pageSize);

            //Respetar Parámetros
            pageSize = pageSize <=0 ? PAGE_SIZE : pageSize;//método operador ternario
            pageSize = pageSize > PAGE_SIZE_LIMIT ? PAGE_SIZE_LIMIT : pageSize;

            //*Definir en que pagina nos encontramos y que elementos 
            int startIndex = (page-1)*pageSize;

            //*Obtener Datos, colocarle la entidad(Los datos importantes), cuando se coloca el {await} se realiza la consulta a la base de datos
            IQueryable<EmployeeEntity> employeeQuery = _context.Employees;

            if(!string.IsNullOrEmpty(searchTerm))
            {
                employeeQuery = employeeQuery
                .Where(e => ($"{e.FirstName} {e.LastName} {e.DNI} {e.Gender}")
                    .Contains(searchTerm));//*Recomendable cuando sean strings
            }

            //*Para calcular las paginas
            //*Para no traer toda la lista de la tabla en el API se hace un await
            //*CountAsync = hay unos query : 'select count(*) total from employees' esto hace la conexión a la base de datos y ejecuta la linea sin traer toda la información de la base de datos

            int totalItems = await employeeQuery.CountAsync();//**CountAsync devuelve solo el numero que hay lo que permite calcular el numero de paginas

            var employeesEntity = await employeeQuery
            .OrderBy(e => e.FirstName)//*Esto es para definir en que orden quedara 
            .Skip(startIndex)//*Pasar de pagina, automáticamente me hará el calculo de en que pagina estoy
            .Take(pageSize)//*Escoger el tamaño de pagina
            .ToListAsync();//*Que lo devuelva como una lista

            //*Preparar la respuesta de datos
            return new ResponseDto<PageDto<List<EmployeeDto>>>//Mapear
            {
                StatusCode = HttpStatusCode.Found,
                Status = true,
                Message = ResponseMessageConstant.Found,
                Data = new PageDto<List<EmployeeDto>>
                {
                    CurrentPage = page == 0 ? 1 : page,
                    SizePage = pageSize,
                    TotalItems = totalItems,
                                                   //*El resultado pasarlo a double para que el resultado de la operación de enteros lo pase a double para que lo pueda redondear
                    TotalPages = (int)Math.Ceiling((double)totalItems/pageSize),  //**Ceiling redondea hacia arriba forzosamente, Floor para redondear hacia abajo
                    HasNextPage = page < (int)Math.Ceiling((double)totalItems/pageSize) ? true : false,//*Habilita que haya siguiente pagina
                    HasPreviousPage = page > 1 ? true : false,
                    Items = EmployeeMapper.ListEntityToListDto(employeesEntity)
                } 
            };



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