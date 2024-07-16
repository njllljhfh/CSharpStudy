using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Car);
            Type tb = t.BaseType;
            Console.WriteLine(tb.FullName);  //HelloOOP.Vehicle
            Type tTop = tb.BaseType;
            Console.WriteLine(tTop.FullName);  //System.Object
            Console.WriteLine($"tTop.BaseType == null吗？ --- {tTop.BaseType == null}");
            Console.WriteLine("------------------------------");

            /*
            概念：是一个（is a）
                - 一个子类的实例，从语义上来讲也是父类的一个实例
                - Car 类的一个实例，从语义上说也是 Vehicle 类的一个实例
            */
            Car car = new Car();
            Console.WriteLine($"car is Vehicle 吗？ --- {car is Vehicle}");
            Console.WriteLine($"car is Object 吗？ --- {car is Object}");
            Console.WriteLine("------------------------------");

            // 可以用一个父类类型的变量 来引用一个子类类型的实例
            Vehicle vehicle = new Car();
            Object o1 = new Vehicle();
            Object o2 = new Car();
        }
    }

    class Vehicle
    {

    }

    class Toy
    {

    }

    // C#中，一个类只能有一个基类，但是可以有多个基接口（后面课程会讲）
    //class Car : Vehicle, Toy
    // 子类的访问级别不能超过父类，比如父类是 internal 级别，那么子类就不能是 public级别。
    //     - 但是反过来可以，父类是 public 级别，子类是 internal 级别。
    class Car : Vehicle
    {

    }

    // sealed 修饰的类，不能作为基类
    sealed class Vehicle2
    {

    }
}
