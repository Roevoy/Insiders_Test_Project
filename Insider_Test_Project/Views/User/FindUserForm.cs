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

namespace Insiders_Test_Project.Views
{
    public partial class FindUserForm : Form
    {
        private readonly UserManager _userManager;
        private readonly DataGridView _dataGridView;
        public FindUserForm(UserManager userManager, DataGridView dataGridView)
        {
            InitializeComponent();
            _userManager = userManager;
            _dataGridView = dataGridView;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Guid.Parse(textBox1.Text);
                var user = _userManager.GetUser(id);
                _dataGridView.DataSource = new List<Models.User>() { user };
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
