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


//事件声明 --- 简略格式（字段式声明，field-like）
namespace EventExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            customer.PayTheBill();
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
        public event OrderEventHandler Order;
        
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

            // this.orderEventHandler 如果是 null 表示没人订阅该事件
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
