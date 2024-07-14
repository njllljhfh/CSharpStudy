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
有了委托字段/属性，为什么还需要事件？
    - 为了程序的逻辑更加“有道理”、更加安全，谨防“借刀杀人”
*/


/*
事件的本质是委托字段的一个包装器
    - 这个包装器对委托字段的访问起 限制作用，相当于一个“蒙板”（mask）
    - 封装（encapsulation）的一个重要功能就是隐藏
    - 事件对外界隐藏了委托实例的大部分功能，仅暴露 添加/移除 事件处理器的功能
*/


/*
用于声明事件的委托类型的命名约定
    - 用于声明Foo事件的委托，一般命名FooEventHandler（除非是一个非常通用的事件约束）
    - FooEventHandler 委托的参数一般有两个（由Win32 API 演化而来，历史悠久）
        - 第一个是 object 类型，名字为 sender，实际上就是事件的拥有者（事件的source）
        - 第二个是 EventArgs 类的派生类，类名一般为 FooEventArgs，参数名为 e。
        - 虽然没有官方说法，但是我们可以把委托的参数列表看做是事件发生后，发给事件响应者的 “事件消息”。
    - 触发 Foo 事件的方法一般命名为 OnFoo 。
        - 访问级别为 protected，不能为 public，不然又可以“借刀杀人”了。
*/


/*
事件的命名约定
    - 带有时态的动词或者动词短语
    - 事件拥有者“正在做”什么事情，用进行时；事件拥有者“做完了”什么事情，用完成时。
*/

//事件声明 --- 完整格式
namespace EventExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            // 挂载事件处理器
            customer.Order += waiter.Action;
            customer.Action();
            customer.PayTheBill();
        }
    }

    // 事件的参数类型
    // 事件的参数，一般继承 EventArgs 类
    // 注意：OrderEventArgs、OrderEventHandler、Customer 这几个类在逻辑中要配合起来用，他们的访问级别需要保持一致（此处都用的 public 级别）。
    public class OrderEventArgs : EventArgs
    {
        // 菜名
        public string DishName { get; set; }
        // 菜量
        public string Size { get; set; }
    }

    // 声明委托类型
    // void：定义事件处理器的返回值类型
    // Customer customer, OrderEventArgs e: 定义事件处理器的输入参数类型
    // EventHandler 的后缀是一种写代码的约定，代表这个 委托类型的用处是 用于自定义事件处理器的。
    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    // 顾客（事件的拥有者）
    public class Customer
    {
        // 定义委托类型的字段，用于引用事件处理器
        private OrderEventHandler orderEventHandler;

        // 自定义事件：事件声明 --- 完整格式
        // 事件是基于委托的
        // 声明事件（event 关键字）
        // OrderEventHandler : 约束事件的委托类型
        public event OrderEventHandler Order
        {
            // 事件的添加器
            add
            {
                this.orderEventHandler += value;  // value，上下文关键字
            }
            
            // 事件的移除器
            remove 
            {
                this.orderEventHandler -= value;
            }
        }

        
        // 账单
        public double Bill { get; set; }

        // 结账
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
            //if (this.Order != null)  // 编译器报错：事件“Customer.Order”只能出现在 += 或 -= 的左边
            if (this.orderEventHandler != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";
                // 触发事件
                this.orderEventHandler.Invoke(this, e);
            }
        }

        // 顾客的一连串动作
        public void Action()
        {
            Console.WriteLine("请单机回车键开始程序。。。");
            Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }

    // 服务生（事件的响应者）
    public class Waiter
    {

        // 事件处理器
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
