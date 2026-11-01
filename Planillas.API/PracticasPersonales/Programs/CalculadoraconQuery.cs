using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Planillas.API.PracticasPersonales
{
    [Route("api/calculadora1.2")]
    [ApiController]

    public class CalculadoraconQuery : ControllerBase
    {
        [HttpGet("sumar")]
    
    public IActionResult Sumar([FromQuery] double a, [FromQuery] double b)
        {
            double resultado = a + b;
            return Ok(new { Operacion = "Suma", A = a, B = b, Resultado = resultado });

            //Este ok puede devolver lo que sea
        }

        [HttpGet("restar")]
    public IActionResult Restar([FromQuery] double a, [FromQuery] double b)
        {
            double resultado = a - b;
            return Ok(new {Operacion = "Resta", A = a, B = b, Resultado = resultado});
            //Este ok puede devolver lo que sea
        }

        [HttpPost("multiplicar")]
        public IActionResult Multiplicar([FromQuery] double a, [FromQuery] double b)
        {
            double sumar = a * b;
            return Ok(sumar);

            //Este ok puede devolver lo que sea
        }

        [HttpGet("dividir")]
            public IActionResult Dividir([FromQuery] double a, [FromQuery] double b)
        {
            double sumar = a / b;
            return Ok(sumar);

            //Este ok puede devolver lo que sea
        }

    

   
    }
    }
