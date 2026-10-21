using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Linq.Expressions;
=======
>>>>>>> 484b6f50d720b38f99040a56e1fcf96b7f5b0518
using System.Threading.Tasks;

namespace Project01.IntroductionToCsharp.ControlStructure
{
    public class Loops
    {
<<<<<<< HEAD
        public void WhilePyramid()
        {
            int n =5;
            int i =1; 
            while (n >= i)
            {
                while(i >= 5)
                {
                    Console.Write("");
                    i--;
                }
            }
        }
       public void Pyramid()
        {
            int n = 15;


            for(int i = 1; i<=n; i++)
            {
                 if(i >= 10)
                    {
                        Console.Write("  ");
                    }
                for(int k = 1; k<=n-i; k++)
                {
                        Console.WriteLine(" ");
                    
                }
                for(int j =1; j<=i; j++)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
        }

        public void ForEach()
        {
             string[] products = {"Laptop", "Mouse", "Keyboard", "Monitor"};
            // for(int i = 0; i<=3; i++)
            // {
            //     Console.WriteLine("Producto: " + products[i]);
            // }
            foreach(string product in products)
            {
                Console.WriteLine("Producto: " + product);
            }
        }
        
=======
>>>>>>> 484b6f50d720b38f99040a56e1fcf96b7f5b0518
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
<<<<<<< HEAD

    public void MultiplyLimit(int number, int limit)
        {

               if(number <= 0)
            {
                return;
            }


             for (int j = 1; j <= limit; j++)
            {
                Console.WriteLine($"{j} X {number} = {j * number}");
            }

        }

        public void ForDesc()
        {
              for (int j = 1; j <= 5; j++)
            {
                Console.WriteLine($"Iteración: {j}");
            }

        }

        public void While()
        {
            int i = 1;
            while (i <= 5)
            {
                Console.WriteLine($"Iteración: {i}");
                i++;
            }
        }

        public void WhileMultiply(int number)
        {
            int i =1;
            while (i <= 12)
            {
                Console.WriteLine($"{i} X {number} = {i * number}");
                i++;
            }
        }

        public void WhileMultiplyLimit(int number, int Limit)
        {
            int i = 1;
            while (i <= Limit)
            {
                Console.WriteLine($" {number} X {i} = {i * number}");
                i++;
            }
            
        }

        public void WhileDesc()

        {
            int i = 1;
            while (i <=5)
            {
                Console.WriteLine($"Iteración: {i}");
                i++;
            }
        }
    }

}

//Tarea crear de que en la clase que salga que si se pone una letra y el carácter se hace 0 qe salga un texto de opción invalida

=======
    }
}

//Tarea crear de que en la clase que salga que si se pone una letra y el caracter se hace 0 qe salga un texto de opcion invalida
>>>>>>> 484b6f50d720b38f99040a56e1fcf96b7f5b0518
