using Insiders_Test_Project.Managers;
using Insiders_Test_Project.Views;
using System.Windows.Forms;

namespace Insiders_Test_Project.Views.User
{
    public partial class CreateUserForm : Form
    {
        private readonly DataGridView _dataGridView;
        private readonly UserManager _userManager;
        public CreateUserForm(DataGridView dataGrodView, UserManager userManager)
        {
            _dataGridView = dataGrodView;
            _userManager = userManager;
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string email = textBox2.Text;
                string password = textBox3.Text;
                _userManager.CreateUser(name, email, password);
                MessageBox.Show("User created!");
                _dataGridView.DataSource = _userManager.GetAllUsers();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CreateUserForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
