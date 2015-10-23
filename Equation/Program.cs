using System;

namespace Equation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter maximum delta");
            int maxDelta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter maximum h");
            int maxH = int.Parse(Console.ReadLine());

            Coefficients eq = new Coefficients(maxDelta, maxH);
            eq.Input();
            Console.WriteLine(eq);
            eq.Solve();
            Console.WriteLine(eq);
            Console.ReadKey();
        }
    }
}
