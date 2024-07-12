using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaticSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");  // WriteLine就是个静态方法
            Form form = new Form();
            form.Text = "Hello";
            form.ShowDialog();  //实例方法

            // 绑定（Binding）指的是编译器如何把一个 成员 与 类或者对象 关联起来
            // 早绑定：编译器在编译这个类的时候，已经知道 这个成员 是属于类 还是 属于类的对象
            // 晚绑定：运行时绑定，有由程序来决定（这是动态语言的特性）
        }
    }
}
