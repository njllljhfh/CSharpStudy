﻿using BabyStroller.SDK;
using System;


namespace Animals.Lib2
{
    public class Dog : IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Woof!");
            }
        }
    }
}
