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
            Console.WriteLine("委托");
            Calculator c = new Calculator();
            //委托 Action 只能接受 无返回值并且无参数的方法
            Action myAction = new Action(c.PrintHello);
            myAction();
            Console.WriteLine("---------------------------");


            Console.WriteLine("访问数组元素");
            //int[] myIntArray1 = new int[10]; // 初始值为0
            int[] myIntArray2 = new int[] { 1, 2, 3, 4, 5 }; //初始化器
            Console.WriteLine(myIntArray2[0]);
            Console.WriteLine(myIntArray2[myIntArray2.Length - 1]);
            Console.WriteLine("---------------------------");


            Console.WriteLine("访问字典元素");
            // Dictionary 是一个泛型类，后续会将
            Dictionary<string, Student> stuDic = new Dictionary<string, Student>();
            for (int i = 1; i <= 100; i++)
            {
                Student stu = new Student();
                stu.Name = "s_" + i.ToString();
                stu.Score = 100 + i;
                stuDic.Add(stu.Name, stu);
            }
            Student number6 = stuDic["s_6"];
            Console.WriteLine(number6.Score);
            Console.WriteLine("---------------------------");


            int x = 100;
            int y = x++;  // 先执行赋值 y = x，然后再 x += 1
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine("---------------------------");


            Console.WriteLine("typeof");
            //Metadata: 数据类型的元信息
            Type t = typeof(int);
            Console.WriteLine(t.Namespace);
            Console.WriteLine(t.FullName);
            Console.WriteLine(t.Name);
            int count = t.GetMethods().Length;  // t类型方法的个数
            foreach (var mi in t.GetMethods())
            {
                Console.WriteLine(mi.Name);
            }
            Console.WriteLine(count);
            Console.WriteLine("---------------------------");


            Console.WriteLine("default");
            // default：类型的默认值
            // 结构体类型（它是值类型）的默认值，x2内存中数据都为0
            int x2 = default(int);
            Console.WriteLine(x2);
            double x3 = default(double);
            Console.WriteLine(x3);
            Console.WriteLine("-------");

            // 引用类型的默认值，myForm内存中数据都为0，也就是空值
            Form myForm = default(Form);  //null
            Console.WriteLine(myForm == null);
            Console.WriteLine("-------");

            // 枚举类型（它是值类型）
            Level level = default(Level);  // 获取的是0，如果有对应的枚举值（如Low=0）就显示Low。没有就显示0
            Console.WriteLine(level);
            Console.WriteLine($"level == 0 吗？ {level == 0}");
            Console.WriteLine("---------------------------");

            Console.WriteLine("var：声明隐式类型的变量");
            //int x4; //显示声明类型
            var x5 = 100; //var：声明隐式类型的变量
            Console.WriteLine(x5.GetType().Name);  //Int32
            var x6 = 100L;
            Console.WriteLine(x6.GetType().Name);  //Int64
            var x7 = 100D;
            Console.WriteLine(x7.GetType().Name);  //Double
            Console.WriteLine("---------------------------");
        }
    }

    class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public void PrintHello()
        {
            Console.WriteLine("Hello");
        }
    }

    class Student
    {
        public string Name;
        public int Score;
    }

    // 定义枚举类型时，最好要给0值对应的枚举
    enum Level
    {
        Mid = 2,
        //Low = 1,
        Low = 0,
        High = 3
    }
}
