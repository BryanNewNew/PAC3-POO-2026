using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Planillas.API.Controllers
{
    [Route("api/calculadora")]
    [ApiController]


    public class Calculdora : ControllerBase
    {
    //crear un controlador endpoint puede ser calculadora

    [HttpPost]
    public  menu =  ("MENU DE OPERACIONES \n 1.Sumar \n2.Restar \n3.Multiplicar \n4Dividir");
    public IActionResult GetAll()
        {
           return Ok();
        }
    [HttpGet("{sumar}")]
    
    public IActionResult Sumar([FromQuery] double a, [FromQuery] double b)
        {
            double sumar = a + b;
            return Ok(sumar);
            //Este ok puede devolver lo que sea
        }

         [HttpGet("{restar}")]
    public IActionResult Restar([FromQuery] double a, [FromQuery] double b)
        {
            double sumar = a - b;
            return Ok(sumar);
            //Este ok puede devolver lo que sea
        }
    }

   
}