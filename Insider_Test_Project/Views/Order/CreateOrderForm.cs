using Insiders_Test_Project.Managers;

namespace Insiders_Test_Project.Views
{
    public partial class CreateOrderForm : Form
    {
        public CreateOrderForm()
        {
            InitializeComponent();
        }
        private readonly DataGridView _dataGridView;
        private readonly OrderManager _orderManager;
        public CreateOrderForm(DataGridView dataGrodView, OrderManager orderManager)
        {
            _dataGridView = dataGrodView;
            _orderManager = orderManager;
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Guid CustomerId = Guid.Parse(textBox1.Text);
                _orderManager.CreateOrder(CustomerId);
                MessageBox.Show("Order created!");
                _dataGridView.DataSource = _orderManager.GetAll();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var customerId = Guid.Parse(textBox1.Text);
                _orderManager.CreateOrder(customerId);
                _dataGridView.DataSource = _orderManager.GetAll();
                MessageBox.Show("Order is created!");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
