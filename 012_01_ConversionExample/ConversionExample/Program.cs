using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string str1 = Console.ReadLine();  // 从命令行获取输入
            //string str2 = Console.ReadLine();
            //Console.WriteLine(str1 + str2);
            //// 类型装换  string --> int
            //int x = Convert.ToInt32(str1);
            //int y = Convert.ToInt32(str2);
            //Console.WriteLine(x + y);
            Console.WriteLine("---------------------------");

            /*
            隐式（implicit）类型转换
                - 不丢失精度的转换
                - 子类向父类的转换
                - 装箱
            */
            Console.WriteLine("隐式（implicit）类型转换");
            Console.WriteLine("不丢失精度的转换");
            int x2 = int.MaxValue;
            long y2 = x2;
            Console.WriteLine(y2);
            Console.WriteLine("---------");

            Console.WriteLine("子类向父类的转换");
            Teacher t = new Teacher(); //t 变量存储额度值 是Teacher实例在内存在中的地址。
            Human h = t;  // 子类向父类的隐式类型转换
            /*
            当用引用类型的变量访问它引用的实例对象的成员时，只能访问到该变量的类型所具有的成员(例如该变量是父类类型，那么用该变量无法访问子类独有的方法，只能访问父类具有的方法)。 
            */
            //h.Teach(); // h 无法调用 Teach() 方法
            t.Think();
            Animal a = h;
            a.Eat();  // a 变量 只能访问 Eat() 方法
            Console.WriteLine("---------------------------");


            /*
            显式（explicit）类型转换
                - 有可能丢失精度（甚至发生错误）的转换，即 cast（铸造的意思）
                - 拆箱
                - 使用Convert类
                - ToString方法与各数据类型的Parse/TryParse方法
            */
            Console.WriteLine("显式（explicit）类型转换");
            Console.WriteLine("cast（铸造的意思）形式的显式类型转换");
            Console.WriteLine(ushort.MaxValue);
            uint x3 = 65536;
            Console.WriteLine($"x3 的二进制：{Convert.ToString(x3, 2).PadLeft(32, '0')}");
            //ushort y3 = x3;  //编译器报错无法进行隐式类型转换
            ushort y3 = (ushort)x3;  //编译器报错无法进行隐式类型转换
            Console.WriteLine($"y3 = {y3}"); // 0, 丢失了精度
            Console.WriteLine("---------");

            Console.WriteLine("使用Convert类");
            string tb1Text = "12";
            string tb2Text = "12";
            double x4 = Convert.ToDouble(tb1Text);
            double y4 = Convert.ToDouble(tb2Text);
            double result = x4 + y4;
            string tb3Text = Convert.ToString(result);
            Console.WriteLine($"tb3Text = {tb3Text}");
            Console.WriteLine("---------");

            Console.WriteLine("直接调用数值数据的实例方法");
            tb3Text = result.ToString();
            Console.WriteLine($"tb3Text = {tb3Text}");
            Console.WriteLine("---------");

            Console.WriteLine("用数据类型的 Parse/TryParse 方法");
            //tb1Text = "ab";
            //double xxx = double.Parse(tb1Text);  //System.FormatException: 输入字符串的格式不正确。
            double x5 = double.Parse(tb1Text);  // Parse 只能解析格式正确的数据
            double y5 = double.Parse(tb2Text);
            double result5 = x5 + y5;
            Console.WriteLine($"result5 = {result5}");

            // TryParse 第二个参数是 输出 参数
            double result6;
            tb1Text = "ab";
            bool ok = double.TryParse(tb1Text, out result6);
            if (ok)
            {
                Console.WriteLine($"result6 = {result6}");
            }
            else
            {
                Console.WriteLine($"数据格式不正确，无法转换为double类型：{tb1Text}");
            }
            Console.WriteLine("---------------------------");


            Console.WriteLine("自定义类型转换操作符");
            Stone stone = new Stone();
            stone.Age = 5000;
            Monkey wuKongSun = (Monkey)stone;  // 显示类型转换
            //Monkey wuKongSun = stone;  // 隐式类型转换
            Console.WriteLine($"wuKonSun 的年龄：{wuKongSun.Age}");
            Console.WriteLine("---------------------------");

            
            Console.WriteLine("乘法");
            // 加、减、乘、除、取余 都可能发生 数据类型提升
            var x6 = 3.0 * 4;  // 数据类型提升，int型的4 被提升为double类型
            Console.WriteLine(x6.GetType().FullName);  // System.Double
            Console.WriteLine(x6);
            Console.WriteLine("---------------------------");


            Console.WriteLine("浮点数除法");
            double x7 = 5.0;
            double y7 = 0;
            double z7 = x7 / y7;
            Console.WriteLine($"z7 = {z7}");  //  ∞  正无穷大
            x7 = -5.0;
            z7 = x7 / y7;
            Console.WriteLine($"z7 = {z7}");  //  -∞  负无穷大
            x7 = 0;
            z7 = x7 / y7;
            Console.WriteLine($"z7 = {z7}");  //  NaN

            double a2 = double.PositiveInfinity;  //  ∞
            double b2 = double.NegativeInfinity;  //  -∞
            double c2 = a2 / b2;
            Console.WriteLine($"c2 = {c2}");  //  NaN

            double x8 = (double)5 / 4;   // 数据类型提升，int型的4 被提升为double类型
            Console.WriteLine($"x8 = {x8}");  // 1.25
            Console.WriteLine("---------------------------");


            Console.WriteLine("移位运算");
            /*
            << ：左移，不论是正数还是负数，补进来的位永远是 0
            >> : 右移，正数高位补0；负数高位补1

            在没有产生溢出的情况下
                - 左移一位 就是 数据*2
                - 右移一位 就是 数据/2
             */
            int x9 = 7;
            int y9 = x9 << 2;  // 7 * 2 * 2
            string strX9 = Convert.ToString(x9,2).PadLeft(32,'0');
            string strY9 = Convert.ToString(y9,2).PadLeft(32,'0');
            Console.WriteLine(strX9);
            Console.WriteLine(strY9);
            Console.WriteLine(y9);  // 28
            Console.WriteLine("---------------------------");


            Console.WriteLine("char 类型");
            char char1 = 'a';
            char char2 = 'A';
            // C# 与 C++ 中不同，C++ 中的 char 是 1 个字节
            Console.WriteLine(sizeof(char));  // char 是 2 个字节，保存一个无符号短整型的数
            ushort u1 = (ushort)char1;
            ushort u2 = (ushort)char2;
            Console.WriteLine(u1);
            Console.WriteLine(u2);
            Console.WriteLine("---------------------------");


            Console.WriteLine("is 操作符");
            Teacher t2 = new Teacher();
            var result2 = t2 is Teacher;  // 检验变量引用的实例的类型
            Console.WriteLine(result2.GetType().FullName);
            Console.WriteLine($"t2 is Teacher: {result2}");  // True
            result2 = t2 is Human;
            Console.WriteLine($"t2 is Human: {result2}");  // True
            result2 = t2 is Animal;
            Console.WriteLine($"t2 is Animal: {result2}");  // True

            Human h2 = new Human();
            var result3 = h2 is Teacher;
            Console.WriteLine($"h2 is Teacher: {result3}");  // False
            Console.WriteLine("---------------------------");


            Console.WriteLine("as 操作符");
            object o = new Teacher();
            if ( o is Teacher )
            {
                Teacher t3 = (Teacher)o;
                t3.Teach();
            }
            Console.WriteLine("---------");

            object o2 = new Teacher();
            // o2 引用的对象 是否像 Teacher类的对象 一样？
            // 是：将 o2 的地址 交给 变量 t4
            // 否：将 null 交给 t4
            Teacher t4 = o2 as Teacher;
            if ( t4 != null ) 
            {
                t4.Teach();
            }
            Console.WriteLine("---------------------------");


            Console.WriteLine("& : 按位与");
            // & : 按位与
            // | : 按位或
            // ^ : 按位异或
            int x10 = 7;
            int y10 = 28;
            int z10 = x10 & y10;
            string strX10 = Convert.ToString(x10, 2).PadLeft(32, '0');
            string strY10 = Convert.ToString(y10, 2).PadLeft(32, '0');
            string strZ10 = Convert.ToString(z10, 2).PadLeft(32, '0');
            Console.WriteLine(strX10);
            Console.WriteLine(strY10);
            Console.WriteLine(strZ10);
            Console.WriteLine("---------------------------");

            // && : 条件与
            // || : 条件或
            int x11 = 3;
            int y11 = 4;
            int a11 = 3;
            // 短路效应：因为 x11 > y11 不成立，&& 后面的 a11++ > 3 语句不会执行
            // 写代码时，应该尽量避开这种短路效应！！！
            if (x11 > y11 && a11++ > 3) 
            {
                Console.WriteLine("Hello");
            }
            Console.WriteLine($"a11 = {a11}");
            Console.WriteLine("---------------------------");


            Console.WriteLine("?? : null值 合并 操作符");
            // Nullable 可空类型，是一个泛型类型
            //Nullable<int> x12 = null;
            int? x12 = null; // Nullable<int> x12 = null; 的简写。
            Console.WriteLine($"x12.HasValue = {x12.HasValue}");
            x12 = 100;
            Console.WriteLine($"x12 = {x12}");
            Console.WriteLine($"x12 = {x12.Value}");
            Console.WriteLine($"x12.HasValue = {x12.HasValue}");
            Console.WriteLine("-------");

            int? x13 = null;
            //x13 = 13;
            // x13 是 null 吗？
            // 是：y13 = 1
            // 否：y13 = x13
            int y13 = x13 ?? 1;  // ?? : null值 合并 操作符。用来操作可空类型。
            Console.WriteLine($"y13 = {y13}");
            Console.WriteLine("---------------------------");


            Console.WriteLine("'?:'  条件操作符（三目运算符）");
            int x14 = 80;
            string str = string.Empty;
            str = x14 > 60 ? "Pass" : "Failed";
            Console.WriteLine($"str = {str}");
            Console.WriteLine("---------------------------");


            Console.WriteLine("赋值操作符，运算顺序是从右向左");
            int x15 = 5;
            int y15 = 6;
            int z15 = 7;
            int a15 = x15 += y15 *= z15;
            Console.WriteLine($"y15 = {y15}");
            Console.WriteLine($"x15 = {x15}");
            Console.WriteLine($"a15 = {a15}");
            Console.WriteLine("---------------------------");
        }
    }

    // Animal、Human、Teacher，这些类形成了一个继承链。
    
    // 基类
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }
    }

    class Human : Animal
    {
        public void Think()
        {
            Console.WriteLine("Who I am?");
        }
    }

    class Teacher : Human
    {
        public void Teach()
        {
            Console.WriteLine("I teach programming.");
        }
    }
    // ---------------------------
    class Stone
    {
        public int Age;

        //自定义类型转换操作符
        //explicit: 显式类型装换
        //Monkey: 目标类型
        public static explicit operator Monkey(Stone stone)
        {
            Monkey m = new Monkey();
            m.Age = stone.Age / 500;
            return m;
        }

        //implicit：隐式类型转换
        //public static implicit operator Monkey(Stone stone)
        //{
        //    Monkey m = new Monkey();
        //    m.Age = stone.Age / 500;
        //    return m;
        //}
    }

    class Monkey
    {
        public int Age;
    }
    // ---------------------------

    class Car
    {
        public void Run()
        {
            Console.WriteLine("Running...");
        }
    }
}
