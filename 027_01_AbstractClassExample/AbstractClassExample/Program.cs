using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
抽象类 与 开放/关闭原则

抽象类（abstract修饰的类）
    - 函数成员没有被完全实现的类，即类中至少有一个类没有被实现（用 abstract 修饰，并且访问级别不能是 private）。
    - 抽象类不能被实例化。
    - 抽象类可以用于声明变量。


开放/关闭原则
    - 对扩展开放，对修改关闭
    - 除了修复bug，或者添加性功能，不能对已经实现的方法进行侵入式修改。
*/

namespace AbstractClassExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("含有虚方法的类-可以实例化");
            Vehicle0 v = new Vehicle0();
            v.Run();
            Console.WriteLine("---------------------------");


            Console.WriteLine("含有纯虚方法的类（抽象类）-不能实例化");
            //Vehicle V1 = new Vehicle();  // 抽象类不能实例化
            Vehicle v2 = new Car();
            v2.Run();
            Console.WriteLine("---------------------------");


            Vehicle v3 = new RaceCar();
            v3.Run();
            Console.WriteLine("---------------------------");
        }
    }

    class Vehicle0
    {
        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public void Fill()  // 加油
        {
            Console.WriteLine("Pay and fill...");
        }

        // 虚方法，含有虚方法的类是可以被实例化的。
        // 只有当类内含有 抽象方法（纯虚方法）时，该类才是抽象类，不能被实例化。
        public virtual void Run()
        {
            Console.WriteLine("Vehicle is running...");
        }
    }
    // ------------------------------------------------------------------------------

    // ------------------------------- 用纯抽象类实现 ---------------------------------
    // 抽象类，不能被实例化
    abstract class VehicleBase
    {
        // 抽象方法（又被称为 纯虚方法）
        public abstract void Stop();
        public abstract void Fill();
        public abstract void Run();
    }

    // 抽象类，不能被实例化
    // 只要有一个没有被实现的 抽象方法，该类就是抽象类
    // Vehicle 类没有实现父类中的 Run() 方法
    abstract class Vehicle : VehicleBase
    {
        public override void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public override void Fill()
        {
            Console.WriteLine("Pay and fill...");
        }
    }
    // ------------------------------------------------------------------------------

    // --------------------------------- 用接口实现 ----------------------------------
    /*
    接口介绍
        - 接口中的方法都是抽象的，所以不用写 abstract
        - 接口中的方法要求都是public，所以不用写 public

    工作中这种方式比较常用
    */

    //interface IVehicle
    //{
    //    void Stop();
    //    void Fill();
    //    void Run();
    //}

    //abstract class Vehicle : IVehicle
    //{
    //    public void Stop()
    //    {
    //        Console.WriteLine("Stopped!");
    //    }

    //    public void Fill()
    //    {
    //        Console.WriteLine("Pay and fill...");
    //    }

    //    public abstract void Run();
    //}
    // ------------------------------------------------------------------------------


    class Car : Vehicle
    {
        // 子类实现 父类中的抽象方法
        public override void Run()
        {
            Console.WriteLine("Car is running...");
        }
    }

    // 如果子类不实现父类的抽象方法，那么子类也是抽象类，所以也要用 abstract 修饰子类
    abstract class Car2 : Vehicle { }

    class Truck : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Truck is running...");
        }
    }

    class RaceCar : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("RaceCar is running...");
        }
    }
}
