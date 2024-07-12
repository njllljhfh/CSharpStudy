using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFun
{
    // c#不能再类外面定义函数
    // 编译报错：命名空间不能直接包含字段、方法或语句之类的成员
    //double Add0(double a, double b)
    //{
    //    return a + b;
    //}

    internal class Program
    {
        static void Main(string[] args)
        {
        }

        //方法永远都是类 或者 结构体的成员
        //方法是类或结构体的基本成员之一
        //    最基本的成员有两个：字段 和 方法（又叫成员变量 和 成员函数）
        double Add(double a, double b)
        {
            return a + b;
        }
    }
}
