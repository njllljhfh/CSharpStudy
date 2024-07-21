using BabyStroller.SDK;
using System;


namespace Animals.Lib
{
    // 假设猫的类没有开发完成，用 Unfinished 进行标记
    [Unfinished]  // Attribute: 反射时，用于识别这个类是否有某个 Attribute 标记，从而判断后续要执行的逻辑
    public class Cat : IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Meow!");
            }
        }
    }
}
