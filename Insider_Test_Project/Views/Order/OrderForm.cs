using Insiders_Test_Project.Managers;

namespace Insiders_Test_Project.Views.Order
{
    public partial class OrderForm : Form
    {
        private OrderManager _orderManager;
        public OrderForm(OrderManager orderManager)
        {
            InitializeComponent();
            this.Load += OrderForm_Load;
            this.OrdersGridView.SelectionChanged += OrdersGridView_SelectionChanged;
            _orderManager = orderManager;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            OrdersGridView.DataSource = _orderManager.GetAll();
        }
        private void OrdersGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (OrdersGridView.SelectedRows.Count == 1)
            {
                DeleteOrderBtn.Enabled = true;
            }
            else
            {
                DeleteOrderBtn.Enabled = false;
            }
        }
        private void AddOrderBtn_Click(object sender, EventArgs e)
        {
            var createOrderBtn = new CreateOrderForm(OrdersGridView, _orderManager);
            createOrderBtn.ShowDialog();
        }

        private void DeleteOrderBtn_Click(object sender, EventArgs e)
        {
            if (OrdersGridView.SelectedRows.Count == 1)
            {
                try
                {
                    var selectedRow = OrdersGridView.SelectedRows[0];
                    var orderId = (Guid)selectedRow.Cells["Id"].Value;
                    _orderManager.DeleteOrder(orderId);
                    OrdersGridView.DataSource = _orderManager.GetAll();
                    DeleteOrderBtn.Enabled = false;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void OrdersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChangeOrderBtn_Click(object sender, EventArgs e)
        {

        }

        private void FindOrderBtn_Click(object sender, EventArgs e)
        {
            var form = new FindOrderForm(_orderManager, OrdersGridView);
            form.ShowDialog();
        }

        private void RefreshOrdersBtn_Click(object sender, EventArgs e)
        {
            OrdersGridView.DataSource = _orderManager.GetAll();
        }
    }
}
