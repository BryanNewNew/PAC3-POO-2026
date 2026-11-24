using Microsoft.AspNetCore.Mvc;
using Planillas.API.Dtos;
using Planillas.API.Dtos.Common;
using Planillas.API.Dtos.Employees;
using Planillas.API.Entities;
using Planillas.API.Services.Employees;

namespace Planillas.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase 
    {
        
        //cualquier metodo
        //Metodo constructor tiene que llamarse exactamente igual que la clase

        //Solo define la variable sin iniciarlizarla y al inicializarla despues no se podra modificar
       //_variable Es una variable global el guion bajo es para saber que es una variable que se podrá utilizar en cualquier metodo de la clase
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;//auntomaticamente crea la instancia
        }
         //El metodo contructor se ejecuta en el NEW
        //Ciclofor ciclofor = NEW Ciclofor();
        [HttpGet]
        public ActionResult<ResponseDto<PageDto<List<EmployeeDto>>>> GetAll(string searchTerm = "", int page = 1, int pageSize = 10)
        {
            var response = _employeeService.GetPage(searchTerm, page, pageSize);
            //El  
            return StatusCode(response.StatusCode, new ResponseDto<PageDto<List<EmployeeDto>>>//Darle los datos de ResponseDto
            {
                Status = response.Status,
                Message = response.Message,
                Data = response.Data
            });
            
            //Esto es incorrecto solo devolver lo necesario
            //El ok puede devolver lo que sea
        }

        [HttpGet("{id}")]
        public ActionResult<ResponseDto<EmployeeOneDto>> GetOneById(Guid id)
        {
            var response = _employeeService.GetOneById(id);
            return StatusCode(response.StatusCode, new ResponseDto<EmployeeOneDto>
            {
                Status = response.Status,
                Message = response.Message,
                Data = response.Data
            });


            // EmployeeEntity emp = new EmployeeEntity();

            // foreach(var employee in _employees)
            // {
            //     if(employee.DNI != null && employee.DNI.Equals(dni))
            //     {
            //         emp = employee;   
            //     }
            // }

        

            //return Ok(_employees.FirstOrDefault(e => e.DNI == dni));//Usar expresion lamda el parentesis)
        }

        [HttpPost]

        public async Task<ActionResult<ResponseDto<EmployeeActionResponseDto>>> Post([FromBody] EmployeeCreateDto dto)//se debe convertir a metodo asincrono
        {
            var response = await _employeeService.CreateAsync(dto);//se debe poner await cuando se llame a una funcion asincrona

            return StatusCode(response.StatusCode, new ResponseDto<EmployeeActionResponseDto>
            {
                Status = response.Status,
                Message = response.Message,
                Data = response.Data
            });
        }

        [HttpPut("{id}")]

        public ActionResult<ResponseDto<EmployeeActionResponseDto>> Put(Guid id, [FromBody] EmployeeEditDto dto)
        {
           var response = _employeeService.Edit(id, dto);


            return StatusCode(response.StatusCode, new ResponseDto<EmployeeActionResponseDto>
            {
                Status = response.Status,
                Message = response.Message,
                Data = response.Data
            });
        }

        [HttpDelete("{id}")]
        
        public ActionResult<ResponseDto<EmployeeActionResponseDto>> Delete(Guid id)
        {
           var response = _employeeService.Delete(id);

           return StatusCode(response.StatusCode, new ResponseDto<EmployeeActionResponseDto>
            {
                Status = response.Status,
                Message = response.Message,
                Data = response.Data
            });
        

        }
    }
}