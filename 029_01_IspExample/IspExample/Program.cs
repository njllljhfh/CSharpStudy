using System;


namespace IspExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicle vehicle = new Car();
            var driver = new Driver(vehicle);
            driver.Drive();
            Console.WriteLine("-----------------------");


            vehicle = new Truck();  // 里氏替换
            var driver2 = new Driver(vehicle);
            driver2.Drive();
            Console.WriteLine("-----------------------");


            vehicle = new HeavyTank();
            var driver3 = new Driver(vehicle);
            driver3.Drive();
            Console.WriteLine("-----------------------");
        }
    }

    class Driver
    {
        private IVehicle _vehicle;

        // 依赖倒置，依赖接口 IVehicle 而不是实现类（如car）
        public Driver(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Drive()
        {
            _vehicle.Run();
        }
    }

    interface IVehicle
    {
        void Run();
    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running...");
        }
    }

    // 接口隔离：接口隔离 与 单一职责，经常是同时体现的。
    // IVehicle 和 IWeapon 对 不相关的 Run() 和 Fire() 方法进行了接口隔离
    // 这样，driver即可以开普通的车，也可以开坦克，因为它们都实现了 IVehicle 接口。
    interface IWeapon
    {
        void Fire();
    }

    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running...");
        }
    }
    // C#中，子类可以实现多个接口，但是只能继承一个父类
    // 一个接口可以继承多个其他的接口
    interface ITank : IVehicle, IWeapon { }

    class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!");
        }

        public void Run()
        {
            Console.WriteLine("Ka! ka! ka!...");
        }
    }

    class MediumTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka!! ka!! ka!!...");
        }
    }

    class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka!!! ka!!! ka!!!...");
        }
    }

    // 这些实现类，都遵守了 开闭原则
}
