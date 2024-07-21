using System;
using System.Reflection;
// 依赖注入
using Microsoft.Extensions.DependencyInjection;  


namespace IspExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITank tank = new HeavyTank();
            //----------------------------------

            var t = tank.GetType(); // 获取对象的类型（类型相关的信息），GetType() 返回的是 Type 类型
            object o = Activator.CreateInstance(t);
            // 反射的基本原理，使用反射，动态调用对象的方法
            MethodInfo fireMi = t.GetMethod("Fire");
            MethodInfo runMi = t.GetMethod("Run");
            fireMi.Invoke(o, null);
            runMi.Invoke(o, null);
            Console.WriteLine("------------------------------------");


            Console.WriteLine("依赖注入-注册");
            // 只需要注册一次（如，在程序启动的时候）
            // 后续代码 只要能访问到 sp 的地方，都可以使用。不再需要用 new 操作符，直接从 容器 中要对象。
            // ---
            // 依赖注入：
            //     - 容器（container）
            var sc = new ServiceCollection();  // ServiceCollection 就是所谓的 容器
            // ITank本身是静态类型，用 typeof 拿到 ITank的动态类型描述
            sc.AddScoped(typeof(ITank), typeof(HeavyTank)); // 把一对类型放入容器（参数1：提供服务的类，参数2：实现了该服务的类）

            // 如果不注册 IVehicle 的实现类，那么当调用 sp.GetService<Driver>() 时会报错：
            //     System.InvalidOperationException: Unable to resolve service for type 'IspExample.IVehicle' while attempting to activate 'IspExample.Driver'.
            sc.AddScoped(typeof(IVehicle), typeof(Car));  
            //sc.AddScoped(typeof(IVehicle), typeof(LightTank)); // 已注册的 IVehicle 接口的实现类，会被最后注册的 IVehicle接口的实现类覆盖掉。

            sc.AddScoped<Driver>();

            var sp = sc.BuildServiceProvider();
            Console.WriteLine("------------------------------------");


            Console.WriteLine("依赖注入-使用");
            ITank tank2 = sp.GetService<ITank>();
            tank2.Fire();
            tank2.Run();
            Console.WriteLine("-----");
            // 这里没有显示的传递 Driver 构造器需要的 IVehicle类型的参数
            // sp 用 已注册的 typeof(IVehicle) 的实现类的实例，作为 Driver 构造器需要的 IVehicle类型的参数
            var driver = sp.GetService<Driver>();
            driver.Drive();
            Console.WriteLine("------------------------------------");
        }
    }

    class Driver
    {
        private IVehicle _vehicle;

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

    interface ITank : IVehicle, IWeapon { }

    class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!");
        }

        public void Run()
        {
            Console.WriteLine("LightTank Ka! ka! ka!...");
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
            Console.WriteLine("MediumTank Ka!! ka!! ka!!...");
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
            Console.WriteLine("HeavyTank Ka!!! ka!!! ka!!!...");
        }
    }
}
