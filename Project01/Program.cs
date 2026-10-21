using Project01.IntroductionToCsharp.Operators.Arithmetic;
using Project01.IntroductionToCsharp.Operators.Logic;
using Project01.IntroductionToCsharp.Variables;
using Project01.IntroductionToCsharp.ControlStructure;
<<<<<<< HEAD
using Project01.IntroductionToCsharp.ArraysLists;
=======
>>>>>>> 484b6f50d720b38f99040a56e1fcf96b7f5b0518

Numbers numbers = new Numbers();
//numbers.variables();
Strings strings = new Strings();
//strings.Variables();
Calculator calculadora = new Calculator();
// Console.WriteLine("La suma de 2+2 es: " + calculadora.Sum(2,2));
//Tarea Multiplicar restar dividir
// Console.WriteLine("La resta de 2 - 2 es: " + calculadora.Subtract(2,2));
// Console.WriteLine("La multiplicación de 2 * 2 es: " + calculadora.Multiply(2,2));
// Console.WriteLine("La división de 11 / 3 es: " + calculadora.Divide(11,3));
// Console.WriteLine("El valor de Pi es: "+ calculadora.Pi());
// Console.WriteLine("El residuo de 11 / 3 es: " + calculadora.Module(11,3));

// Compare compare = new Compare();
// // compare.Valid();
// compare.ValidInterpolation();

Conditional conditional = new Conditional();
//conditional.If();
// conditional.OperadorTernario();
// conditional.SwitchClassic();
//conditional.SwitchExpression();
Loops Loop = new Loops();
<<<<<<< HEAD
// //Loop.For();
// Console.WriteLine("Ingrese un número para multiplicar: ");
// // int n1 = int.Parse(Console.ReadLine()!);
// int n2 = int.TryParse(Console.ReadLine(), out n2) ? n2 : 0;//Se utiliza para que si el usuario usa algo invalido, se le asigne un valor de 0
//    Console.WriteLine("Ingrese un número limite:");
// int limit = int.TryParse(Console.ReadLine(), out limit) ? limit : 0;
//Loop.Multiply(n2);
// Loop.MultiplyLimit(n2,limit);
// Loop.ForDesc();
// Loop.While();
// Loop.WhileMultiply(n2);
// Loop.WhileMultiplyLimit(n2, limit);
// Loop.WhileDesc();
// Loop.ForEach();
// Loop.Pyramid();
LIsts list = new LIsts();
// list.Products();
list.ListadeCompras();
=======
//Loop.For();
Console.WriteLine("Ingrese un número para multiplicar: ");
// int n1 = int.Parse(Console.ReadLine()!);
int n2 = int.TryParse(Console.ReadLine(), out n2) ? n2 : 0;//Se utiliza para que si el usuario usa algo invalido, se le asigne un valor de 0
Loop.Multiply(n2);
>>>>>>> 484b6f50d720b38f99040a56e1fcf96b7f5b0518
