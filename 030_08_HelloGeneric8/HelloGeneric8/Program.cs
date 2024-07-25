using System;

// LINQ
namespace HelloGeneric8 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 泛型委托: Action，只能引用没有返回值的方法 
            Action<string> a1 = Say;
            a1.Invoke("Timothy");
            a1("Timothy");
            Action<int> a2 = Mul;
            a2.Invoke(1);
            a2(1);
            Console.WriteLine("----------------------------");


            // 泛型委托: Func，只能引用有返回值的方法 
            // 最后一个泛型参数：是引用方法的返回值类型
            Func<int, int, int> func1 = Add;
            var result1 = func1(100, 200);
            Console.WriteLine($"result1 = {result1}");

            Func<double, double, double> func2 = Add;
            var result2 = func2(100.1, 200.2);
            Console.WriteLine($"result2 = {result2}");
            Console.WriteLine("----------------------------");


            Console.WriteLine("泛型委托 与 lambda 表达式一起使用");
            // Func<double, double, double> func3 = (double a, double b) => { return a + b; };
            // Func<double, double, double> func3 = (a, b) => { return a + b; };
            Func<double, double, double> func3 = (a, b) => a + b;
            var result3 = func3(100.1, 200.2);
            Console.WriteLine($"result3 = {result3}");
            Console.WriteLine("----------------------------");
        }

        static void Say(string str)
        {
            Console.WriteLine($"Hello, {str}!");
        }

        static void Mul(int x)
        {
            Console.WriteLine(x * 100);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Add(double a, double b)
        {
            return a + b;
        }
    }
}