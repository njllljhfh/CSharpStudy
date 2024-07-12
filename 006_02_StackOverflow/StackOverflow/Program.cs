using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 程序运行时，类型的变量分配在内存的什么位置
            // 栈（Stack)
            // 堆(Heap)
            // c# 有垃圾回收期，不需要手动回收内存。

            Console.WriteLine("模拟栈溢出1");
            //BadGuy bg = new BadGuy();
            //bg.BadMethod();  // 命令行报错：Process is terminated due to StackOverflowException.
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("模拟栈溢出2");
            // 声明在 栈 上创建数据
            unsafe
            {
                int* p = stackalloc int[99999999];  // 命令行报错：Process is terminated due to StackOverflowException.
            }
        }
    }

    class BadGuy
    {
        // 模拟栈溢出
        public void BadMethod()
        {
            int x = 100;
            this.BadMethod();
        }
    }
}
