namespace WinFormExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //已经废弃的写法： 用 delegate 写的匿名方法
            //this.button3.Click += delegate (object sender, EventArgs e)
            //{
            //    this.textBox1.Text = "haha!";
            //};

            // 现在流行的 lambda 表达式写法
            //this.button3.Click += (object sender, EventArgs e) =>
            // sender, e 可以不写参数类型：编译器可以根据事件的约束，推断出参数类型
            this.button3.Click += (sender, e) =>
            {
                this.textBox1.Text = "Hoho!";
            };
            // -----------------------------

            // 比较老的写法，EventHandler 是一个委托。
            //this.button3.Click += new EventHandler(this.ButtonClicked);

            // 新写法
            //this.button3.Click += this.ButtonClicked;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            if (sender == this.button1)
            {
                this.textBox1.Text = "Hello!";
            }

            if (sender == this.button2)
            {
                this.textBox1.Text = "World!";
            }

            if (sender == this.button3)
            {
                this.textBox1.Text = "Mr.Okay!";
            }
        }
    }
}
