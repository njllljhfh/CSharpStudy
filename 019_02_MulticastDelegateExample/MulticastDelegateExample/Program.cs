using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


/*
应该适时的使用接口（interface）取代一些对委托的使用
    - java 完全地使用接口取代了委托的功能，即 java 没有与 C# 中委托相对应的功能实体。
*/

namespace MulticastDelegateExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };
            // 一个委托封装一个方法，叫做单播委托
            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            //action1.Invoke();
            //action2.Invoke();
            //action3.Invoke();
            // -------------------------------------------------------------


            action1 += action2; // 将 action2 合并到了 action1 里面
            action1 += action3;
            // 多播委托，按照封装顺序执行（同步执行）
            //action1.Invoke();  // 按照 action1、action2、action3 的顺序执行
            // -------------------------------------------------------------


            Action action4 = new Action(stu1.DoHomework);
            Action action5 = new Action(stu2.DoHomework);
            Action action6 = new Action(stu3.DoHomework);
            // 隐式异步调用
            // 使用委托的，隐式异步调用，下面这三个委托，是异步执行的
            // 控制台输出的文字颜色，由于多个线程共享资源，所以会出现设置颜色资源竞争的情况。
            //action4.BeginInvoke(null, null);
            //action5.BeginInvoke(null, null);
            //action6.BeginInvoke(null, null);
            // -------------------------------------------------------------


            // 显示异步调用 - 使用 Thread（比较老的方式）
            Thread thread1 = new Thread(new ThreadStart(stu1.DoHomework));
            Thread thread2 = new Thread(new ThreadStart(stu2.DoHomework));
            Thread thread3 = new Thread(new ThreadStart(stu3.DoHomework));
            //thread1.Start();
            //thread2.Start();
            //thread3.Start();
            // -------------------------------------------------------------


            // 显示异步调用 - 使用 Task
            Task task1 = new Task(new Action(stu1.DoHomework));
            Task task2 = new Task(new Action(stu2.DoHomework));
            Task task3 = new Task(new Action(stu3.DoHomework));
            task1.Start();
            task2.Start();
            task3.Start();

            for (int i = 0; i < 10; i++)  // 主线程要加个耗时的逻辑，否则，子线程还没执行结束，主线程就已经执行结束了。
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Main thread {i}.");
                Thread.Sleep(1000);  // 1s
            }
        }
    }

    class Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }

        public void DoHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine($"Student {this.ID} doing homwwork {i} hour(s)");
                Thread.Sleep(1000);  // 1s
            }
        }
    }
}
