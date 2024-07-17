using System;
using MyLib;


namespace HelloAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehcle = new Vehicle();
            vehcle.Owner = "Timothy";
            Console.WriteLine($"vehcle.Owner = {vehcle.Owner}");
            //vehcle.Owner2 = "Timothy2";  // 无法访问 internal 属性
            Console.WriteLine("------------------------------------------");


            Car car = new Car();
            car.Refuel();
            car.Accelerate();
            car.Accelerate();
            Console.WriteLine($"car.Speed = {car.Speed}");
            Console.WriteLine("------------------------------------------");


            Car car2 = new Car();
            //car2.Burn();  // 无法访问 protected 方法
            car2.Refuel();
            car2.TurboAccelerate();
            Console.WriteLine($"car2.Speed = {car2.Speed}");
            Console.WriteLine("------------------------------------------");


            Bus bus = new Bus();
            bus.SlowAccelerate();
            Console.WriteLine($"bus.Speed = {bus.Speed}");
            Console.WriteLine("------------------------------------------");
        }
    }

    class Bus : Vehicle
    {
        public void SlowAccelerate()
        {
            //子类可以跨程序集访问父类的 protected 成员
            Burn(1);
            _rpm += 500;
        }
    }
}
