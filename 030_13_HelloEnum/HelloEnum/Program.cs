namespace HelloEnum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person();
            person.Level = Level.Employee;

            Person boss = new Person();
            boss.Level = Level.Boss;

            Console.WriteLine(boss.Level > person.Level);
            Console.WriteLine("--------------------------------");


            Console.WriteLine((int)Level.Employee);  // 要获得枚举的int值，需要类型转换。否则打印的是名字
            Console.WriteLine((int)Level.Manager);
            Console.WriteLine((int)Level.Boss);
            Console.WriteLine((int)Level.BigBoss);
            Console.WriteLine("---------------------------------");

            // 枚举的比特位用法
            Person person2 = new Person();
            person2.Level = Level.Employee;
            person2.Name = "Timothy";
            person2.Skill = Skill.Drive | Skill.Cook | Skill.Program | Skill.Teach;
            Console.WriteLine(person2.Skill);
            Console.WriteLine($"{person2.Name} 是否会开车？ --- {(person2.Skill & Skill.Drive) == Skill.Drive}");
            Console.WriteLine($"{person2.Name} 是否会做饭？ --- {(person2.Skill & Skill.Cook) == Skill.Cook}");
            Console.WriteLine($"{person2.Name} 是否会编程？ --- {(person2.Skill & Skill.Program) == Skill.Program}");
            Console.WriteLine($"{person2.Name} 是否会教书？ --- {(person2.Skill & Skill.Teach) == Skill.Teach}");
            Console.WriteLine("---------------------------------");
        }
    }

    // 枚举值默认从 0 开始递增
    enum Level
    {
        Employee = 100,
        Manager,
        Boss = 300,
        BigBoss,
    }

    // 枚举的比特位用法
    enum Skill
    {
        Drive = 1,
        Cook = 2,
        Program = 4,
        Teach = 8,
    }

    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; }
        public Skill Skill { get; set; }
    }


}