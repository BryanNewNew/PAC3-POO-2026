using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.IntroductionToCsharp.ArraysLists
{
    public class LIsts
    {
        public void Products()
        {
            List<string> products = new List<string>();

            products.Add("Semita");
            products.Add("Cafe");
            products.Add("Galletas");
            products.Insert(0, "Azúcar");
            products.Insert(2, "Chocolate");
            // products.Remove("Galletas");
            // products.RemoveAt(0);

            products.Sort();
            products.Reverse();
            products.Clear();


            foreach(var product in products)
            {
                Console.WriteLine($"Producto: {product}");
            }

            Console.WriteLine($"Total de productos: {products.Count} ");

        }

        public void ListadeCompras()
        {
            
            List<string> compras = new List<string>();
            int op;
            do{
            Console.Clear();
            Console.WriteLine("Bienvenido al menu de compras, seleccione una opción: ");
            Console.WriteLine("1. Agregar producto\n" +  "2. Ver Lista de compras\n" + "3. Eliminar producto\n" + "4. Salir");
            op = Convert.ToInt32(Console.ReadLine()?? "");
            switch(op)
            {
                case 1:
                Console.Clear();
                Console.WriteLine("Ingrese el producto a agregar: ");
                var producto = Console.ReadLine();
                compras.Add(producto?? "");
                break;
                case 2:
                Console.Clear();
                Console.WriteLine("Lista de compras: ");
                foreach(var productos in compras)
                        {
                            Console.WriteLine($"Producto: {productos}");
                        }
                break;
                case 3:
                Console.Clear();
                Console.WriteLine("Ingrese el numero del producto a eliminar: ");
                var productoEliminar =Console.ReadLine()?? "";
                if(compras.Contains(productoEliminar))
                        {
                            compras.Remove(productoEliminar);
                            Console.WriteLine("Producto eliminado.");
                            Console.WriteLine($"Total de productos: {compras.Count}");
                        }
                break;
                case 4: 
                Console.WriteLine("Saliendo del programa...");
                return;
                default:
                Console.WriteLine("Opción inválida, intente de nuevo.");
                break;

            }

            }while(op != 4);
          

            
        }



    }
}
