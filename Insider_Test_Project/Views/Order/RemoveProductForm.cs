using Insiders_Test_Project.Managers;


namespace Insiders_Test_Project.Views.Order
{
    public partial class RemoveProductForm : Form
    {
        private readonly OrderManager _orderManager;
        public RemoveProductForm(OrderManager orderManager)
        {
            InitializeComponent();
            _orderManager = orderManager;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var OrderId = Guid.Parse(textBox1.Text);
                var ProductId = Guid.Parse(textBox2.Text);
                _orderManager.RemoveProduct(OrderId, ProductId);
                MessageBox.Show("Product was removed.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
