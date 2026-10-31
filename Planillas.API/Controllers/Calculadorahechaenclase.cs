using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Planillas.API.Controllers
{
    public class Calculadorahechaenclase : ControllerBase
    {
        [HttpPost]
        public IActionResult Operations([FromBody] CalculatorMode1 calculatorMode1)
        {
            int result = calculatorMode1.Operator switch
            {
                "+" => calculatorMode1.N1 + calculatorMode1.N2,
                "-" => calculatorMode1.N1 - calculatorMode1.N2,
                "X" => calculatorMode1.N1 * calculatorMode1.N2,
                "/" => calculatorMode1.N1 / calculatorMode1.N2,
                _ => 0

            };
            return Ok(new 
            N1 = calculatorMode1.N1,
            N2 = calculatorMode1.N2,
            Operator = calculatorMode1.Operator
            Total = result 
            );
        }
    }

    public class CalculatorMode1 
    {
    public int N1 { get; set; }
    public int N2 { get; set; }
    public string? Operator { get; set; }

    
    }
}