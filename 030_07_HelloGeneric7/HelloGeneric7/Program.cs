using System;
using System.IO.Compression;

namespace HelloGeneric7 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a1 = { 1, 2, 3, 4, 5 };
            int[] a2 = { 1, 2, 3, 4, 5, 6 };
            double[] a3 = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            double[] a4 = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6 };
            
            // 没有对 泛型方法 进行显示的特化（泛型方法，在被调用时，类型参数会自动推断）
            var result = Zip(a1, a2);
            Console.WriteLine(string.Join(",", result));
            
            var result2 = Zip(a3, a4);
            Console.WriteLine(string.Join(",", result2));
        }

        // 泛型方法
        static T[] Zip<T>(T[] a, T[] b)
        {
            T[] zipped = new T[a.Length + b.Length];
            int ai = 0, bi = 0, zi = 0;
            do
            {
                if (ai < a.Length) zipped[zi++] = a[ai++];
                if (bi < b.Length) zipped[zi++] = b[bi++];
            } while (ai < a.Length || bi < b.Length);

            return zipped;
        }
    }
}