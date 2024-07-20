using System;

namespace InterfaceExample3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 用接口来 使代码 松耦合
            var user = new PhoneUser(new NokiaPhone());
            user.UsePhone();
            Console.WriteLine("-------------------------------------");

            var user2 = new PhoneUser(new EricssonPhone());
            user2.UsePhone();
            Console.WriteLine("-------------------------------------");
        }
    }

    class PhoneUser
    {
        private IPhone _phone;
        public PhoneUser(IPhone phone)
        {
            _phone = phone;
        }
        public void UsePhone()
        {
            _phone.Dail();
            _phone.PickUp();
            _phone.Send();
            _phone.Receive();
        }
    }

    interface IPhone
    {
        void Dail();
        void PickUp();
        void Send();
        void Receive();
    }

    class NokiaPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Nokid calling...");
        }

        public void PickUp()
        {
            Console.WriteLine("Hello! This is Tim!");
        }

        public void Receive()
        {
            Console.WriteLine("Nokia message ring...");
        }

        public void Send()
        {
            Console.WriteLine("Hello!");
        }
    }

    class EricssonPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Ericsson calling...");
        }

        public void PickUp()
        {
            Console.WriteLine("Hello! This is Tim!");
        }

        public void Receive()
        {
            Console.WriteLine("Ericsson message ring...");
        }

        public void Send()
        {
            Console.WriteLine("Hello!");
        }
    }
}
