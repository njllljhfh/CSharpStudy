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
            Console.WriteLine("new 操作符");
            // new 在内存中创建一个类型的实例，并调用类型的实例构造器
            new Form();
            // new 在创建完实例后，还可以调用该实例的 初始化器（后边的 {} ）
            Form myForm2 = new Form() { Text = "Hello", FormBorderStyle=FormBorderStyle.FixedToolWindow};
            //myForm2.ShowDialog();
            //----------

            //new Form() { Text="Hello"}.ShowDialog(); // 这个Form实例，用了一次，过一会就被 GC 回收了
            //----------

            // c# 语言 的 语法糖衣
            string name = "Tim"; // string 是类类型。c#将new隐藏起来了（因为string是很基础的类型，很常用，为了便于使用）。
            int[] myArray = new int[10]; // 数组类型
            int[] myArray2 = { 1, 2, 3, 4 };
            //----------

            
            Console.WriteLine("new 为匿名类型创建对象");
            var person = new { Name = "Mr.Okay", Age = 34 };  // 开头必须用 var 声明隐式类型的变量。这里new的是一个匿名类型，不知道类型名字没法显示声明变量的类型。
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
            Console.WriteLine(person.GetType().Name);  //<>f__AnonymousType0`2    其中0表示第一个实例；`2 表示这个类型是个泛型类，构成这个类型是需要2个类型其他类型（即 string 和 int）
            Console.WriteLine("---------------------------");

            Console.WriteLine("new 用作修饰符：\"隐藏\" 父类的相同方法（这种用法并不常用，此处只是了解下）。");
            Student stu = new Student();
            stu.Report();
            CsStudent csStu= new CsStudent();
            csStu.Report();
            Console.WriteLine("---------------------------");


            Console.WriteLine("checked、unchecked 操作符用法");
            //checked 告诉编译器检查是否溢出
            //unchecked 告诉编译器不用检查是否溢出
            uint x8 = uint.MaxValue;
            Console.WriteLine($"x8 = {x8}");
            string binStr = Convert.ToString(x8, 2); // 2进制
            Console.WriteLine($"binStr = {binStr}");
            uint y8 = x8 + 1;  // 默认的就是采用 unchecked 模式
            Console.WriteLine($"y8 = {y8}");  // 0

            try
            {
                uint y82 = checked(x8 + 1);
                //uint y82 = unchecked(x8 + 1); //unchecked 不用写，默认的就是采用 unchecked 模式
                Console.WriteLine($"y82 = {y82}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("y82 --- There's overflow!");
            }
            Console.WriteLine("---------------------------");



            Console.WriteLine("checked、unchecked 上下文用法");
            // 在这个 checked 语句块范围内，所有的溢出都会检测到
            checked 
            {
                try
                {
                    uint y83 = x8 + 1;
                    Console.WriteLine($"y83 = {y83}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("y83 --- There's overflow!");
                }
            }

            // 在这个 unchecked 语句块范围内，所有的溢出都不会被检测
            unchecked
            {
                try
                {
                    uint y84 = x8 + 1;
                    Console.WriteLine($"y84 = {y84}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("y84 --- There's overflow!");
                }
            }
            Console.WriteLine("---------------------------");
        }
    }

    class Student
    {
        public void Report()
        {
            Console.WriteLine("I'm a student.");
        }
    }

    //CsStudent 继承 Student
    class CsStudent : Student
    {
        // 此处的 new 是修饰符。"隐藏" 父类的相同方法（这种用法并不常用，此处只是了解下）。
        new public void Report()
        {
            Console.WriteLine("I'm a CS student.");
        }
    }
}
