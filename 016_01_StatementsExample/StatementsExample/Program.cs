using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StatementsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("while 循环");
            //int score = 0;
            //bool canContinue = true;
            //while (canContinue)
            //{
            //    Console.WriteLine("Please input first number:");
            //    string str1 = Console.ReadLine();
            //    int x = int.Parse(str1);

            //    Console.WriteLine("Please input second number:");
            //    string str2 = Console.ReadLine();
            //    int y = int.Parse(str2);

            //    int sum = x + y;
            //    if(sum == 100)
            //    {
            //        score++;
            //        Console.WriteLine("Correct! {0}+{1}={2}",x,y,sum);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Error! {0}+{1}={2}", x, y, sum);
            //        canContinue=false;  
            //    }
            //}
            //Console.WriteLine("Your score is {0}",score);
            //Console.WriteLine("GAME OVER");
            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("do while 循环");
            //int score = 0;
            //int sum = 100;
            //// do语句 循环体至少执行一次
            //do
            //{
            //    Console.WriteLine("Please input first number:");
            //    string str1 = Console.ReadLine();
            //    if (str1.ToLower() =="end")
            //    {
            //        break;
            //    }

            //    int x = 0;
            //    try
            //    {
            //        x = int.Parse(str1);
            //    }
            //    catch
            //    {
            //        Console.WriteLine("First number has problem! Restart.");
            //        continue;
            //    }

            //    Console.WriteLine("Please input second number:");
            //    string str2 = Console.ReadLine();
            //    if (str2.ToLower() == "end")
            //    {
            //        break;
            //    }

            //    int y = 0;
            //    try
            //    {
            //        y = int.Parse(str2);
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Sceond number has problem! Restart.");
            //        continue;
            //    }

            //    sum = x + y;
            //    if (sum == 100)
            //    {
            //        score++;
            //        Console.WriteLine("Correct! {0}+{1}={2}", x, y, sum);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Error! {0}+{1}={2}", x, y, sum);
            //    }
            //} while (sum == 100);
            //Console.WriteLine("Your score is {0}", score);
            //Console.WriteLine("GAME OVER");
            Console.WriteLine("-------------------------------------------");


            Console.WriteLine("for 循环");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------------------------------");


            Console.WriteLine("for 循环 乘法表");
            for(int a = 1;a <= 9; a++)
            {
                for(int b = 1;b <= a; b++)
                {
                    Console.Write($"{a}*{b}={b}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------");


            Console.WriteLine("集合遍历");
            int[] intArray = { 1, 2, 3, 4, 5, 6};
            Console.WriteLine(intArray.GetType().FullName);
            // C# 中所有的数组，基类都是 Array 类
            // C# 所有实现了 IEnumerable 接口的类 就是可以被遍历的集合
            //     IEnumerable 只有一个接口 GetEnumerator() 获取迭代器
            Console.WriteLine(intArray is Array);

            // List 也实现了 IEnumerable 接口
            List<int> intList = new List<int>() { 1,2,3 };
            Console.WriteLine("-----");


            // IEnumerator 迭代器接口
            IEnumerator enumerator = intArray.GetEnumerator(); //获取迭代器
            Console.WriteLine("遍历 数组");
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine("-----");

            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine("-----");


            Console.WriteLine("遍历 List");
            enumerator = intList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine("-----");

            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine("-------------------------------------------");


            Console.WriteLine("foreach 遍历");  // 最佳应用场合：对集合进行遍历
            // foreach 是 集合迭代器遍历的简化
            foreach (var item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------------------");
        }
    }
}
