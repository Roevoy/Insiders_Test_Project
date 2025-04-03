using Insiders_Test_Project.Managers;

namespace Insiders_Test_Project.Views.Order
{
    public partial class FindOrderForm : Form
    {
        private readonly DataGridView _dataGridView;
        private readonly OrderManager _manager;
        public FindOrderForm(OrderManager orderManager, DataGridView dataGridView)
        {
            InitializeComponent();
            _manager = orderManager;
            _dataGridView = dataGridView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var Id = Guid.Parse(textBox1.Text.ToString());
                _dataGridView.DataSource = new List<Models.Order>() { _manager.GetOrderById(Id) };
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
