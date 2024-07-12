using System;
using System.Collections;
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

namespace HeapSample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 声明变量
        List<Window> winList;

        // 模拟内存泄漏
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // win按键 + R，输入 perfmon(performance monitor) ，打开性能检测界面。
            winList = new List<Window>();
            for (int i = 0; i < 150000; i++)
            {
                // c# 根据变量类型，来决定该变量是分配在 栈上 还是 分配在 堆上。
                // 实例会分配到 堆上。
                Window w = new Window();  // Window 的实例比较占内存
                winList.Add(w);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            foreach (var window in winList)
            {
                window.Close();
                // 如果 Window 实现了 IDisposable 接口，则可以调用 Dispose 方法
                if (window is IDisposable disposableWindow)
                {
                    disposableWindow.Dispose();
                }
            }

            // 释放内存
            winList.Clear(); // 我的测试，点击button2并没有释放内存
                             // 强制垃圾收集（测试时使用）
            winList = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
