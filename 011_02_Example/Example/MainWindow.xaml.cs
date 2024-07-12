using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Example
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //delegate 后面的是一个 匿名方法（delegate 作为操作符的这种用法，已经过时了。现在流行的是 lambda 表达式）
            //this.myButton.Click += delegate(object sender, RoutedEventArgs e)
            //{
            //    this.myTextBox.Text = "Hello, World!";
            //}; // += 绑定事件处理器


            // lambda 表达式：(sender, e) => { ... }
            this.myButton.Click += (sender, e) =>
            {
                this.myTextBox.Text = "Hello, World!";
            }; // += 绑定事件处理器
        }


    }
}
