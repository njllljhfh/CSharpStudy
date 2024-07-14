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
            customer.Action();
            customer.PayTheBill();  // customer 白花了 30
        }
    }

    // 自定义事件参数，一般继承自 EventArgs
    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    //不声明自定义的委托 OrderEventHandler
    //public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    public class Customer
    {
        //public event OrderEventHandler Order;
        // 不声明自定义的委托 OrderEventHandler。使用.Net 平台已经为我们准备好的 EventHandler 委托（专门用于声明事件的委托类型）。
        public event EventHandler Order;

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
            // 触发事件
            this.OnOrder("Kongpao Chicken", "large");
        }
        
        // 触发事件的方法命名规则：On + 事件名
        protected void OnOrder(string dishName, string size)
        {
            // 注意：要判断 事件 封装的 委托 是否为空
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishName;
                e.Size = size;
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
        public void Action(object sender, EventArgs e)
        {
            Customer customer = sender as Customer;
            OrderEventArgs orderInfo = (OrderEventArgs)e;
            
            Console.WriteLine($"I will serve you the dish - {orderInfo.DishName}");
            double price = 10;
            switch (orderInfo.Size)
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
