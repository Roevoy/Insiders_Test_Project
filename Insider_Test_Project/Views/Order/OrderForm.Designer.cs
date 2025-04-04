namespace Insiders_Test_Project.Views.Order
{
    partial class OrderForm
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
            RefreshOrdersBtn = new Button();
            OrdersGridView = new DataGridView();
            AddOrderBtn = new Button();
            DeleteOrderBtn = new Button();
            ChangeOrderBtn = new Button();
            FindOrderBtn = new Button();
            SubstrctOrderBtn = new Button();
            AddProductBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)OrdersGridView).BeginInit();
            SuspendLayout();
            // 
            // RefreshOrdersBtn
            // 
            RefreshOrdersBtn.Location = new Point(589, 142);
            RefreshOrdersBtn.Name = "RefreshOrdersBtn";
            RefreshOrdersBtn.Size = new Size(116, 33);
            RefreshOrdersBtn.TabIndex = 8;
            RefreshOrdersBtn.Text = "Refresh";
            RefreshOrdersBtn.UseVisualStyleBackColor = true;
            RefreshOrdersBtn.Click += RefreshOrdersBtn_Click;
            // 
            // OrdersGridView
            // 
            OrdersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrdersGridView.Location = new Point(12, 21);
            OrdersGridView.Name = "OrdersGridView";
            OrdersGridView.RowHeadersWidth = 51;
            OrdersGridView.Size = new Size(551, 408);
            OrdersGridView.TabIndex = 7;
            OrdersGridView.CellContentClick += OrdersGridView_CellContentClick;
            // 
            // AddOrderBtn
            // 
            AddOrderBtn.Location = new Point(589, 21);
            AddOrderBtn.Name = "AddOrderBtn";
            AddOrderBtn.Size = new Size(116, 36);
            AddOrderBtn.TabIndex = 3;
            AddOrderBtn.Text = "Add";
            AddOrderBtn.UseVisualStyleBackColor = true;
            AddOrderBtn.Click += AddOrderBtn_Click;
            // 
            // DeleteOrderBtn
            // 
            DeleteOrderBtn.Enabled = false;
            DeleteOrderBtn.Location = new Point(589, 393);
            DeleteOrderBtn.Name = "DeleteOrderBtn";
            DeleteOrderBtn.Size = new Size(116, 36);
            DeleteOrderBtn.TabIndex = 4;
            DeleteOrderBtn.Text = "Delete";
            DeleteOrderBtn.UseVisualStyleBackColor = true;
            DeleteOrderBtn.Click += DeleteOrderBtn_Click;
            // 
            // ChangeOrderBtn
            // 
            ChangeOrderBtn.Enabled = false;
            ChangeOrderBtn.Location = new Point(589, 351);
            ChangeOrderBtn.Name = "ChangeOrderBtn";
            ChangeOrderBtn.Size = new Size(116, 36);
            ChangeOrderBtn.TabIndex = 5;
            ChangeOrderBtn.Text = "Change";
            ChangeOrderBtn.UseVisualStyleBackColor = true;
            ChangeOrderBtn.Click += ChangeOrderBtn_Click;
            // 
            // FindOrderBtn
            // 
            FindOrderBtn.Location = new Point(589, 63);
            FindOrderBtn.Name = "FindOrderBtn";
            FindOrderBtn.Size = new Size(116, 36);
            FindOrderBtn.TabIndex = 6;
            FindOrderBtn.Text = "Find";
            FindOrderBtn.UseVisualStyleBackColor = true;
            FindOrderBtn.Click += FindOrderBtn_Click;
            // 
            // SubstrctOrderBtn
            // 
            SubstrctOrderBtn.Location = new Point(589, 260);
            SubstrctOrderBtn.Name = "SubstrctOrderBtn";
            SubstrctOrderBtn.Size = new Size(116, 35);
            SubstrctOrderBtn.TabIndex = 9;
            SubstrctOrderBtn.Text = "- Product";
            SubstrctOrderBtn.UseVisualStyleBackColor = true;
            SubstrctOrderBtn.Click += SubstrctOrderBtn_Click;
            // 
            // AddProductBtn
            // 
            AddProductBtn.Location = new Point(589, 219);
            AddProductBtn.Name = "AddProductBtn";
            AddProductBtn.Size = new Size(116, 35);
            AddProductBtn.TabIndex = 9;
            AddProductBtn.Text = "+ Product";
            AddProductBtn.UseVisualStyleBackColor = true;

            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 450);
            Controls.Add(AddProductBtn);
            Controls.Add(SubstrctOrderBtn);
            Controls.Add(RefreshOrdersBtn);
            Controls.Add(OrdersGridView);
            Controls.Add(AddOrderBtn);
            Controls.Add(DeleteOrderBtn);
            Controls.Add(ChangeOrderBtn);
            Controls.Add(FindOrderBtn);
            Name = "OrderForm";
            Text = "OrderForm";
            Load += OrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)OrdersGridView).EndInit();
            ResumeLayout(false);
        }

        private void SubstrctOrderBtn_Click(object sender, EventArgs e)
        {
            var form = new RemoveProductForm(_orderManager);
            form.ShowDialog();
        }

        #endregion

        private Button RefreshOrdersBtn;
        private DataGridView OrdersGridView;
        private Button AddOrderBtn;
        private Button DeleteOrderBtn;
        private Button ChangeOrderBtn;
        private Button FindOrderBtn;
        private Button SubstrctOrderBtn;
        private Button AddProductBtn;
    }
}