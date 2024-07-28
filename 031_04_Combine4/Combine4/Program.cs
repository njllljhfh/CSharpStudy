using System;
using System.Linq;
using Combine4.Models;

namespace Combine4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
            LINQ: .NET Language Integrated Query
                - 工作中 多用于 查询数据库
                - 类似于 ORM，把C#语法翻译成 sql 语法，然后去sql服务器执行，并返回查询结果的对象。
            */
            var dbContext = new AdvertureWorks2014Entities();
            var allPeople = dbContext.Person.ToList();
            foreach (var p in allPeople)
            {
                Console.WriteLine(p.FirstName);
            }
            Console.WriteLine("--------------------------------------------");


            // LINQ: 只选择 FirstName
            var allFirstName = dbContext.Person.Select(p=>p.FirstName).ToList();
            foreach (var fn in allFirstName)
            {
                Console.WriteLine(fn);
            }            
            Console.WriteLine("-------------");

            // LINQ: 全名
            var allFullName = dbContext.Person.Select(p => p.FirstName + " " + p.LastName).ToList();
            foreach (var fullName in allFullName)
            {
                Console.WriteLine(fullName);
            }
            Console.WriteLine("-------------");

            // LINQ: Where 条件
            var fullName2 = dbContext.Person.Where(p=>p.FirstName == "li").Select(p => p.FirstName + " " + p.LastName).ToList();
            foreach (var fullName in fullName2)
            {
                Console.WriteLine(fullName);
            }
            Console.WriteLine("-------------");

            // LINQ: 判断 是不是 所有 人都 姓 zhang
            var yesOrNo = dbContext.Person.All(p => p.FirstName == "zhang");
            Console.WriteLine(yesOrNo);
            Console.WriteLine("-------------");

            // LINQ: 判断 是不是 有人 姓 zhang
            yesOrNo = dbContext.Person.Any(p => p.FirstName == "zhang");
            Console.WriteLine(yesOrNo);
            Console.WriteLine("-------------");

            // LINQ: GroupBy
            var groups = dbContext.Person.GroupBy(p=>p.FirstName).ToList();
            foreach (var g in groups)
            {
                Console.WriteLine($"Name: {g.Key}, Count: {g.Count()}");
            }

            Console.WriteLine("-------------");

            // LINQ: Count
            var count = dbContext.Person.Count(p => p.FirstName == "zhang");
            Console.WriteLine($"count: {count}");
            Console.WriteLine("--------------------------------------------");
        }
    }
}