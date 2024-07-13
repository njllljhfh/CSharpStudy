using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    /*
    委托，是函数指针的“升级版” 
    
    
    委托的声明
        - 委托是一种类（class），类是数据类型，所以委托也是一种数据类型。
        - 它的声明方式与一般的类不同
        - 注意声明委托的位置
            - 避免写错地方，结果声明成了嵌套类型
        - 委托与所封装的方法必须"类型兼容"


    委托的一般使用
    把方法当做参数传递给另一个方法
        - 正确使用1：模板方法，"借用"指定的外部方法来产生结果
            - 相当于"填空题"
            - 长位于代码中部
            - 委托有返回值
        - 正确使用2：回调（callback）方法，调用指定的外部方法
            - 相当于"流水线"
            - 常位于代码尾部
            - 委托无返回值
    
    
    注意：难精通 + 易使用 + 功能强大 的东西，一旦被滥用则后果非常严重
        - 缺点1：这是一种方法级别的紧耦合，现实工作中要慎之又慎
        - 缺点2：使可读性下降、debug的难度增加
        - 缺点3：把委托回调、异步调用和多线程纠缠在一起，会让代码变得难以阅读和维护
        - 缺点4：委托使用不当可能造成内存泄漏和程序性能下降
    */
    // 声明自定义的 委托类型
    public delegate double Calc(double x, double y);

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Action 委托");
            // Action 只接收没有返回值的方法
            Type t = typeof(Action);
            Console.WriteLine($"Action 是 class 吗？ --- {t.IsClass}");
            Calculator calculator = new Calculator();
            // 此处 Action 接收 参数列表为空，返回值为void 的方法。
            Action action = new Action(calculator.Report);
            calculator.Report();  //直接调用
            action.Invoke();  //间接调用
            action();  //间接调用：简便写法
            Console.WriteLine("-------------------------------------");


            Console.WriteLine("Func 委托");
            // Func 只接收有返回值的方法
            // Func<int, int, int>：表示这里接收 输入参数为 两个 int 类型，返回参数为int类型的方法。
            Func<int, int, int> func1 = new Func<int, int, int>(calculator.Add);
            Func<int, int, int> func2 = new Func<int, int, int>(calculator.Sub);
            t = typeof(Func<int, int, int>);
            Console.WriteLine($"Func<int, int, int> 是 class 吗？ --- {t.IsClass}");

            int x = 100;
            int y = 200;
            int z = 0;

            z = func1.Invoke(x, y);  //间接调用
            Console.WriteLine($"z = {z}");
            z = func2(x, y);  //间接调用：简便写法
            Console.WriteLine($"z = {z}");
            Console.WriteLine("-------------------------------------");


            Console.WriteLine("自定义 委托");
            Calculator2 calculator2 = new Calculator2();
            Calc calc1 = new Calc(calculator2.Add);
            Calc calc2 = new Calc(calculator2.Sub);
            Calc calc3 = new Calc(calculator2.Mul); ;
            Calc calc4 = new Calc(calculator2.Div);

            double a = 100;
            double b = 200;
            double c = 0;

            c = calc1.Invoke(a, b);  //间接调用
            Console.WriteLine($"c = {c}");
            c = calc2.Invoke(a, b);
            Console.WriteLine($"c = {c}");
            c = calc3(a, b);  //间接调用：简便写法
            Console.WriteLine($"c = {c}");
            c = calc4(a, b);
            Console.WriteLine($"c = {c}");
            Console.WriteLine("-------------------------------------");


            Console.WriteLine("委托 --- 模板方法、回调（callback）方法");
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();
            wrapFactory.Name = "打包工厂";
            Func<Product> func3 = new Func<Product>(productFactory.MakePizza);  // 委托 --- 模板方法
            Func<Product> func4 = new Func<Product>(productFactory.MakeToyCar);  // 委托 --- 模板方法

            Logger logger = new Logger();
            // Action<Product>: 表示接收 一个参数类型为Product，另一个参数类型为String 并且无返回值的 方法
            Action<Product, string> log = new Action<Product, string>(logger.Log);  // 委托 --- 回调（callback）方法

            Box box1 = wrapFactory.WrapProduct(func3, log);
            Box box2 = wrapFactory.WrapProduct(func4, log);
            Console.WriteLine($"box1.Product.Name = {box1.Product.Name}");
            Console.WriteLine($"box2.Product.Name = {box2.Product.Name}");
            Console.WriteLine("-------------------------------------");
        }
    }

    class Calculator
    {
        public void Report()
        {
            Console.WriteLine("I have 3 methods");
        }

        public int Add(int a, int b)
        {
            int result = a + b;
            return result;
        }

        public int Sub(int a, int b)
        {
            int result = a - b;
            return result;
        }
    }


    class Calculator2
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Sub(double a, double b)
        {
            return a - b;
        }

        public double Mul(double a, double b)
        {
            return a * b;
        }

        public double Div(double a, double b)
        {
            return a / b;
        }
    }

    class Logger
    {
        public void Log(Product product, string info)
        {
            Console.WriteLine($"logging[{info}]: Product '{product.Name}' created at {DateTime.UtcNow}. Price is {product.Price}.");
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
        public string Name { get; set; }

        // Func<Product> 委托：此处接收一个无参数，返回值为 Product 类型的 方法
        // Action<Product> 委托: 此处接收 一个参数类型为Product，另一个参数类型为String 并且无返回值的 方法，用于回调
        public Box WrapProduct(Func<Product> getProduct, Action<Product, string> logCallback)
        {
            Box box = new Box();
            Product product = getProduct.Invoke();

            if (product.Price >= 50)
            {
                logCallback(product, this.Name);
            }
            box.Product = product;
            return box;
        }
    }

    // 工厂方法
    class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 12;
            return product;
        }

        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            product.Price = 100;
            return product;
        }
    }
}
