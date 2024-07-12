using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            C#的五大数据类型
            1.类（Class)：如Window，Form，Console，String
            2.结构体（Structure）：如int32，int64，Single，Double，bool
            3.枚举（Enumeration)：如HorizontalAlignment，Visibility
            4.接口（Interface）
            5.委托（Delegate)
            */

            //类类型
            //public class Form : ContainerControl
            Type myType = typeof(Form);
            Console.WriteLine(myType.FullName);
            Console.WriteLine(myType.IsClass);
            Console.WriteLine("--------------------------");

            //结构体类型
            //public struct Int32 : IComparable, IFormattable, IConvertible, IComparable<int>, IEquatable<int>
            int x1;  // F12进去看定义

            //public struct Int64 : IComparable, IFormattable, IConvertible, IComparable<long>, IEquatable<long>
            long x2;
            Console.WriteLine("--------------------------");

            //枚举类型
            Form f = new Form();
            //public enum FormWindowState
            //f.WindowState = FormWindowState.Maximized; // 枚举类型
            //f.ShowDialog();
            Console.WriteLine("--------------------------");

            /*
            Object类是他们的基类

            引用类型：类，接口，委托
            值类型：结构体，枚举
            */

            //null 一个引用变量不引用任何实例，用null
            //-------------------------------------------

            int x3;
            x3 = 100;
            short x4 = 200;
            x3 = x4; // short类型的值可以赋值给 int类型的变量
            //-------------------------------------------

            /*
             变量一共有7种：静态变量、实例变量（成员变量，也叫字段）、数组元素、值参数、引用参数、输出形参、局部变量
            */
            Console.WriteLine(Student.Amount);//静态变量

            Student stu = new Student();
            stu.Age = 18;  //实例变量
            Console.WriteLine(stu.Age);

            //数组元素
            int[] array = new int[100];
            array[0] = 3;
            Console.WriteLine(array[0]);

            //变量 = 以变量名所对应的内存地址为起点、以其数据类型所要求的存储空间为长度的一块内存区域
            //-------------------------------------------
            Console.WriteLine("值类型的变量---这里以结构体类型为例");
            byte b; // 1 字节
            b = 100;
            Console.WriteLine(b);

            sbyte sb; // 1 字节，s表示有符号
            sb = -100;
            Console.WriteLine(sb);

            ushort us; // 2 字节，无符号整型
            us = 1000;
            Console.WriteLine(us);

            short s; // 2 字节，有符号短整型
            s = -1000;
            Console.WriteLine(s);
            string str = Convert.ToString(s,2); // 按照二进制转化为字符串
            Console.WriteLine(str);
            Console.WriteLine("--------------------------");

            Console.WriteLine("引用类型的变量---这里以class类型为例");
            //引用类型变量与实例的关系：引用类型变量里存储的数据是对象的内存地址
            //局部变量是分配在栈上的
            Student2 stu2; // 此时在栈内存中分配了一个引用变量stu2（局部变量），该变量的值是null（指向null），因为还没有创建实例。
            stu2 = new Student2(); // 在堆上分配内存，创建实例对象
            Student2 stu3;
            stu3 = stu2; // stu3 和 stu2 引用的是同一个实例对象
            Console.WriteLine(stu3.ID); // 默认值是0
            Console.WriteLine(stu3.Score);
            Console.WriteLine("--------------------------");

            //int x5;
            //Console.WriteLine(x5);  //c#中，x5没有赋值前不能用

            // 常量（声明时就要初始化）
            const int x6 = 100; 
            //x6 = 200; // 常量不能赋值
            Console.WriteLine(x6);
            Console.WriteLine("--------------------------");

            Console.WriteLine("装箱 与 拆箱");
            // 装箱：把栈上的值类型的数据的值，封装成一个object类型的实例放在堆上。
            // 拆箱：把堆上面object类型的实例里面的值，转换成目标值类型，存储到栈上。
            // 装箱与拆箱会损失程序的性能。
            int x7 = 100;
            object obj = x7;  // 装箱（会把栈上的x7变量的值 100，复制到堆上。这是隐式类型转换）
            int y7 = (int)obj;  // 拆箱（把堆上的obj指向的内存地址保存的数据 100，赋值给栈上的变量y7。这是显示类型转换）
            Console.WriteLine(y7);
        }
    }

    class Student
    {
        //静态成员属于类
        public static int Amount;
        
        //实例变量
        public int Age;
        public string Name;

        //值参数 a, b
        public double Add(double a, double b)  // ref double a 引用参数变量；out double a 输出参数变量
        {
            // 局部变量
            double result = a + b;
            return result;   
        }
    }

    class Student2
    {
        public uint ID;
        public ushort Score;
    }
}
