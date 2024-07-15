using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib.MyNamespace;

namespace HelloClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            double res = calc.Add(1.1, 2.2);
            Console.WriteLine($"res={res}");
            //Calculator2 calc2 = new Calculator2(); // internal 修饰的类，在外部项目中不能访问
            Console.ReadLine();
        }

        // 在类里声明类（成员类）
        //     - 成员类可以用 private 修饰
        class Student
        {

        }
    }
}

// 在自定义命名空间声明类
namespace MyNS
{
    class Teacher
    {

    }
}


//在外面声明类（在全局命名空间里声明类），几乎不这么写
class Computer
{

}