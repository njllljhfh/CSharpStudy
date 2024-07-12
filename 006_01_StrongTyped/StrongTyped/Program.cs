using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// c# 是强类型语言
namespace StrongTyped
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 32 位
            int x;
            x = 100;

            // 64 位
            long y;
            y = 100L;

            //x = 100L; // 编译报错
            // -----------------------------------


            bool b;
            b = true;
            b = false;
            //b = 100;  // 编译报错
            // -----------------------------------


            int x2 = 100;
            if (x == 200)
            {
                Console.WriteLine("It's OK!");
            }
            // -----------------------------------

            // dynamic 模仿动态语言的 特性（例如，js）
            // 多用于跟底层数据打交道
            dynamic myVar = 100;
            Console.WriteLine(myVar);
            myVar = "Mr. Okay!";
            Console.WriteLine(myVar);
            Console.WriteLine("-----------------------------------");


            // 初步认识 反射
            Console.WriteLine("初步认识 反射");
            Type myType = typeof(Form);
            Console.WriteLine(myType.Name);
            Console.WriteLine(myType.FullName);
            Console.WriteLine(myType.BaseType.FullName);
            Console.WriteLine(myType.BaseType.BaseType.FullName);
            Console.WriteLine("------");
            
            Console.WriteLine("GetProperties() 动态获取属性");
            PropertyInfo[] pinfos = myType.GetProperties();
            foreach (var p in pinfos) 
            { 
                Console.WriteLine(p.Name);
            }
            Console.WriteLine("------");

            Console.WriteLine("GetMethods() 动态获取方法");
            MethodInfo[] minfos = myType.GetMethods();
            foreach (var m in minfos)
            {
                Console.WriteLine(m.Name);
            }
            Console.WriteLine("-----------------------------------");


            double result = 3.0 / 4.0;
            Console.WriteLine(result); // 0.75

            double result2 = 3 / 4;
            Console.WriteLine(result2);  // 0
            Console.WriteLine("-----------------------------------");
        }
    }
}
