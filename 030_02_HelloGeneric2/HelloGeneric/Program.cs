// See https://aka.ms/new-console-template for more information

using System;
using System.Security.Cryptography;

/*
不好的例子2，没有使用泛型，导致的 成员膨胀
*/
namespace HelloGeneric2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Apple apple = new Apple() { Color = "Red" };
            Book book = new Book() { Name = "New Book" };
            Box box1 = new Box() { Apple = apple };
            Box box2 = new Box() { Book = book };
            Console.WriteLine($"box1.Apple.Color = {box1.Apple.Color}");
            Console.WriteLine($"box2.Book.Name = {box2.Book.Name}");
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
        public Apple Apple { get; set; }
        public Book Book { get; set; }
        // 其他商品...
    }
}