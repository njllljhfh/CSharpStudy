using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("静态属性只读属性、静态构造器");
            Console.WriteLine($"Red = {Brush.DefaultColor.Red}");
            Console.WriteLine($"Green = {Brush.DefaultColor.Green}");
            Console.WriteLine($"Blue = {Brush.DefaultColor.Blue}");
            Console.WriteLine("--------------------------");

            Console.WriteLine("属性（property）--- 实例属性（表示的是某个实例的状态）");
            Student stu1 = new Student();
            stu1.Age = 20;
            //stu1.Id = 2;  // 编译器报错
            Console.WriteLine($"stu1.Id = {stu1.Id}");

            Student stu2 = new Student();
            stu1.Age = 20;

            Student stu3 = new Student();
            stu1.Age = 20;
            int avgAge = (stu1.Age + stu2.Age + stu3.Age) / 3;
            Console.WriteLine($"avgAge = {avgAge}");
            Console.WriteLine("--------------------------");


            Console.WriteLine("属性（property）--- 静态属性（表示的是某个class的状态）");
            Student.Amount = 100;
            Console.WriteLine($"Amount = {Student.Amount}");
            Console.WriteLine("--------------------------");


            Console.WriteLine("属性（property）--- 简略声明");
            Student2 stu4 = new Student2();
            stu4.Age = 20;
            //stu4.Id = 2;  // 编译器报错（只读属性，不能赋值）
            //stu4.Name = "stu4";  // 编译器报错（不能访问）
            stu4.SomeMethod();
            Console.WriteLine($"stu4.Age = {stu4.Age}");
            Console.WriteLine($"stu4.Id = {stu4.Id}");
            Console.WriteLine($"stu4.Name = {stu4.Name}");
            Console.WriteLine("--------------------------");


            Console.WriteLine("属性（property）--- 动态计算属性");
            Student2 stu5 = new Student2();
            stu5.Age = 20;
            Console.WriteLine($"stu5 能工作吗？--- {stu5.CanWork}");
            Console.WriteLine("--------------------------");


            /*
             建议：永远使用属性（而不是字段）来暴露数据，即字段永远都是 private 或 protected 的。 
            */
        }
    }

    struct Color
    {
        public int Red;
        public int Green;
        public int Blue;
    }

    class Brush
    {
        //静态只读字段（不常用）
        public static readonly Color DefaultColor = new Color() { Red = 0, Green = 0, Blue = 0 };

        //下面这种写法跟上面一样
        //public static readonly Color DefaultColor;
        ////静态构造器
        //static Brush()
        //{
        //    Brush.DefaultColor = new Color() { Red = 0, Green = 0, Blue = 0 };
        //}
    }

    class Student
    {
        // 静态字段，在类第一次加载的时候初始化，只初始化一次
        public static int AverageAge;

        // 只读字段，只有一次初始机会：声明时初始化，或者 在构造函数中初始化。
        public readonly int Id = 1;

        //属性（property）--- 完整声明
        private int age; // age字段 是被 Age属性 包装的字段
        public int Age  // 属性（property）:为了向外部暴露数据，以及外部设置值时，对数据做一些校验
        {
            get  // getter
            {
                return this.age;
            }
            set  // setter
            {
                // value 是默认变量, 变量名不能改变
                // value 叫做上下文关键字
                if (value >= 0 && value <= 120)
                {
                    this.age = value;
                }
                else
                {
                    throw new Exception("Age value has error!");
                }
            }
        }

        private static int amount;
        public static int Amount
        {
            get { return amount; }
            set
            {
                if (value >= 0)
                {
                    amount = value;
                }
                else
                {
                    throw new Exception("Amount value has error!");
                }
            }
        }
    }

    class Student2
    {
        // 在反编译器中，可以看到
        //     - Age的后台变量： '<Age>k__BackingField'
        //     - 自动生成的方法： get_Age : int32()  
        //     - 自动生成的方法： set_Age : int32()  
        public static int Age { get; set; }         //属性（property）--- 简略声明，

        private int id = 1;
        public int Id
        {
            get { return id; } // 只有get没有set 是 只读的属性
        }

        private string name;
        public string Name
        {
            get { return name; }
            private set  // 类内部可以只用，外部不可以使用
            {
                name = value;
            }
        }

        public void SomeMethod()
        {
            this.Name = "内部调用设置名字";
        }


        public bool CanWork
        {
            get
            {
                //动态计算属性
                if (this.Age >=16)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
