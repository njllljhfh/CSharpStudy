using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("传值参数 --> 值类型");
            Student stu = new Student();
            int y = 100;
            stu.AddOne(y);
            Console.WriteLine($"y = {y}");
            Console.WriteLine("------------------------------------");


            Console.WriteLine("传值参数 --> 引用类型 --- 函数内部赋值新对象");
            Student stu2 = new Student() { Name = "Tim" };
            SomeMethod(stu2);
            Console.WriteLine($"stu2.Name = {stu2.Name}");
            Console.WriteLine($"{stu2.GetHashCode()}, {stu2.Name}");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("传值参数 --> 引用类型 --- 函数内部不赋值新对象");
            // 修改了函数外的 stu2 的 Name
            UpdateObject(stu2);
            Console.WriteLine($"stu2 --- {stu2.GetHashCode()}, Name={stu2.Name}");
            Console.WriteLine("------------------------------------");


            Console.WriteLine("引用参数 --> 值类型");
            int y2 = 1;
            IWantSideEffect(ref y2);  // 必须写ref，否则编译器报错
            Console.WriteLine($"y2 = {y2}");
            Console.WriteLine("------------------------------------");


            Console.WriteLine("引用参数 --> 引用类型 --- 函数内部赋值新对象");
            Student2 outterStu = new Student2() { Name = "Tim2" };
            Console.WriteLine($"outterStu --- {outterStu.GetHashCode()}, Name={outterStu.Name}, 函数外");
            Console.WriteLine("----------");
            IWantSideEffect2(ref outterStu);
            Console.WriteLine($"outterStu --- {outterStu.GetHashCode()}, Name={outterStu.Name}, 函数外");
            Console.WriteLine("------------------------------------");

            Console.WriteLine("引用参数 --> 引用类型 --- 函数内部不赋值新对象");
            // SomeSideEffect 函数 内的 stu 与函数外的 outterStu2，他们的内存地址相同（即函数内部没有对stu的实参进行拷贝）
            // 只有一个小孩牵着气球，这个小孩有两个名字，一个叫 outterStu2，另一个叫stu。函数外面用outterStu2，函数内部用stu。
            // 可以理解为 stu 是 outterStu2 的别名，他们共用相同的内存地址，此内存地址保存的值是 Student2类的一个实例对象的内存地址。
            Student2 outterStu2 = new Student2() { Name = "Tim3" };
            Console.WriteLine($"outterStu2 --- {outterStu2.GetHashCode()}, Name={outterStu2.Name}, 函数外");
            Console.WriteLine("----------");
            SomeSideEffect(ref outterStu2);
            Console.WriteLine($"outterStu2 --- {outterStu2.GetHashCode()}, Name={outterStu2.Name}, 函数外");
            Console.WriteLine("------------------------------------");


            /*
                用 out 修饰符 声明的形参是输出形参。输出形参不创建新的存储位置。
                变量在可以作为输出的形参传递之前不一定需要明确赋值。
                在方法返回之前，该方法的每个输出形参都必须明确赋值。
            */
            Console.WriteLine("输出参数 --> 值类型");
            string arg1 = "123";
            //string arg1 = "asd";
            double x = 0;
            bool b1 = double.TryParse(arg1, out x);  // x 是输出参数
            if (b1 == false)
            {
                Console.WriteLine("Input error!");
            }
            else
            {
                Console.WriteLine($"x = {x}");
            }
            Console.WriteLine("-------");
            // 自定义带有 out 参数的函数
            double x2 = 0;
            bool b2 = DoubleParse.TryParse("789", out x2);
            //bool b2 = DoubleParse.TryParse("asd",out x2);
            if (b2 == false)
            {
                Console.WriteLine("Input error!");
            }
            else
            {
                Console.WriteLine($"x2 = {x2}");
            }
            Console.WriteLine("------------------------------------");


            Console.WriteLine("输出参数 --> 引用类型");
            Student3 stu3 = null;
            bool b3 = Student3Factory.Create("Tim3", 34, out stu3);
            if (b3 == true)
            {
                Console.WriteLine($"姓名：{stu3.Name}, 年龄：{stu3.Age}");
            }
            else
            {
                Console.WriteLine("Input error!");
            }
            Console.WriteLine("------------------------------------");


            //Console.WriteLine("断两个字符串是否引用相同的内存地址，可以使用 Object.ReferenceEquals 方法");
            //string str1 = "Hello";
            //string str2 = "Hello";
            //string str3 = new string("Hello".ToCharArray());
            //// 比较 str1 和 str2 的引用
            //bool areSameReference1 = Object.ReferenceEquals(str1, str2);
            //Console.WriteLine($"str1 和 str2 引用相同的内存地址: {areSameReference1}");
            //// 比较 str1 和 str3 的引用
            //bool areSameReference2 = Object.ReferenceEquals(str1, str3);
            //Console.WriteLine($"str1 和 str3 引用相同的内存地址: {areSameReference2}");
            //Console.WriteLine("------------------------------------");
        }


        // 传值参数 --> 引用类型
        static void SomeMethod(Student stu)
        {
            // stu 指向了 新的 名字为 Tom 的对象 
            // 这种操作只是为了教学，在实际工作中没有什么意义。
            stu = new Student() { Name = "Tim" };
            Console.WriteLine($"stu.Name = {stu.Name}");
            // 无论什么数据类型都具有 GetHashCode 方法，调用后获取到的是该对象的 hashcode，该值是唯一的，每个对象都是不一样的。
            // 有点类似于 python 中的 id() 这个方法。
            Console.WriteLine($"{stu.GetHashCode()}, {stu.Name}");
        }


        // 传值参数 --> 引用类型
        static void UpdateObject(Student stu)
        {
            // stu 拷贝了外部引用变量保存的内存地址
            // 引用参数，修改了函数外部的对象
            stu.Name = "TTT";  // 副作用，side-effect。 尽量避免，为什么？？？
            Console.WriteLine($"stu  --- {stu.GetHashCode()}, Name={stu.Name}");
        }


        // 引用参数 --> 值类型
        // ref 修饰符，传递引用。方法内部的 x 与方法外部的变量 指向内存的同一个地址。
        // 使用 ref 修饰符显示指出 --- 此方法的副作用是改变实际参数的值。
        static void IWantSideEffect(ref int x)
        {
            x = x + 100;
        }


        //引用参数 --> 引用类型
        //引用参数不创建变量的副本
        //内部引用变量的重新赋值 改变了 外部引用变量指向的对象（外部和内部都指向了新的对象）
        static void IWantSideEffect2(ref Student2 stu)
        {
            stu = new Student2() { Name = "Tom2" };
            Console.WriteLine($"stu       --- {stu.GetHashCode()}, Name={stu.Name}, 函数内");
        }


        //引用参数 --> 引用类型
        static void SomeSideEffect(ref Student2 stu)
        {
            stu.Name = "Tom3";
            Console.WriteLine($"stu        --- {stu.GetHashCode()}, Name={stu.Name}, 函数内");
        }
    }


    class Student
    {
        // 传值参数 --> 值类型
        public void AddOne(int x)
        {
            x = x + 1;
            Console.WriteLine($"x = {x}");
        }

        // 简化声明的属性
        public string Name { get; set; }
    }


    class Student2
    {
        public string Name { get; set; }
    }


    class DoubleParse
    {
        //输出参数 --> 值类型
        public static bool TryParse(string input, out double result)
        {
            try
            {
                result = double.Parse(input);
                return true;
            }
            catch (Exception)
            {
                result = 0;
                return false;
            }
        }
    }


    class Student3
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    class Student3Factory
    {
        // 输出参数 --> 引用类型
        public static bool Create(string stuName, int stuAge, out Student3 result)
        {
            result = null;
            if (string.IsNullOrEmpty(stuName))
            {
                return false;
            }

            if (stuAge < 20 || stuAge > 80)
            {
                return false;
            }

            result = new Student3() { Name = stuName, Age = stuAge };
            return true;
        }
    }
}
