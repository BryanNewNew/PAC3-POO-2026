using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Planillas.API.PracticasPersonales
{
    [ApiController]
    [Route("api/calculadora1.1")]
    public class CalculadoraConClaseGetSet : ControllerBase
    {
         [HttpPost]        
        public IActionResult Operaciones([FromBody] Calculadora calculadora)
        {
            int resultado = calculadora.Operacion switch
            {
                "+" => calculadora.a + calculadora.b,
                "-" => calculadora.a - calculadora.b,
                "*" => calculadora.a * calculadora.b,
                "/" => calculadora.a / calculadora.b,
                _ => 0
            };
           
            return Ok(new
            {
                A = calculadora.a,
                B = calculadora.b,
                Operacion = calculadora.Operacion,
                Resultado = resultado
            });

    }

    public class Calculadora
    {
        public int a { get; set; }
        public int b { get; set; }

        public string? Operacion { get; set; }
    }
}
}