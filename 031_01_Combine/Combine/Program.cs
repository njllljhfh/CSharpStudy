namespace Combine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // dele1 这个变量引用着一个MyDele类型的实例，这个实例里“包裹”着 M1 这个方法。
            MyDele dele1 = new MyDele(M1);
            dele1.Invoke();
            Console.WriteLine("-------------------------------");


            // 委托，可以包裹多个函数（多播委托）
            Console.WriteLine("多播委托");
            Student stu = new Student();
            dele1 += M1;
            dele1 += stu.SayHello;
            //dele1.Invoke();
            dele1();
            Console.WriteLine("-------------------------------");


            MyDele2 dele2 = new MyDele2(Add);
            int res = dele2(100, 200);
            Console.WriteLine($"res = {res}");
            Console.WriteLine("-------------------------------");
        }

        static void M1()
        {
            Console.WriteLine("M1 is called ");
        }

        static int Add(int x, int y)
        {
            return x + y;
        }
    }

    class Student
    {
        public void SayHello()
        {
            Console.WriteLine("Hello, I'm a student!");
        }
    }

    // 委托是一种类类型，所以委托也是引用类型
    // 声明委托
    delegate void MyDele();

    delegate int MyDele2(int a, int b);
}