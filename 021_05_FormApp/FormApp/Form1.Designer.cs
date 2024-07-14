namespace FormApp
{
    partial class MyForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            myTextBox = new TextBox();
            myButton = new Button();
            SuspendLayout();
            // 
            // myTextBox
            // 
            myTextBox.Location = new Point(12, 12);
            myTextBox.Name = "myTextBox";
            myTextBox.Size = new Size(457, 27);
            myTextBox.TabIndex = 0;
            // 
            // myButton
            // 
            myButton.Location = new Point(12, 45);
            myButton.Name = "myButton";
            myButton.Size = new Size(457, 29);
            myButton.TabIndex = 1;
            myButton.Text = "Say Hello";
            myButton.UseVisualStyleBackColor = true;
            myButton.Click += myButtonClicked;
            // 
            // MyForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 381);
            Controls.Add(myButton);
            Controls.Add(myTextBox);
            Name = "MyForm";
            Text = "Hello Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox myTextBox;
        private Button myButton;
    }
}
