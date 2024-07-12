using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //引用类库

namespace ClassAndInstance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Form myForm1;
            Form myForm2;

            // 用 new 创建类的实例
            myForm1 = new Form();

            myForm1.Text = "My Form!";
            myForm2 = myForm1; // myForm2和myForm1 引用的是同一个对象
            myForm2.ShowDialog();
        }
    }
}
