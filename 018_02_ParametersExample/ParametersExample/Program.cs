using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ParametersExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 这么写 语法比较啰嗦，要先声明并初始化一个数组
            int[] myIntArray = new int[] { 1, 2, 3 };
            int result = CalculateSum(myIntArray);
            Console.WriteLine($"result = {result}");
            Console.WriteLine("------------------------------");


            /*
            数组参数
                - 一个方法的参数列表中，只能有一个 参数是 数组参数，并且必须是形参列表中的最后一个，由 params 修饰
                - 举例：String.Format方法 和 String.Split方法
            */
            Console.WriteLine("数组参数");
            int result2 = CalculateSum(1, 2, 3);
            Console.WriteLine($"result2 = {result2}"); // Console.WriteLine的重载方法中，也有 数组参数
            Console.WriteLine("------------------------------");


            Console.WriteLine("数组参数");
            string str = "Tim;Tom,Amy.Lisa";
            string[] result3 = str.Split(';', ',', '.');
            foreach( string s in result3)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("------------------------------");


            // 具名参数
            Console.WriteLine("具名参数");
            PrintInfo(age: 34, name:"Tim");
            Console.WriteLine("------------------------------");


            /*
            可选参数
                - 参数因为具有默认值而变得“可选”
                - 不推荐使用可选参数
            */
            Console.WriteLine("可选参数");
            PrintInfo2();
            Console.WriteLine("------------------------------");


            Console.WriteLine("扩展方法");
            double x = 3.14159;
            //double y = Math.Round(x,4);
            double y = x.Round(4); // x 会 作为 this 参数传递给扩展方法 round
            Console.WriteLine($"y = {y}");
            Console.WriteLine("------------------------------");


            Console.WriteLine("LINQ 方法");
            List<int> myList = new List<int>() { 11, 12, 13, 14, 15 };
            //bool result4 = AllGreaterThanTen(myList);
            //LINQ 方法
            bool result4 = myList.All(i => i > 10);  // All 是扩展方法
            Console.WriteLine($"result4 = {result4}");
            Console.WriteLine("------------------------------");
        }

        static int CalculateSum(params int[] intArray)
        {
            int sum = 0;
            foreach (var item in intArray)
            {
                sum += item;
            }
            return sum;
        }


        static void PrintInfo(string name, int age)
        {
            Console.WriteLine($"Hello {name}, you are {age}");
        }


        //可选参数
        static void PrintInfo2(string name="Time2", int age=34)
        {
            Console.WriteLine($"Hello {name}, you are {age}");
        }


        static bool AllGreaterThanTen(List<int> intList)
        {
            foreach (var item in intList)
            {
                if (item <= 10)
                {
                    return false;
                }
            }
            return true;
        }
    }


    // 扩展方法，声明静态类。扩展方法 必须在顶级静态类中定义。
    // 扩展方法必须是公有、静态的，即被 public static 修饰。
    // this 修饰符, 修饰的必须是第一个参数。
    // 约定：当要扩展一个类名为 SomeType 的类时，扩展方法的静态类一般命名为 SomeTypeExtension
    // 当我们没有办法去修改源码的时候，我们可以用扩展方法，来追加方法！！！
    // C#中很多功能都是基于扩展方法的： 如 LINQ 方法。
    static class DoubleExtension  // 这个类名随便叫什么都行
    {
        public static double Round(this double input, int digits)
        {
            double result = Math.Round(input, digits);
            return result;
        }
    }
}


