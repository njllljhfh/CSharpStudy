using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 操作符不能脱离与它相关联的操作类型
            int x = 5;
            int y = 4;
            int z = x / y;  
            Console.WriteLine(z);  // 1

            double a = 5;
            double b = 4;
            double c = a / b;
            Console.WriteLine(c);  // 1.25
            Console.WriteLine("-----------------------");

            // 操作符的本质是函数（即算法）的“简记法”。
            Person person1 = new Person();
            Person person2 = new Person();
            person1.Name = "Deer";
            person2.Name = "Deer's wife";
            //List<Person> nation = Person.GetMarry(person1, person2);    
            List<Person> nation = person1 + person2;    
            foreach (var p in nation) 
            { 
                Console.WriteLine(p.Name);
            }
            Console.WriteLine("-----------------------");

            /*
            同优先级操作符
                - 除了带有赋值功能的操作符，同优先级操作符都是由左向右进行运算
                - 带有赋值功能的操作符的运算顺序是由右向左
                - 与数学运算不同，计算机语言的同优先级运算没有“结合律”
                    - 3+4+5 编译器只能理解为Add(Add(3,4),5) 不能理解为 Add(3,Add(4,5))
            */
            int x2;
            x2 = 3 + 4 + 5;
            Console.WriteLine(x2);

            int x3 = 100;
            int y3 = 200;
            int z3 = 300;
            x3 += y3 += z3;  //+= 是 带有赋值功能的操作符
            Console.WriteLine(x3);  // 600
            Console.WriteLine(y3);  // 500
            Console.WriteLine(z3);  // 300
            Console.WriteLine("-----------------------");
        }
    }

    class Person
    {
        public string Name;

        //public static List<Person> GetMarry(Person p1, Person p2)
        public static List<Person> operator+(Person p1, Person p2)
        {
            List<Person> people = new List<Person>();
            people.Add(p1);
            people.Add(p2);
            for (int i = 0;i<11;i++)
            {
                Person child = new Person();
                child.Name = p1.Name + "&" + p2.Name + "'s chidl" + i;
                people.Add(child);
            }

            return people;
        }
    }
}
