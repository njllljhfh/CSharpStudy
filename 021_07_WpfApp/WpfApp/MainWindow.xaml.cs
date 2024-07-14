using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // wpf中也可以用c#代码来挂载事件（先在 xaml 中将 button1 的Click绑定事件的代码删除）
            //this.button1.Click += ButtonClicked;
            //this.button1.Click += new RoutedEventHandler(this.ButtonClicked);
            //this.button1.Click += (sender, e) =>
            //{
            //    this.textBox1.Text = "Hello World!";
            //};
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            this.textBox1.Text = "Hello World!";
        }
    }
}