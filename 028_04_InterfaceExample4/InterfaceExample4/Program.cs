using System;

namespace InterfaceExample4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fan = new DeskFan(new PowerSupply());
            Console.WriteLine(fan.Work());
        }
    }

    public interface IPowerSupply
    {
        int GetPower();
    }

    //电源
    public class PowerSupply : IPowerSupply
    {
        public int GetPower()
        {
            return 110;
        }
    }

    //电扇
    public class DeskFan
    {
        private IPowerSupply _powerSupply;
        public DeskFan(IPowerSupply powerSupply)
        {
            _powerSupply = powerSupply;
        }
        public string Work()
        {
            int power = _powerSupply.GetPower();
            if (power == 0)
            {
                return "Won't work.";
            }
            else if (power < 100)
            {
                return "Slow";
            }
            else if (power < 200)
            {
                return "Work fine";
            }
            else
            {
                return "Warning!";
            }
        }
    }
}
