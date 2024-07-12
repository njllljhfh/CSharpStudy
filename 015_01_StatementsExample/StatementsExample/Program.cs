using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace StatementsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 块语句：编译器把块语句当做一条语句来看待，无论块语句里有多少子语句
            {
                int x = 100;
                if (x > 80) Console.WriteLine(x);
            }
            Console.WriteLine("----------------------------");


            int score = 100;
            //int y2 = 10;
            switch (score / 10)  // switch 语句的 () 里面的表达式的类型：整数、布尔、字符、字符串、枚举、可空类型。 现在的版本支持 double 了
            {
                //case y2: // 编译器报错
                case 10:  // case 后的表达式 必须是 常量表达式
                    if (score == 100)
                    {
                        goto case 8;
                    }
                    else
                    {
                        goto default;
                    }
                case 8:
                case 9:
                    Console.WriteLine("A");  // 8,9  都是 A
                    break;
                case 6:  // 一个单独的标签
                case 7:  // 一个标签后面 有语句，它就变成了一个 section, 就必须显示的写 break
                    Console.WriteLine("B");
                    break;
                case 5:
                case 4:
                    Console.WriteLine("C");
                    break;
                case 0:
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("D");
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
            Console.WriteLine("----------------------------");


            Level myLevel = Level.High;
            switch (myLevel)
            {
                case Level.High:
                    Console.WriteLine("High level!");
                    break;
                case Level.Mid:
                    Console.WriteLine("Mid level!");
                    break;
                case Level.Low:
                    Console.WriteLine("Low level!");
                    break;
                default:
                    break;
            }
            Console.WriteLine("----------------------------");


            Calculator c = new Calculator();
            int r = 0;
            try
            {
                r = c.Add("9999999999999999999999999999999", "200");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Main方法中捕获异常：{e.Message}");
            }
            Console.WriteLine(r);
            Console.WriteLine("----------------------------");
        }
    }

    enum Level
    {
        High,
        Mid,
        Low
    }

    class Calculator
    {
        public int Add(string arg1, string arg2)
        {
            int a = 0;
            int b = 0;
            bool hasError = false;
            try
            {
                a = int.Parse(arg1);
                b = int.Parse(arg2);
            }
            catch (ArgumentNullException e) // 可以没有 e
            {
                Console.WriteLine("Your argument(s) are null!");
                Console.WriteLine(e.Message);
                hasError = true;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Your argument(s) are not number!");
                Console.WriteLine(e.Message);
                hasError = true;
            }
            catch (OverflowException)
            {
                //Console.WriteLine("Out of range!");
                //Console.WriteLine(e.Message);
                hasError = true;
                //throw e;
                throw;  // 不用写 e 也能将异常抛出去
            }
            finally
            {
                // 用例1：释放资源，如关闭数据库连接

                // 用例2：记录log
                if (hasError)
                {
                    Console.WriteLine("Execution has error!");
                }
                else
                {
                    Console.WriteLine("Done!");
                }
            }

            int res = a + b;
            return res;
        }
    }
}
