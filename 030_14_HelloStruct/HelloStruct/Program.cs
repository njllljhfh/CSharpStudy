using System.Xml.Serialization;

namespace HelloStruct
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // student 是局部变量（值类型），分配在 Main 函数的 函数栈上
            Student student = new Student() { ID = 101, Name = "Timtohy" };

            // 装箱：将 student 进行复制，放到堆空间。用 obj 这个变量 引用着 堆内存中的 student。
            object obj = student;

            // 拆箱：把 obj 指向的 堆上的 object类型的实例的值，转换成 Student类型（值类型），存储到栈上的 student2 变量中。
            Student student2 = (Student)obj;
            Console.WriteLine($"#{student2.ID} Name:{student2.Name}");
            // 装箱与拆箱会损失程序的性能。
            Console.WriteLine("----------------------------------");


            // 经典面试题
            Student stu1 = new Student() { ID = 101, Name = "Timothy" };
            // stu1是 值类型，在赋值给 stu2 时，stu1 在内存中会复制一份，然后赋值给 stu2 
            Student stu2 = stu1;
            // 此时，stu1 和 stu2 是两个不同的对象
            stu2.ID = 1001;
            stu2.Name = "Michael";
            Console.WriteLine($"#{stu1.ID} Name:{stu1.Name}"); // stu1 没有被改变
            Console.WriteLine($"#{stu2.ID} Name:{stu2.Name}");
            Console.WriteLine("----------------------------------");


            //结构体类型：可实现接口
            Student2 stu3 = new Student2() { ID = 1, Name = "Dragon" };
            stu3.Speak();
            Console.WriteLine("----------------------------------");


            //无参构造
            Student4 stu4 = new Student4();
            stu4.Speak();
            //有参构造
            Student4 stu5 = new Student4(5, "Dragon5");
            stu5.Speak();
            Console.WriteLine("----------------------------------");
        }
    }

    // 结构体类型：是 值类型，可装/拆箱
    struct Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    interface ISpeak
    {
        void Speak();
    }

    // 结构体类型：可实现接口
    struct Student2 : ISpeak
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine($"I'm #{this.ID} student {this.Name}");
        }
    }

    // 不能派生自类/结构体
    //struct Student3 : Student
    //{
    //}


    // 不能有显示的无参构造器？？？（现在的版本貌似可以了！ 2022 的 visual studio）
    struct Student4 : ISpeak
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // 无参构造器
        public Student4()
        {
            this.ID = 4;
            this.Name = "Dragon4";
        }

        // 无参构造器
        public Student4(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"I'm #{this.ID} student {this.Name}");
        }
    }
}