// See https://aka.ms/new-console-template for more information

using System;
using System.Security.Cryptography;

/*
不好的例子3，没有使用泛型，使用了 object 类型的成员，导致Main中无法直接访问 object成员 的实际类的属性
*/
namespace HelloGeneric3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Apple apple = new Apple() { Color = "Red" };
            Book book = new Book() { Name = "New Book" };
            Box box1 = new Box() { Cargo = apple };
            Box box2 = new Box() { Cargo = book };
            // 无法直接访问 Apple 的 Color 属性，需要进行类型转换后，才能访问
            Console.WriteLine((box1.Cargo as Apple)?.Color);
            Console.WriteLine((box2.Cargo as Apple)?.Color);
        }
    }

    class Apple
    {
        public string Color { get; set; }
    }

    class Book
    {
        public string Name { get; set; }
    }

    class Box
    {
        public object Cargo { get; set; }
    }
}