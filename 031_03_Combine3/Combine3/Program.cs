using System;

namespace Combine3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
            Lambda 的作用
                1. 匿名方法
                2. Inline 方法   
            */
            // Lambda 表达式：(int a, int b) => { return a + b; 
            Func<int, int, int> func = new Func<int, int, int>((int a, int b) => { return a + b; });
            int res = func(100, 200);
            Console.WriteLine($"res = {res}");

            // 省略入参类型
            func = new Func<int, int, int>((x, y) => { return x * y; });
            res = func(3, 4);
            Console.WriteLine($"res = {res}");

            // 省略 new 创建委托的代码，直接将一个Lambda表达式 赋值 给 一个委托类型的变量
            func = (x, y) => { return x * y; };
            res = func(3, 4);
            Console.WriteLine($"res = {res}");

            // 省略 函数体的花括号 和 return 
            func = (x, y) => x * y;
            res = func(3, 4);
            Console.WriteLine($"res = {res}");
            Console.WriteLine("-------------------------------------");


            Console.WriteLine("泛型委托作为函数的参数");
            // 这里的 int 没有高亮，说明可以省略掉<int>
            // 最后两个参数 是 int类型，所以 编译器 能推断出来 T 的类型 是 int（这是 泛型委托的参数类型推断）。
            DoSomeCalc<int>((a, b) => { return a * b; }, 100, 200);
            DoSomeCalc((a, b) => { return a * b; }, 100, 200);
            Console.WriteLine("-------------------------------------");


            // 以上的各种省略，是 C# 中的 语法糖
        }


        // 泛型委托作为函数的参数
        static void DoSomeCalc<T>(Func<T, T, T> func, T x, T y)
        {
            T res = func(x, y);
            Console.WriteLine($"res = {res}");
        }
    }
}