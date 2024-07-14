namespace FormApp
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void myButtonClicked(object sender, EventArgs e)
        {
            this.myTextBox.Text = "Hello World!";
        }
    }
}
