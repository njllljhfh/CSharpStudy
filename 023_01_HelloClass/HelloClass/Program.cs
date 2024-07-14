using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            默认构造器
                - 编译器自动生成
                - 不接受任何参数
                - 作用：把所有的字段都设为默认值。
            */
            //Student stu = new Student();
            //---------------------------------


            //Student stu = new Student() { ID = 1, Name = "Timothy" };
            //Console.WriteLine(stu.ID);
            //Console.WriteLine(stu.Name);
            //stu.Report();
            //---------------------------------


            //Student stu2 = new Student(2, "Timothy2");
            //Console.WriteLine(stu2.ID);
            //Console.WriteLine(stu2.Name);
            //stu2.Report();
            //Console.WriteLine("----------------------------------");
        

            Type t = typeof(Student);
            // Activator.CreateInstance() 创建的类型 都是 object 类型
            object o = Activator.CreateInstance(t, 3, "Timothy3");
            Console.WriteLine($"o.GetType().Name = {o.GetType().Name}");
            Console.WriteLine($"o is Student = {o is Student}");
            Student stu3 = o as Student;
            Console.WriteLine($"stu3.ID = {stu3.ID}");
            Console.WriteLine($"stu3.Name = {stu3.Name}");
            Console.WriteLine("----------------------------------");


            Type t2 = typeof(Student);
            dynamic stu4 = Activator.CreateInstance(t2, 4, "Timothy4");
            Console.WriteLine($"stu4.Name = {stu4.Name}");  // 这里敲代码时，Name是没有提示的。
            Console.WriteLine("----------------------------------");


            Console.WriteLine($"Student.Amount = {Student.Amount}");
            Console.WriteLine("----------------------------------");


        } // 程序执行到这个右括号时，我们的程序就要结束了。stu2 没有人引用了，被gc回收，stu2析构器被调用。
    }


    class Student
    {
        // 学生总数（静态成员）
        public static int Amount { get; set; }

        // 静态构造器：可以初始化静态成员
        static Student()
        {
            Amount = 100;
        }

        /*
        自定义 实例构造器
            - 一旦我们写了自定义构造器，编译器就不自动生成默认构造器了。
        */
        public Student(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            // 每创建一个学生，学生总数 +1
            Amount++;
        }

        //析构器，当对象被gc回收时，会调用
        ~Student()
        {
            //Console.WriteLine("Bye bye! Release the system resources ...");
            // 实例被回收时，学生总数 -1
            Amount--;
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public void Report()
        {
            Console.WriteLine($"I'm {ID} student, my name is {Name}");
        }
    }
}
