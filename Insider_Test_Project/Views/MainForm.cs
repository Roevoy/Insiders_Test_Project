using Insiders_Test_Project;
using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.Managers;
using Insiders_Test_Project.Views;
using WinFormProject1;

namespace WinFormProject1
{
    public partial class MainForm : Form
    {
        private readonly UserManager _userManager;
        public MainForm(UserManager userManager)
        {
            _userManager = userManager;
            InitializeComponent();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm(_userManager);
            form.ShowDialog();
        }

    }
}
