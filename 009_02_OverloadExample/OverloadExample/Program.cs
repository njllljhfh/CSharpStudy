using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 方法重载：多个同名方法的签名不能相同
    - 方法签名（method signature）由方法的名称、类型形参（这个概念后续讲泛型会遇到）的个数和它的每一个形参（按从左到右的顺序）的类型和种类（值、引用或输出）组成。
      方法签名不包括返回值的类型。

    - 类的实例构造器也可以重载
 
    - 重载决策（到底调用哪一个重载）：根据传递的参数，来决定具体调用哪个方法。
 */
namespace OverloadExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine();// Console.WriteLine() 有很多个重载方法。
            Calculator c = new Calculator();
            int x = c.Add(100, 100);
            Console.WriteLine(x);

            double x2 = c.Add(100D, 200D);
            Console.WriteLine(x2);

            int x3 = c.Add(100, 200,300);
            Console.WriteLine(x3);
        }
    }

    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int a,int b,int c)
        {
            return a + b + c;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }

        //泛型编程，类型形参 T（此处只做了解）
        //public int Add<T>(int a, int b)
        //{
        //    T t;
        //    return a + b;
        //}

        //参数的种类：值、引用、输出（此处只做了解）
        //public int Add(ref int a, int b) // 传引用
        //{
        //    return a + b;
        //}
        
        //函数签名中，参数只有 ref 和 out 的不同，是不可以的（上面的ref和这里的out是冲突的，编译器报错）
        //public int Add(out int a, int b) // 输出
        //{
        //    a = 100;
        //    return a + b;
        //}
    }
}
