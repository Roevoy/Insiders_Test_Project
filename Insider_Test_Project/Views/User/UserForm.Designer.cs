namespace Insiders_Test_Project.Views
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FindUserBtn = new Button();
            AddUserBtn = new Button();
            UsersGridView = new DataGridView();
            ChangeUserBtn = new Button();
            DeleteUserBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)UsersGridView).BeginInit();
            SuspendLayout();
            // 
            // FindUserBtn
            // 
            FindUserBtn.Location = new Point(579, 54);
            FindUserBtn.Name = "FindUserBtn";
            FindUserBtn.Size = new Size(116, 36);
            FindUserBtn.TabIndex = 0;
            FindUserBtn.Text = "Find";
            FindUserBtn.UseVisualStyleBackColor = true;
            // 
            // AddUserBtn
            // 
            AddUserBtn.Location = new Point(579, 12);
            AddUserBtn.Name = "AddUserBtn";
            AddUserBtn.Size = new Size(116, 36);
            AddUserBtn.TabIndex = 0;
            AddUserBtn.Text = "Add";
            AddUserBtn.UseVisualStyleBackColor = true;
            AddUserBtn.Click += AddUserBtn_Click;
            // 
            // UsersGridView
            // 
            UsersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UsersGridView.Location = new Point(12, 12);
            UsersGridView.Name = "UsersGridView";
            UsersGridView.RowHeadersWidth = 51;
            UsersGridView.Size = new Size(551, 408);
            UsersGridView.TabIndex = 1;
            // 
            // ChangeUserBtn
            // 
            ChangeUserBtn.Enabled = false;
            ChangeUserBtn.Location = new Point(579, 342);
            ChangeUserBtn.Name = "ChangeUserBtn";
            ChangeUserBtn.Size = new Size(116, 36);
            ChangeUserBtn.TabIndex = 0;
            ChangeUserBtn.Text = "Change";
            ChangeUserBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteUserBtn
            // 
            DeleteUserBtn.Enabled = false;
            DeleteUserBtn.Location = new Point(579, 384);
            DeleteUserBtn.Name = "DeleteUserBtn";
            DeleteUserBtn.Size = new Size(116, 36);
            DeleteUserBtn.TabIndex = 0;
            DeleteUserBtn.Text = "Delete";
            DeleteUserBtn.UseVisualStyleBackColor = true;
            DeleteUserBtn.Click += DeleteUserBtn_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 446);
            Controls.Add(UsersGridView);
            Controls.Add(AddUserBtn);
            Controls.Add(DeleteUserBtn);
            Controls.Add(ChangeUserBtn);
            Controls.Add(FindUserBtn);
            Name = "UserForm";
            Text = "User";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)UsersGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button FindUserBtn;
        private Button AddUserBtn;
        private DataGridView UsersGridView;
        private Button ChangeUserBtn;
        private Button DeleteUserBtn;
    }
}