using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


/*
事件的应用
事件模型的五个组成部分
    - 事件的拥有者（event source，对象）
    - 事件成员（event，成员）
    - 事件的响应者（event subscriber，对象）
    - 事件处理器（event handler，成员） --- 本质上是一个回调方法
    - 事件订阅 --- 把事件处理器与事件关联在一起，本质上是一种以委托类型为基础的"约定"
*/


namespace EventExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            // 扳手图标：属性
            // 方块图标：方法
            // 闪电图标：事件
            timer.Interval = 1000;  // 1s
            Boy boy = new Boy();
            Girl girl = new Girl();

            // +=  订阅事件的操作符
            timer.Elapsed += boy.Action;
            timer.Elapsed += girl.Action;

            timer.Start();

            Console.ReadLine();  // 让控制台窗口等待用户输入，不退出
        }
    }

    class Boy
    {
        //internal 是什么？
        //object sender, ElapsedEventArgs e 是 timer.Elapsed 事件约定的入参
        internal void Action(object sender, ElapsedEventArgs e)  // 事件处理器
        {
            Console.WriteLine("Jump!");
        }
    }

    class Girl
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Sing！");
        }
    }
}
