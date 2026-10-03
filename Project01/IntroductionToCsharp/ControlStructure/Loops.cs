using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.IntroductionToCsharp.ControlStructure
{
    public class Loops
    {
        public void For()
       { 
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Iteración: {i}");
            }
        }

        public void Multiply(int number)
        {
            for (int j = 1; j <= 12; j++)
            {
                Console.WriteLine($"{j} X {number} = {j * number}");
            }
        }
    }
}

//Tarea crear de que en la clase que salga que si se pone una letra y el caracter se hace 0 qe salga un texto de opcion invalida