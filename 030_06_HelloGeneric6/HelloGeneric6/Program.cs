using System;
// 泛型的类型，基类，基接口都集中在下面这个命名空间里
using System.Collections.Generic;

/*
内建的泛型类、泛型接口
*/

namespace HelloGeneric6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // List 相当于 java 中的 ArrayList
            // List 的底层维护者一个数组，当向List中添加数据超过数组长度时，底层会生成新的数组，并将旧数组中数据复制到新的数组中
            // List 的长度是可以改变的（又叫动态数组）
            IList<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------------");


            // 有多个泛型参数的 泛型接口、泛型类
            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict[1] = "Timothy";
            dict[2] = "Michael";
            Console.WriteLine($"Student 1 is {dict[1]}");
            Console.WriteLine($"Student 2 is {dict[2]}");
        }
    }
}