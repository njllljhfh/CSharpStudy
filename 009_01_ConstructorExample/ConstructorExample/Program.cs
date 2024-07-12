using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
栈的内存分配，是从栈底向栈顶逐渐分配内存，栈底的内存地址 大于 栈顶的内存地址

注意：要好好理解对象在创建过程中，内存的分配（看视频）
https://www.bilibili.com/video/BV13b411b7Ht/?p=9&spm_id_from=pageDriver&vd_source=d5456c77ecfc61e7372a8a02b7e73d29
 */

namespace ConstructorExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //没有自定义构造函数，使用默认构造函数
            Student stu = new Student();
            Console.WriteLine(stu.Name==null); //True
            Console.WriteLine("-------------------------");


            //构造函数-无参数
            Student2 stu2 = new Student2();
            Console.WriteLine(stu2.ID);
            Console.WriteLine(stu2.Name);
            Console.WriteLine("-------------------------");


            //构造函数-有参数
            Student3 stu3 = new Student3(2, "Mr.Okay");
            Console.WriteLine(stu3.ID);
            Console.WriteLine(stu3.Name);
            Console.WriteLine("-------");
            //构造函数-无参数
            Student3 stu4 = new Student3();
            Console.WriteLine(stu4.ID);
            Console.WriteLine(stu4.Name);
            Console.WriteLine("-------------------------");
        }
    }

    class Student 
    {
        //如果没有定义构造器，类会用默认构造器
        public int ID;  // int 是值类型
        public string Name;  // string 是引用类型
    }

    class Student2
    {
        //构造函数-无参数
        public Student2() 
        {
            this.ID = 1;
            this.Name = "No name";
        }
        public int ID;
        public string Name;
    }

    class Student3
    {
        //构造函数-有参数
        public Student3(int initID,string initName)
        {
            this.ID = initID;
            this.Name = initName;
        }

        public Student3()
        {
            this.ID = 1;
            this.Name = "No name";
        }

        public int ID;
        public string Name;
    }
}
