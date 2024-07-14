namespace WinFormExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //�Ѿ�������д���� �� delegate д����������
            //this.button3.Click += delegate (object sender, EventArgs e)
            //{
            //    this.textBox1.Text = "haha!";
            //};

            // �������е� lambda ���ʽд��
            //this.button3.Click += (object sender, EventArgs e) =>
            // sender, e ���Բ�д�������ͣ����������Ը����¼���Լ�����ƶϳ���������
            this.button3.Click += (sender, e) =>
            {
                this.textBox1.Text = "Hoho!";
            };
            // -----------------------------

            // �Ƚ��ϵ�д����EventHandler ��һ��ί�С�
            //this.button3.Click += new EventHandler(this.ButtonClicked);

            // ��д��
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
