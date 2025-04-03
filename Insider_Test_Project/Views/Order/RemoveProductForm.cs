using Insiders_Test_Project.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Insiders_Test_Project.Views.Order
{
    public partial class RemoveProductForm : Form
    {
        private readonly OrderManager _orderManager;
        public RemoveProductForm(OrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var OrderId = Guid.Parse(textBox1.Text);
                var ProductId = Guid.Parse(textBox2.Text);
                _orderManager.RemoveProduct(OrderId, ProductId);
                MessageBox.Show("Product was added.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
