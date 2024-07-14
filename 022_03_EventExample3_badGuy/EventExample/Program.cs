using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/*
事件的应用
事件模型的五个组成部分
    - 事件的拥有者（event source，对象）
    - 事件成员（event，成员）
    - 事件的响应者（event subscriber，对象）
    - 事件处理器（event handler，成员） --- 本质上是一个回调方法
    - 事件订阅 --- 把事件处理器与事件关联在一起，本质上是一种以委托类型为基础的"约定"
*/


/*
事件的本质是委托字段的一个包装器
    - 这个包装器对委托字段的访问起 限制作用，相当于一个“蒙板”
    - 封装（encapsulation）的一个重要功能就是隐藏
    - 事件对外界隐藏了委托实例的大部分功能，仅暴露 添加/移除 事件处理器的功能
*/


//事件声明 --- 简略格式
namespace EventExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            //customer.Action();


            //举例，不用 event 声明时事件的话，可能出现的潜在问题
            OrderEventArgs e = new OrderEventArgs();
            e.DishName = "Manhanquanxi";
            e.Size = "large";

            OrderEventArgs e2 = new OrderEventArgs();
            e2.DishName = "Beer";
            e2.Size = "large";

            // 没有 event 关键字修饰的 Order 是一个委托字段，可以在外面调用
            // badGuy 点餐，记账到了其他 customer 的账单上！！！
            Customer badGuy = new Customer();
            badGuy.Order += waiter.Action;
            badGuy.Order.Invoke(customer, e);   // 加上 event 关键字，编译报错
            badGuy.Order.Invoke(customer, e2);  // 加上 event 关键字，编译报错

            customer.PayTheBill();  // customer 白花了 30
        }
    }

    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    public class Customer
    {
        // 自定义事件：事件声明 --- 简略格式（可以用反编译工具常看二进制文件，会看到隐藏在背后的字段 Order : private class EventExample.OrderEventHandler）
        // 看上去很像是一个用 event 关键字修饰的 字段。实则不然，这只是表象。Order 是事件，不是字段。
        // 加上 event 后，Main 中的 badGuy直接调用Order事件时，编译器报错： 事件“Customer.Order”只能出现在 += 或 -= 的左边(从类型“Customer”中使用时除外)
        //public event OrderEventHandler Order;
        public OrderEventHandler Order;

        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine($"I will pay ${this.Bill}.");
        }

        public void WalkIn()
        {
            Console.WriteLine("Walk into the restaurant.");
        }

        public void SitDown()
        {
            Console.WriteLine("Sit down.");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me think ...");
                Thread.Sleep(1000);
            }

            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";
                this.Order.Invoke(this, e);
            }
        }

        public void Action()
        {
            Console.WriteLine("请单机回车键开始程序。。。");
            Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }

    public class Waiter
    {
        public void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine($"I will serve you the dish - {e.DishName}");
            double price = 10;
            switch (e.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }
    }
}
