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
using System.Windows.Threading;

//1. ctrl + k + f：非强制的，自己写的代码中自己调整的空格不能格式化
//2. ctrl + K + d：强制的
namespace EventSample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            //timer 就是以事件为侧重点的类
            timer.Interval=TimeSpan.FromSeconds(1); // 1秒钟
            timer.Tick += timer_Tick;  // += 用来绑定事件，当Tick事件触发时，执行timer_Tick
            timer.Start(); // 启动定时器
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timeTextBox.Text = DateTime.Now.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
