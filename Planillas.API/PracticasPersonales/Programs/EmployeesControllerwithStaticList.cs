using Microsoft.AspNetCore.Mvc;
using Planillas.API.Entities;

//Este utiliza los controladores y entidades hechas en clase

namespace Planillas.API.Controllers 
{
    [Route("api/employees1.1")]
    [ApiController]
    public class EmployeesControllerstatic : ControllerBase
    {
        //Solo define la variable sin iniciarlizarla y al inicializarla despues no se podra modificar
        private static List <EmployeeEntity> _employees = new List<EmployeeEntity>
        {
            new EmployeeEntity{ id = 1, FirstName = "Juan", LastName = "Perez", DNI="0401-2000-00001", Gender = "M"},
            new EmployeeEntity{ id = 2, FirstName = "Maria", LastName = "Rodriguez", DNI="0401-2000-00002", Gender = "F"},
        };
            //Es una variable global el guion bajo es para saber que es una variable que se podrá utilizar en
                                                //cualquier metodo
        //Metodo constructor tiene que llamarse exactamente igual que la clase
        public EmployeesControllerstatic()
        {
            //IMPORTANTE NO SE USA EL METODO CONSTRUCTOR DEBIDO A QUE SIEMPRE REINICIARLA LA LISTA
        }
         //El metodo contructor se ejecuta en el NEW
        //Ciclofor ciclofor = NEW Ciclofor();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employees);
            //Este ok puede devolver lo que sea
        }

        [HttpGet("{dni}")]
        public IActionResult GetOne(string dni)
        {
            // EmployeeEntity emp = new EmployeeEntity();

            // foreach(var employee in _employees)
            // {
            //     if(employee.DNI != null && employee.DNI.Equals(dni))
            //     {
            //         emp = employee;   
            //     }
            // }

        

            return Ok(_employees.FirstOrDefault(e => e.DNI == dni));//Usar expresion landa el parentesis)
        }

        [HttpPost]

        public IActionResult Post([FromBody] EmployeeEntity employee)
        {
            _employees.Add(employee);

            return Ok(new {id = employee.id});
        }

        [HttpPut("{dni}")]

        public IActionResult Put(string dni, [FromBody] EmployeeEntity employee)
        {
            var oldEmployee = _employees.FirstOrDefault(e => e.DNI == dni);

            if(oldEmployee != null)
            {
                _employees.Remove(oldEmployee);
                _employees.Add(employee);
            }

            return Ok(_employees);
        }

        [HttpDelete("{dni}")]
        
        public IActionResult Delete(string dni)
        {
            var oldEmployee = _employees.FirstOrDefault(e => e.DNI == dni);

            if(oldEmployee != null)
            {
            _employees.Remove(oldEmployee);   
            }
            
            return Ok(_employees);

        }
    }
}