using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 自动获取变量的类型
            var x1 = 3;
            Console.WriteLine(x1.GetType().Name);

            var x2 = 3L;
            Console.WriteLine(x2.GetType().Name);

            var x3 = 3.0;  // 浮点型，默认是 double 类型的（工作中一般用double）
            Console.WriteLine(x3.GetType().Name);

            var x4 = 3.0F; // 单精度浮点型
            Console.WriteLine(x4.GetType().Name);
            Console.WriteLine("---------------------------------");


            int x5; // 声明变量
            x5 = 100;
            Console.WriteLine(x5);
            Console.WriteLine("---------------------------------");


            Calculator c = new Calculator();
            int x6 = c.Add(2, 3);
            Console.WriteLine(x6);

            string x7 = c.Today();   
            Console.WriteLine(x7);

            c.PringSum(4, 6);
            Console.WriteLine("---------------------------------");

            c.PrintXTo1(10);
            Console.WriteLine("---------------------------------");

            c.PrintXTo1Recursion(10);
            Console.WriteLine("---------------------------------");

            int x8 = c.SumFrom1ToX(100);
            Console.WriteLine(x8);
            Console.WriteLine("---------------------------------");

            int x9 = c.SumFrom1ToXRecursion(3);
            Console.WriteLine(x9);
        }
    }

    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public string Today()
        {
            int day = DateTime.Now.Day; // 几号
            return day.ToString();
        }

        // 无返回值的方法
        public void PringSum(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);
        }

        // 循环 打印 0 ~ x
        public void PrintXTo1(int x)
        {
            for (int i = x; i >0 ; i--)
            {
                Console.WriteLine(i);
            }
        }

        // 递归 打印 0 ~ x
        public void PrintXTo1Recursion(int x)
        {
            if (x < 1) {
                return;
            }
            Console.WriteLine(x);
            PrintXTo1Recursion(x - 1);
        }


        // 循环 1~x 的和
        public int SumFrom1ToX(int x) 
        { 
            int result = 0;
            for (int i = x; i >0 ;i--)
            {
                result += i;
            }
            return result;  
        }

        // 递归 1~x 的和
        public int SumFrom1ToXRecursion(int x)
        {
            if (x == 1)
            {
                return 1;
            } else
            {
                return x + SumFrom1ToXRecursion(x - 1);
            }
        }
    }
}
