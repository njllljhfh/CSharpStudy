using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            什么是索引器
                - 索引器（indexer）是这样一种成员：它使对象能够用与数组相同的方式（即使用下标）进行检索
            

            一般情况下，拥有索引器的这种成员的数据类型，都是集合类型
            */
            // 平时开发几乎不会自己写索引器
            Console.WriteLine("索引器");
            Student stu = new Student();
            var mathScore = stu["Math"];
            Console.WriteLine($"mathScore = {mathScore}");
            Console.WriteLine(mathScore == null);
            Console.WriteLine("--------");

            stu["Math"] = 90;
            mathScore = stu["Math"];
            Console.WriteLine($"mathScore = {mathScore}");
            Console.WriteLine("--------------------------------");


            Console.WriteLine("常量");
            // 常量隶属于 类型 而不是对象，即没有“实例常量”
            //     - “实例常量”的角色由只读实例字段来担当
            const int x = 100;  // 局部常量
            Console.WriteLine(WASPEC.WebsiteURL);
            Console.WriteLine("--------------------------------");

        }

        static double GetArea(double r)
        {
            // Math.PI 是常量
            // 编译阶段 直接 将 Math.PI 用 常量替换掉，程序运行时不用去内存访问变量，直接用 3.14... 去运算，可以提高运算效率。
            double a = Math.PI * r * r;
            return a;
        }
    }

    class Student
    {
        private Dictionary<string,int> scoreDictionary = new Dictionary<string,int>();

        //索引器
        public int? this[string subject]  //返回 int? 可空类型
        {
            get { 
                if (this.scoreDictionary.ContainsKey(subject))
                {
                    return this.scoreDictionary[subject];
                }
                else 
                { 
                    return null; 
                }
            }
            set 
            {
                // value 是 可空类型 的变量
                if (value.HasValue == false)
                {
                    throw new Exception("Score cannot be null.");
                }

                if (this.scoreDictionary.ContainsKey(subject))
                {
                    this.scoreDictionary[subject] = value.Value;  // value变量 是赋进来的值
                }
                else
                {
                    this.scoreDictionary.Add(subject, value.Value);
                }
            }
        }
    }


    class WASPEC
    {
        // 成员常量
        public const string WebsiteURL = "http://www.waspec.org";  
    }
}
