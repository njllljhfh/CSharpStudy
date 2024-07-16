using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RaceCar raceCar = new RaceCar();
            //raceCar.Owner = "张三";
            //Console.WriteLine(raceCar.Owner);
            //Console.WriteLine("---------------------------------");

            //Car car = new Car();
            Car car = new Car("Timothy");
            Console.WriteLine(car.Owner);
            car.ShowOwner();
            Console.WriteLine("---------------------------------");
        }
    }

    class Vehicle
    {
        //public Vehicle()
        //{
        //    this.Owner = "N/A";
        //}

        // 父类的实例构造器 不能被子类继承，子类要定义自己的实例构造器
        public Vehicle(string owner)
        {
            this.Owner = owner;
        }

        public string Owner { get; set; }
    }

    class Car : Vehicle
    {
        //public Car()
        //{
        //    // 调用构造器Car()时，先调用父类的构造器Vehicle()，再调用Car()的构造器
        //    this.Owner = "Car Owner";
        //}

        public Car(string owner) : base(owner)
        {
            this.Owner = owner;
        }

        public void ShowOwner()
        {

            Console.WriteLine($"this.Owner = {this.Owner}");
            // base 只能访问上一级父类的对象（即没有 base.base）
            Console.WriteLine($"base.Owner = {base.Owner}"); // this.Owner 和 base.Owner 指向内存的同一个字符串
            // this 和 base 可以不写，直接写 Owner
            Console.WriteLine($"Owner = {Owner}");
        }
    }

    //class RaceCar : Car
    //{

    //}
}
