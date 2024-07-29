using System.ComponentModel;
using System.Globalization;
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

namespace HappyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 从资源中 获取 key 为 human 的对象
            Human? h = this.FindResource("human") as Human;
            if (h != null)
            {
                //MessageBox.Show(h.Name);
                MessageBox.Show(h.Child.Name);
            }
        }
    }


    [TypeConverter(typeof(NameToHumanTypeConverter))]
    public class Human
    {
        public string Name { get; set; }
        public Human Child { get; set; } 
    }


    // 把字符串值 转换为其 他类型的值
    public class NameToHumanTypeConverter:TypeConverter
    {
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            //value: 就是在 xaml的标签里 通过属性赋值 得到的值
            string name = value.ToString();
            Human child = new Human();
            child.Name = name;
            return child;
        }
    }
}