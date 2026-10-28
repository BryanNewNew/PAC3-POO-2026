using Microsoft.AspNetCore.Mvc;

namespace Planillas.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //Solo define la variable sin iniciarlizarla y al inicializarla despues no se podra modificar
        private readonly List <string> _employees;//Es una variable global el guion bajo es para saber que es una variable que se podrá utilizar en
                                                //cualquier metodo
        //Metodo constructor tiene que llamarse exactamente igual que la clase
        public EmployeesController()
        {
            _employees = new List<string>();
            _employees.Add("JuanPerez");
            _employees.Add("Maria Mejia");
            _employees.Add("Karla Lopez");

        }
         //El metodo contructor se ejecuta en el NEW
        //Ciclofor ciclofor = NEW Ciclofor();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employees);
            //Este ok puede devolver lo que sea
        }
    }
}