using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.IntroductionToCsharp.ControlStructure
{
    public class Conditional
    {
        //if and else
        public void If()
        {
            int age = 20;
            if(age >= 18)
            {
                Console.WriteLine("Eres mayor de edad");
            }
            else
            {
                Console.WriteLine("No eres mayor de edad");
            }
        }
        //switch
        public void SwitchClassic()
        {
            int numberDay = 1;
            switch(numberDay)
        {      //op = Convert.ToInt32(Console.ReadLine());
                case 1:
                Console.WriteLine("Domingo");
                break;
                case 2:
                Console.WriteLine("Lunes");
                break;
                case 3:
                Console.WriteLine("Martes");
                break;
                case 4:
                Console.WriteLine("Miércoles");
                break;
                case 5:
                Console.WriteLine("Jueves");
                break;
                case 6:
                Console.WriteLine("Viernes");
                break;
                case 7:
                Console.WriteLine("Sábado");
                break;
                default:
                Console.WriteLine("Opción no válida");
                break;
        }
            }
        
        public void SwitchExpression()
        {
            int numberDay = 1;
            string day = numberDay switch
            {
                1 => "Domingo",
                2 => "Lunes",
                3 => "Martes",
                4 => "Miércoles",
                5 => "Jueves",
                6 => "Viernes",
                7 => "Sábado",
                _ => "Opción no válida"
            };
            Console.WriteLine(day);
        }
        

        //Operador ternario(condición if abreviada)
        public void OperadorTernario()
        {
            int age = 21;
            string message = (age > 18) ? "Eres mayor de edad" : "No eres mayor de edad ";
            Console.WriteLine(message);
        }


    }
}