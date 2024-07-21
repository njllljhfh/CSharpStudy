using BabyStroller.SDK;
using System;
using System.IO;
using System.Runtime.Loader;

/*
模拟程序主体开发商，与 第三方开发者（如插件开发者）的 协作方式。
    - 主体开发商，在开发主体程序时，要留出响应功能的接口，并在 SDK 中封装好各个接口相关的抽象，主体程序要引用SDK。将编译后的SDK的 .dll 文件以及SDK的使用说明书提供给第三方开发人员。
    - 第三方开发人员，写代码时，要在项目中引用 SDK，并按照SDK中的接口进行开发。
*/

namespace BabyStroller.App // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            主体程序，利用反射来加载插件，并且拿到动物类、创建实例、调用方法
            */
            var folder = Path.Combine(Environment.CurrentDirectory, "Animals");
            var files = Directory.GetFiles(folder);
            var animalTypes = new List<Type>();
            foreach (var file in files)
            {
                Console.WriteLine($"file = {file}");
                // 获取文件（这里是.dll文件）提供的程序集
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    // 没有 用SDK之前的 写法------------------------
                    // 添加所有包含 Voice 方法的 类型 到 animalTypes 列表中
                    //if (t.GetMethod("Voice") != null)
                    //{
                    //    animalTypes.Add(t);
                    //}
                    //--------------------------------------------------

                    // 使用 SDK 后的写法---------------------------------
                    // 添加符合要求，并且已经开发完的类 到 imalTypes 列表中
                    // 判断 t 类型的 基接口中 包含 IAnimal 接口
                    if (t.GetInterfaces().Contains(typeof(IAnimal)))
                    {
                        // 并且 t 类型 不包含 UnfinishedAttribute 标记
                        //var isUnfinished = !t.GetCustomAttributes(true).Contains(typeof(UnfinishedAttribute)); // 这行代码有问题：全是true
                        var isUnfinished = t.GetCustomAttributes(false).Any(a => a.GetType() == typeof(UnfinishedAttribute)); 
                        //Console.WriteLine($"isUnfinished = {isUnfinished}");
                        if (isUnfinished)
                        {
                            continue;
                        }
                        animalTypes.Add(t);
                    }
                }
            }

            while (true)
            {
                for (int i = 0; i < animalTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {animalTypes[i].Name}");
                }
                Console.WriteLine("======================");
                Console.WriteLine("Please choose animal:");
                int index = int.Parse(Console.ReadLine());
                if (index > animalTypes.Count || index < 1)
                {
                    Console.WriteLine("No such an animal. Try again!");
                    continue;
                }

                Console.WriteLine("How many times?");
                int times = int.Parse(Console.ReadLine()); // 小动物要叫多少次
                var t = animalTypes[index - 1];
                var m = t.GetMethod("Voice");
                var o = Activator.CreateInstance(t);
                // 没有 用SDK之前的 写法------------------------
                // 这是一种弱类型的 调用方式
                //m.Invoke(o, new object[] { times });  // 调用 Voice，object[] 是参数列表
                //---------------------------------------------

                // 使用 SDK 后的写法---------------------------------
                var a = o as IAnimal;
                a.Voice(times);
                Console.WriteLine("----------------");
            }
        }
    }
}