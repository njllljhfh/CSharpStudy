using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperatorsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            sizeof
                - 默认情况下，sizeof只能用于获取基本数据类型（c#关键字里的那些类型，除了string和object，因为sizeof只能获取结构体类型的实例在内存中的大小）的实例在内存中占用的内存。
                - 在非默认的情况下，可以使用sizeof获取自定义的结构体类型的实例在内存中占用的字节数，但是需要把它放在不安全的上下文中。
            */

            Console.WriteLine("默认情况下，使用 sizeof");
            int x = sizeof(int);
            Console.WriteLine(x);
            x = sizeof(long);
            Console.WriteLine(x);
            x = sizeof(ulong);
            Console.WriteLine(x);
            x = sizeof(double);
            Console.WriteLine(x);
            x = sizeof(decimal);  // decimal 比 double 更精确
            Console.WriteLine(x);  // 16
            Console.WriteLine("-------------------------------");


            Console.WriteLine("非默认情况下，使用 sizeof");
            unsafe // 打开菜单栏-->项目-->属性-->勾选 允许不安全代码
            {
                int x2 = sizeof(Student);
                Console.WriteLine(x2);
            }
            Console.WriteLine("-------------------------------");


            Console.WriteLine("-> 操作符");
            // -> 操作符：要放在 不安全的上下文中使用
            // c#这中这些指针的操作，只能用于操作结构体类型，不能操作引用类型
            // 这种用法工作中很少用，只做了解。
            unsafe 
            {
                Student stu;
                stu.ID = 1;
                stu.Score = 99;
                Student* pStu = &stu;  // 指针
                pStu->Score = 100;
                Console.WriteLine(stu.Score);

                // *pStu：通过指针获取实例
                (*pStu).Score = 1000;
                Console.WriteLine(stu.Score);
            }
            Console.WriteLine("-------------------------------");

            /*
            计算机中求一个数的相反数：按位取反，再加1
            */
            Console.WriteLine("~：按位取反");
            int x3 = 12345678;
            int y3 = ~x3;
            Console.WriteLine(x3);
            Console.WriteLine(y3); // -12345679
            string xStr = Convert.ToString(x3, 2).PadLeft(32, '0'); // 二进制，32为，左侧补0
            string yStr = Convert.ToString(y3, 2).PadLeft(32, '0');
            Console.WriteLine(xStr);
            Console.WriteLine(yStr);
            Console.WriteLine("-------------------------------");


            // 有符号的最小值 取相反数 会溢出
            int x4 = int.MinValue;
            int y4 = -x4;
            Console.WriteLine($"x4 = {x4}");
            Console.WriteLine($"y4 = {y4}");
            string x4Str = Convert.ToString(x4,2).PadLeft(32, '0');
            Console.WriteLine($"x4 的二进制：{x4Str}");  // 10000000000000000000000000000000
            Console.WriteLine("-------------------------------");


            Console.WriteLine("!：非运算符，只能操作bool类型的值");
            //Student2 stu2 = new Student2(null);
            //Console.WriteLine(stu2.Name);  // 这里抛出了异常
            Console.WriteLine("-------------------------------");


            Console.WriteLine("++x,--x: 前置的自增与自减");
            int x5 = 100;
            int y5 = ++x5; // 先 x5 += 1, 然后 y5 = x5
            Console.WriteLine(x5);
            Console.WriteLine(y5);
        }
    }

    struct Student
    {
        public int ID;
        public long Score;
    }

    class Student2
    {
        public Student2(string initName)
        {
            if (!string.IsNullOrEmpty(initName))
            {
                this.Name = initName;
            }
            else
            {
                throw new ArgumentException("initName cannot be null or empty.");
            }
        }

        public string Name;
    }
}
