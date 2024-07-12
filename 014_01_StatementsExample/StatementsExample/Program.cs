using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StatementsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入考试分数：");
            string input = Console.ReadLine();
            try
            {
                double score = double.Parse(input);
                if (score >= 60)
                {
                    Console.WriteLine("Pass!");
                }
                else
                {
                    Console.WriteLine("Failed!");
                }
            }
            catch
            {
                Console.WriteLine("Not a number!");
            }
            Console.WriteLine("--------------------------");

            int x0 = 100; // 声明变量并且初始化

            // var 第一次给变量赋值时，编译器自动推断，确定变量 x 的数据类型。
            var x = 100;
            Console.WriteLine(x.GetType().FullName);
            Console.WriteLine("--------------------------");


            // 一组变量声明
            int x2, y2, z2;
            x2 = 100;  // 变量赋值操作
            y2 = 100;
            z2 = x2 + y2;
            Console.WriteLine("--------------------------");


            // 数组初始化器
            int[] myArray = { 1, 2, 3 };  // 数组的长度是3
            Console.WriteLine("--------------------------");


            // 常量
            const int x3 = 100;  // 常量在声明的同时必须初始化！！！
            Console.WriteLine("--------------------------");


            int x4 = 100;
            Console.WriteLine(x4++); // x4++ 表达式是有值的，值就是 x4 的值 100
            Console.WriteLine("--------------------------");

        }
    }
}
