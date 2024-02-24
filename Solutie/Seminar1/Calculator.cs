using System;
using System.CodeDom;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Seminar1.Host
{
    public class Calculator
    {
        private double result = 0;
        public void Execute(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentNullException("Expression is null or contains only white spaces");

            if (!expression.Contains('+'))
                throw new ArgumentException("Expression does not contain an operator");

            var parts = expression.Split('+');

            if (parts.Length != 2)
                throw new ArgumentException("Expression is invalid");

            if (!double.TryParse(parts[0].Trim(), out var operand1))
                throw new ArgumentException("Operand 1 is invalid");

            if (!double.TryParse(parts[1].Trim(), out var operand2))
                throw new ArgumentException("Operand 2 is invalid");

            result = operand1 + operand2;
        }
        public void Multiplication(string expresion)
        {
            if (expresion == null)
                throw new ArgumentNullException("Expresia este nula");
            if (!expresion.Contains("*"))
                throw new ArgumentException($"{expresion} does not exist");
            var parts = expresion.Split('*');
            if (parts.Length != 2)
                throw new Exception("Mai multe *");
            if (!double.TryParse(parts[0].Trim(), out var operand1))
                throw new ArgumentException("Operand 1 is not valid");
            if (!double.TryParse(parts[1].Trim(), out var operand2))
                throw new ArgumentException("Operand 2 is not valid");
            result = operand1 * operand2;
        }
        public void Divide(string expresion)
        {
            if (expresion == null)
                throw new ArgumentNullException("Expresia este nula");
            if (!expresion.Contains("/"))
                throw new ArgumentException($"{expresion} does not exist");
            var parts = expresion.Split('/');
            if (parts.Length != 2)
                throw new Exception("Mai multe /");
            if (!double.TryParse(parts[0].Trim(), out var operand1))
                throw new ArgumentException("Operand 1 is not valid");
            if (!double.TryParse(parts[1].Trim(), out var operand2))
                throw new ArgumentException("Operand 2 is not valid");
            if (operand2 == 0)
                throw new DivideByZeroException("NaN");
            var resultString = String.Format("{0:0.00}", operand1 / operand2);
            result = Double.Parse(resultString);

        }
        public void DisplayTheResult()
        {
            Console.WriteLine("Rezultatul este:" + result);
        }
    }
    public class Student
    {
        private readonly int id = 12;
        private String nume = "";
        private int varsta;
        public Student(int id, String nume, int varsta)
        {
            this.id = id;
            this.nume = nume;
            this.varsta = varsta;
        }
        public String Nume { get { return this.nume; } set { this.nume = value; } }
        public int Varsta { get { return this.varsta; } set { this.varsta = value; } }
        public override String ToString()
        {
            String student = id + " " + nume + " " + varsta;
            return student;
        }
    }
    public interface ISalariat
    {
        void CeFaceUnSalariat();
    }
    [Serializable]
    public class Salariat : ISalariat
    {
        private StringBuilder nume = null;
        private Decimal salariul = 12.34m;
        public Salariat(Decimal salariul, StringBuilder nume)
        {
            this.nume = new StringBuilder();
            this.nume.Insert(0, nume);
            this.nume.Insert(++this.nume.Length, " Muieee");
            this.salariul = salariul;
        }
        public override String ToString()
        {
            return "Nume " + nume + "\nSalariul " + salariul;
        }
        public void CeFaceUnSalariat()
        {
            Console.WriteLine("face bine");
        }

        public void Serializare(BufferedStream line)
        {
        }
    }
    public class SalariatSpecial : Salariat
    {
        Int16 salariuExtensiv = 0;
        public SalariatSpecial(Int16 salariuExtensiv, Decimal salariul, StringBuilder nume) : base(salariul, nume)
        {
            this.salariuExtensiv = salariuExtensiv;
        }
        public override String ToString()
        {
            String salariatSpecial = base.ToString() + "\nSalariul Extensiv " + salariuExtensiv;
            return salariatSpecial;
        }
    }
}
