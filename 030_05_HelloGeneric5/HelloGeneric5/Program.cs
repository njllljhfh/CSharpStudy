namespace HelloGeneric5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Student<int> stu = new Student<int>();
            stu.ID = 101;
            stu.Name = "Timothy";
            Console.WriteLine($"stu.ID = {stu.ID}");
            Console.WriteLine($"stu.Name = {stu.Name}");
            Console.WriteLine("--------------------------------");

            Student<ulong> stu2 = new Student<ulong>();
            stu2.ID = 100000000000000001;
            stu2.Name = "Timothy2";
            Console.WriteLine($"stu2.ID = {stu2.ID}");
            Console.WriteLine($"stu2.Name = {stu2.Name}");
            Console.WriteLine("--------------------------------");

            Student2 stu3 = new Student2();
            stu3.ID = 100000000000000003;
            stu3.Name = "Timothy3";
            Console.WriteLine($"stu3.ID = {stu3.ID}");
            Console.WriteLine($"stu3.Name = {stu3.Name}");
            Console.WriteLine("--------------------------------");
        }
    }

    // 泛型接口
    interface IUnique<TId>
    {
        TId ID { get; set; }
    }

    // 一个类实现的是 泛型接口，那么这个类 也变成了泛型类
    // TId 只会影响到 ID 这个属性的类型
    class Student<TId> : IUnique<TId>
    {
        public TId ID { get; set; }
        public string Name { get; set; }
    }
    
    
    // IUnique<ulong> 是 特化后的泛型接口
    // 一个类实现的是 特化后的泛型接口，那么这个类 不是泛型类
    class Student2 : IUnique<ulong>
    {
        public ulong ID { get; set; }
        public string Name { get; set; }
    } 
}