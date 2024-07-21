using System;


namespace IspExample3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wk = new WarmKiller();
            wk.Love();
            //wk.Kill(); // 无法调用 显示实现的接口
            Console.WriteLine("--------------------------------");

            IKiller killer = new WarmKiller();
            killer.Kill(); // 调用 显示实现的接口

            var wk2 = killer as WarmKiller;
            wk.Love();

            var wk3 = (WarmKiller)killer;  // 强制类型转换
            wk3.Love();

            var wk4 = (IGentleMan)killer;  // 强制类型转换
            wk4.Love();
            Console.WriteLine("--------------------------------");
        }
    }

    interface IGentleMan
    {
        void Love();
    }

    interface IKiller
    {
        void Kill();
    }


    class WarmKiller : IGentleMan, IKiller
    {

        public void Love()
        {
            Console.WriteLine("I will love you for every...");
        }

        //显示实现接口
        //  - 当用 IKiller 类型的变量 引用 WarmKiller 类的对象时 Kill() 方法才能被调用。
        void IKiller.Kill()
        {
            Console.WriteLine("Let me kill the enemy...");
        }
    }
}
