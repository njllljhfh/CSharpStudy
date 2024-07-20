// See https://aka.ms/new-console-template for more information

using System;
using System.Reflection.Metadata;


namespace OverrideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Run();
            Console.WriteLine("-----------------------------------");


            var v = new Vehicle();
            v.Run();
            Console.WriteLine("-----------------------------------");

            
            Console.WriteLine("重写方法");
            Console.WriteLine("多态：当用一个父类的变量引用一个子类的对象，调用一个被重写的成员时，调用的是该实例的类型的成员。");
            Vehicle v2 = new Car();
            v2.Run();
            Vehicle v3 = new RaceCar();
            v3.Run();
            Car c3 = new RaceCar();
            c3.Run();
            Console.WriteLine("-----------------------------------");

            
            Console.WriteLine("重写属性（property）");
            Vehicle v4 = new Vehicle();
            v4.Run();
            Console.WriteLine($"v4.Speed = {v4.Speed}");
            Console.WriteLine("---------");
            Vehicle v5 = new Car();
            v5.Run();
            Console.WriteLine($"v5.Speed = {v5.Speed}");
            Console.WriteLine("-----------------------------------");
        }
    }

    /*
    如果 不写 virtual 和 override 关键字，那么在 Car 类里不是重写了 Run() 方法，
    而是隐藏（hid）了 父类的 Run() 方法，相当于 Car 中有两个 Run()方法。
        当用 Vehicle v2 = new Car(); 创建对象时， v2.Run(); 执行的是 父类 Vehicle 中的Run()。
        当用 Car car = new Car(); 创建对象时， car.Run(); 执行的是 子类 Car 中的Run()。

    注意：开发中不用这种隐藏（hid）的用法。
    */

    class Vehicle
    {
        private int _speed;

        public virtual int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        //virtual 修饰的方法，是可被重写的方法
        public virtual void Run()
        {
            Console.WriteLine("I'm running!");
            _speed = 100;
        }
    }

    class Car : Vehicle
    {
        private int _rpm;

        // 子类的属性，重写父类的属性
        public override int Speed
        {
            get { return _rpm / 100; }
            set { _rpm = value * 100; }
        }

        // 子类的成员，对父类的成员，进行重写
        public override void Run()
        {
            Console.WriteLine("Car is running!");
            _rpm = 5000;
        }
    }

    class RaceCar : Car
    {
        public override void Run()
        {
            Console.WriteLine("Race car is running!");
        }
    }
}