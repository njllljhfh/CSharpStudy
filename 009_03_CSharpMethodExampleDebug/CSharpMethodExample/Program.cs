using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
每个线程都有自己的 栈

Debug：
    - 断点
    - 查看函数调用栈（窗口在：菜单栏-调试-窗口-调用堆栈， 快捷键 Ctrl + Alt + c）
*/

namespace CSharpMethodExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            //double a = Calculator.GetCircleArea(100);

            /*
            C# 遵从 C++ 的栈管理规则
            C#中，100，100 这两个参数归 Main方法的栈帧 来管理（谁调用，谁来管理。）。压栈的顺序是，先压左边的，再压右边的。

            函数的返回值，一般存在cpu的寄存器中。如果寄存器存不下这个值，则会在栈上开辟内存来存储返回值。当函数返回时，把寄存器中的返回值 赋值给保存返回值的变量。
            */
            double result = Calculator.GetConeVolume(100,100);
        }
    }

    class Calculator
    {
        public static double GetCircleArea(double r)
        {
            //计算圆面积
            return Math.PI * r * r; 
        }

        // 方法复用
        public static double GetCylinderVolume(double r, double h)
        {
            /*
            变量 a 由 GetCylinderVolume 方法的栈帧管理
            
            调用 GetCircleArea 时要压入栈的 r 由 GetCylinderVolume 方法的栈帧管理
            */

            //计算圆柱体积
            double a = GetCircleArea(r);  // 当函数返回时，把寄存器中的返回值 赋值给保存返回值的变量。
            return a * h;
        }

        // 方法复用
        public static double GetConeVolume(double r, double h)
        {
            /*
            变量 cv 由 GetConeVolume 方法的栈帧管理
            
            调用 GetCylinderVolume 时要压入栈的 r,h 由 GetConeVolume 方法的栈帧管理
            */

            //计算圆锥体积
            double cv =  GetCylinderVolume(r,h);
            return cv/3;
        }
    }
}
