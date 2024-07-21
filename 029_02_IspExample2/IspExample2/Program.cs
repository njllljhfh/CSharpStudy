using System;
using System.Collections;


namespace IspExample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = {1,2,3,4,5};
            ArrayList nums2 = new ArrayList { 1,2,3,4,5 };
            Console.WriteLine(Sum(nums1));
            Console.WriteLine(Sum(nums2));
            Console.WriteLine("-------------------------------");

            Console.WriteLine("自定义只读的集合类");
            var num3 = new ReadOnlyCollection(nums1);
            //foreach 通过 getEnumerator() 获取 迭代器，然后进行迭代
            foreach (var n in num3)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("-------------------------------");

            Console.WriteLine(Sum(num3));
            Console.WriteLine("-------------------------------");

        }

        // ICollection 接口对于Sum()方法的逻辑来说，太重了，它继承了IEnumerable接口，同时还定义了它自己的功能接口（这些接口在Sum()方法中用不到）。
        //     - 使得 num3 无法作为参数传递给 Sum() 方法。 
        //     - Sum()方法的逻辑中，只用得到迭代，其他功能不需要
        //static int Sum(ICollection nums)
        static int Sum(IEnumerable nums)  // 接口隔离：使用颗粒度更小的 IEnumerable 接口
        {
            int sum = 0;
            foreach (int n in nums)
            {
                sum += n;
            }
            return sum;
        }

        // 自定义只读的集合类
        class ReadOnlyCollection : IEnumerable
        {
            private int[] _array;

            // 构造器
            public ReadOnlyCollection(int[] array)
            {
                _array = array;
            }

            // IEnumerable 接口中定义的 方法
            public IEnumerator GetEnumerator()
            {
                return new Enumerator(this);
            }

            // 成员类
            public class Enumerator : IEnumerator  // 实现 迭代器接口
            {
                private ReadOnlyCollection _collection;
                private int _head;

                // 构造器
                public Enumerator(ReadOnlyCollection collection)
                {
                    _collection = collection;
                    _head = -1;
                }

                //IEnumerator 接口中定义的 只读属性
                public object Current
                {
                    get
                    {
                        // 装箱（以前的课程讲过，忘记了的话，去复习）
                        object o = _collection._array[_head]; 
                        return o;
                    }
                }

                //IEnumerator 接口中定义的 方法
                public bool MoveNext()
                {
                    if (++_head < _collection._array.Length)
                    {
                        return true;
                    }else
                    {
                        return false;
                    }
                }

                //IEnumerator 接口中定义的 方法
                public void Reset()
                {
                    _head = -1; // 查看 IEnumerator 接口中 Reset()方法的描述
                }
            }
        }
    }
}
