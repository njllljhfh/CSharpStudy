using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 解耦合的例子
// 工作中应该避免这样写代码
namespace InterfaceExample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            var car = new Car(engine);
            car.Run(3);
            Console.WriteLine($"car.Spead = {car.Spead}");
        }
    }

    class Engine
    {
        public int RPM { get; private set; }

        public void Work(int gas)
        {
            this.RPM = 1000 * gas;
        }
    }

    class Car
    {
        private Engine _engine;

        public Car(Engine engine)
        {
            _engine = engine;
        }

        public int Spead { get; private set; }
        public void Run(int gas)
        {
            _engine.Work(gas);
            this.Spead = _engine.RPM / 100;
        }
    }
}
