using System;
using System.Runtime.CompilerServices;

namespace Combine2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDele<int> deleAdd = new MyDele<int>(Add);
            int res = deleAdd(100, 200);
            Console.WriteLine($"res = {res}");
            MyDele<double> deleMul = new MyDele<double>(Mul);
            double res2 = deleMul(3.0, 4.0);
            Console.WriteLine($"res2 = {res2}");
            Console.WriteLine("--------------------------------------");


            Console.WriteLine("查看 deleAdd 的类型，是不是 类类型");
            Console.WriteLine(deleAdd.GetType().IsClass);  // True
            Console.WriteLine("--------------------------------------");


            Console.WriteLine("Action 委托：接收无参数，也无返回值的方法");
            Action action = new Action(M1);
            action();
            Console.WriteLine("--------------------------------------");


            Console.WriteLine("泛型 Action 委托：接收无返回值的方法");
            Action<string> action2 = new Action<string>(SayHello);
            action2("Tim");
            Action<string, string> action3 = new Action<string, string>(SayHello2);
            action3("Tim2", "Tim3");
            Console.WriteLine("--------------------------------------");


            Console.WriteLine("泛型 Func 委托：接收有返回值的方法");
            Func<int, int, int> func = new Func<int, int, int>(Add);
            var res3 = Add(100, 200);
            Console.WriteLine($"res3 = {res3}");
            var func2 = new Func<double, double, double>(Mul);
            var res4 = func2(3.0, 4.0);
            Console.WriteLine($"res4 = {res4}");
            Console.WriteLine("--------------------------------------");
        }

        static void M1()
        {
            Console.WriteLine("M1 is called.");
        }

        static void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        static void SayHello2(string name1, string name2)
        {
            Console.WriteLine($"Hello, {name1} and {name2}!");
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static double Mul(double x, double y)
        {
            return x * y;
        }

        // 泛型委托
        delegate T MyDele<T>(T a, T b);
    }
}