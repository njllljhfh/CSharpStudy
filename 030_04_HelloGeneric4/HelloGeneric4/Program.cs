// See https://aka.ms/new-console-template for more information

using System;
using System.Security.Cryptography;


namespace HelloGeneric4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Apple apple = new Apple() { Color = "Red" };
            Book book = new Book() { Name = "New Book" };
            Box<Apple> box1 = new Box<Apple>() { Cargo = apple };
            Box<Book> box2 = new Box<Book>() { Cargo = book };
            Console.WriteLine(box1.Cargo.Color);
            Console.WriteLine(box2.Cargo.Name);
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

    // 泛型类：尖括号内是 类型参数
    // 泛型实体不能用来直接编程，编程前先要多泛型实体进行 特化。
    class Box<TCargo>
    {
        public TCargo Cargo { get; set; }
    }
}