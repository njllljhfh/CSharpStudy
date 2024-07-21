// See https://aka.ms/new-console-template for more information

using System;
using System.Security.Cryptography;

/*
不好的例子1，没有使用泛型，导致的 类型膨胀
*/
namespace HelloGeneric
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Apple apple = new Apple() { Color = "Red" };
            AppleBox box = new AppleBox() { Cargo = apple };
            Console.WriteLine($"box.Cargo.Color = {box.Cargo.Color}");
            Book book = new Book() { Name = "New Book" };
            BookBox bookbox = new BookBox() { Cargo = book };
            Console.WriteLine($"bookbox.Cargo.Name = {bookbox.Cargo.Name}");
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

    class AppleBox
    {
        public Apple Cargo { get; set; }
    }

    class BookBox
    {
        public Book Cargo { get; set; }
    }
}