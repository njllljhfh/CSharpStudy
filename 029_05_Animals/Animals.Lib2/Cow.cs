using BabyStroller.SDK;
using System;


namespace Animals.Lib2
{
    // 假设牛的类没有开发完成，用 Unfinished 进行标记
    [Unfinished]
    public class Cow : IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Moo!");
            }
        }
    }
}
