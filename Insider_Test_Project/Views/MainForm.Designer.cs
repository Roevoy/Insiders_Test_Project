namespace Insiders_Test_Project.Views
{
    partial class MainForm
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
            UsersButton = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // UsersButton
            // 
            UsersButton.Location = new Point(12, 21);
            UsersButton.Name = "UsersButton";
            UsersButton.Size = new Size(188, 85);
            UsersButton.TabIndex = 0;
            UsersButton.Text = "Users";
            UsersButton.UseVisualStyleBackColor = true;
            UsersButton.Click += UsersButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(219, 21);
            button1.Name = "button1";
            button1.Size = new Size(179, 85);
            button1.TabIndex = 1;
            button1.Text = "Orders";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(124, 123);
            button2.Name = "button2";
            button2.Size = new Size(172, 94);
            button2.TabIndex = 2;
            button2.Text = "Taxrate";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 249);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(UsersButton);
            Name = "MainForm";
            Text = "Main";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button UsersButton;
        private Button button1;
        private Button button2;
    }
}
