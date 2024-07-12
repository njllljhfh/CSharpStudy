using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressionExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("元素访问");
            List<int> intList = new List<int>() { 1, 2, 3 };
            var x1 = intList[1];
            Console.WriteLine(x1.GetType());  // 获取数据类型
            double[] doubleArray = new double[] { 1.0, 2.0, 3.0 };
            var x2 = doubleArray[1];
            Console.WriteLine(x2.GetType());
            Console.WriteLine("--------------------------");


            //可空类型，是一个泛型类型
            //Nullable<int> x3 = null;
            int? x3 = null;  // int? x3    就是    Nullable<int> x3
            var y3 = x3 ?? 100;
            Console.WriteLine(y3.GetType().FullName);
            Console.WriteLine("--------------------------");


            // ?:   的表达式返回的类型，由 ：左右两边的操作数的数据类型决定的，谁的精度高 就用谁的数据类型。 
            var x4 = 5 > 3 ? 2 : 3.0;  // ：左右两边的数据类型，必须可以进行隐式类型转换
            //var x4 = 5 > 3 ? "2.0" : 3.0;  // 编译器报错： "2.0" 和 3.0 不能进行隐式类型转换
            Console.WriteLine($"x4 = {x4}");  // 2
            Console.WriteLine(x4.GetType().FullName);  // System.Double
            Console.WriteLine("--------------------------");


            Console.WriteLine("赋值表达式也有自己的值");
            int x5 = 100;
            int y5;
            Console.WriteLine(y5 = x5);  // python 没有这种用法 print(y5=x5) 会报错
            Console.WriteLine((y5 = x5).GetType().FullName);
            Console.WriteLine("--------");
            bool b = false;
            if (b == 5 > 3)  // false
            {
                Console.WriteLine("hello1 打印了");
            }
            else
            {
                Console.WriteLine("hello1 没有打印");
            }

            if (b = 5 > 3)  // true
            {
                Console.WriteLine("hello2 打印了");
            }
            Console.WriteLine("--------------------------");

            Console.WriteLine("匿名方法表达式，delegate 的这种用法已经过时了");
            // delegate 委托
            Action a = delegate () { Console.WriteLine("Hello, World!"); };
            a();
            Console.WriteLine("--------------------------");


            Console.WriteLine("事件");
            Form myForm = new Form();
            myForm.Text = "Hello";
            myForm.Load += MyForm_Load;  // 给 Load 事件 绑定事件处理器
            myForm.ShowDialog();
            Console.WriteLine("--------------------------");
        }

        // sender: 事件发送方
        private static void MyForm_Load(object sender, EventArgs e)
        {
            // 要访问Form 要对 object 进行类型转换
            Form form = sender as Form;  
            if (form == null)
            {
                return;
            }
            form.Text = "New Title";
        }
    }
}
