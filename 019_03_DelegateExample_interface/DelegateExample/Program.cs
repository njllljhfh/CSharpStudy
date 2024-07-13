using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 用接口，代替了之前的 Func委托
            IProductFactory pizzaFactory = new Pizzafactory();
            IProductFactory toyCarFactory = new ToyCarFactory();
            WrapFactory wrapFactory = new WrapFactory();

            Logger logger = new Logger();
            Action<Product> log = new Action<Product>(logger.Log);  // 委托 --- 回调（callback）方法

            Box box1 = wrapFactory.WrapProduct(pizzaFactory, log);
            Box box2 = wrapFactory.WrapProduct(toyCarFactory, log);

            Console.WriteLine($"box1.Product.Name = {box1.Product.Name}");
            Console.WriteLine($"box2.Product.Name = {box2.Product.Name}");
            Console.WriteLine("-------------------------------------");
        }
    }

    // 接口：产品工厂
    interface IProductFactory
    {
        Product Make();
    }

    class Pizzafactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 12;
            return product;
        }
    }

    class ToyCarFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            product.Price = 100;
            return product;
        }
    }

    class Logger
    {
        public void Log(Product product)
        {
            Console.WriteLine($"logging: Product '{product.Name}' created at {DateTime.UtcNow}. Price is {product.Price}.");
        }
    }

    //产品类
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    //打包盒类
    class Box
    {
        public Product Product { get; set; }
    }

    //打包工厂
    class WrapFactory
    {
        public Box WrapProduct(IProductFactory productFactory, Action<Product> logCallback)
        {
            Box box = new Box();
            Product product = productFactory.Make();

            if (product.Price >= 50)
            {
                logCallback(product);
            }
            box.Product = product;
            return box;
        }
    }
}
