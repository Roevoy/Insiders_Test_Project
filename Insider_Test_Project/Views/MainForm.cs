using ClassLibraryIntegration;
using Insiders_Test_Project;
using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.Managers;
using Insiders_Test_Project.Views;
using Insiders_Test_Project.Views.Order;
using Insiders_Test_Project.Views.Taxrate;

namespace Insiders_Test_Project.Views
{
    public partial class MainForm : Form
    {
        private readonly UserManager _userManager;
        private readonly OrderManager _orderManager;
        private readonly ClassLibraryIntegration.Taxrate _taxrate;
        public MainForm(UserManager userManager, OrderManager orderManager, ClassLibraryIntegration.Taxrate taxrate)
        {
            InitializeComponent();
            _userManager = userManager;
            _orderManager = orderManager;
            _taxrate = taxrate; 
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(_userManager);
            userForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm(_orderManager);
            orderForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new TaxrateForm(_taxrate);
            form.Show();
        }
    }
}
