using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

/*
事件的应用
事件模型的五个组成部分
    - 事件的拥有者（event source，对象）
    - 事件成员（event，成员）
    - 事件的响应者（event subscriber，对象）
    - 事件处理器（event handler，成员） --- 本质上是一个回调方法
    - 事件订阅 --- 把事件处理器与事件关联在一起，本质上是一种以委托类型为基础的"约定"
*/


namespace EventExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyForm form = new MyForm();
            form.ShowDialog();
        }
    }

    // 类的继承
    class MyForm : Form
    {
        private TextBox textBox;
        private Button button;

        public MyForm()
        {
            this.textBox = new TextBox();
            this.button = new Button();
            // 把组件添加到Form对象中
            this.Controls.Add(this.button);
            this.Controls.Add(this.textBox);

            this.button.Click += this.ButtonClicked;
            this.button.Text = "Say Hello";
            this.button.Top = 100;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            this.textBox.Text = "Hello, World!";
        }
    }
}
