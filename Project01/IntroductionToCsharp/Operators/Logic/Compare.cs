using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.IntroductionToCsharp.Operators.Logic
{
    public class Compare
    {
        private int x = 20;
        private int y = 25;

        private int z = 22;

        // public void Valid()
        // {
        //     Console.WriteLine("Es igual x y y: " + (x == y));
        //     Console.WriteLine("Es diferente x y y: " + (x != y));
        //     Console.WriteLine("Es mayor x y y: " + (x > y));
        //     Console.WriteLine("Es menor x y y: " + (x < y));
        //     Console.WriteLine("Es mayor o igual x y y: " + (x >= y));
        //     // AND y OR
        //     Console.WriteLine("Z es mayor que X y menor que Y: " + (z > x && z<y)); 
        //     Console.WriteLine("Z es menor que X o mayor que Y: " + (z < x || z>y)); 
            
        //     //Interpolación de strings
        //     Console.WriteLine($"El valor de {z} es mayor que {x} y menor que {y} :" + (z > x && z<y));
            
        // }


    //Crear un nuevo método llamado valid interpolation

    public void ValidInterpolation()
        {
            Console.WriteLine($"Es igual {x} y {y}: " + (x == y));
            Console.WriteLine($"Es diferente {x} y {y}: " + (x != y));
            Console.WriteLine($"Es mayor {x} y {y}: " + (x > y));
            Console.WriteLine($"Es menor {x} y {y}: " + (x < y));
            Console.WriteLine($"Es mayor o igual {x} y {y}: " + (x >= y));
            // AND y OR
            Console.WriteLine($"{z} es mayor que {x} y menor que {y}: " + (z > x && z<y)); 
            Console.WriteLine($"{z} es menor que {x} o mayor que {y}: " + (z < x || z>y)); 
            
            //Interpolación de strings
            Console.WriteLine($"El valor de {z} es mayor que {x} y menor que {y} :" + (z > x && z<y));
            
        }
    }
}