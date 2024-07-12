using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 添加新引用命名空间（要先在导航栏中的 引用->鼠标右键点击，选择添加引用->程序集，里面添加System.Windows.Forms后，这里才能using）
using System.Windows.Forms;

// 自定义的类库
using Tools;

// 命名空间，默认跟创建project的时候是一样的
namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");

            //form表单窗口, namespace: System.Windows.Forms
            //Form form = new Form();
            //form.ShowDialog();  // 调用此方法时，只有在对话框关闭之后，它后面的代码才会执行。 

            // 调用自定义的类库
            double res = Calculator.Mul(3, 4);  //乘法
            Console.WriteLine(res);
            res = Calculator.Div(1, 0);  // 除法
            Console.WriteLine(res);

            // 写程序要注重“高内聚，低耦合”
        }
    }
}
