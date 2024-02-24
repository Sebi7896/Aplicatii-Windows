using System;
using System.Text;
namespace Seminar1.Host
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Student s = new Student(23, "Sebi", 21);
            Console.WriteLine(s);
            SalariatSpecial salariatSpecial = new SalariatSpecial(12, 12.4m, new StringBuilder("Eu"));
            Console.WriteLine(salariatSpecial);

            while (true)
            {
                var calculator = new Calculator();
                Console.Write("Expresie=");
                var expression = Console.ReadLine();

                try
                {

                    if (expression.Contains("+"))
                    {
                        Console.Write("Calculam cu + : ");
                        calculator.Execute(expression);
                        calculator.DisplayTheResult();
                    }

                    if (expression.Contains("*"))
                    {
                        Console.Write("Calculam cu * : ");
                        calculator.Multiplication(expression);
                        calculator.DisplayTheResult();
                    }
                    if (expression.Contains("/"))
                    {
                        Console.Write("Calculam cu / : ");
                        calculator.Divide(expression);
                        calculator.DisplayTheResult();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
