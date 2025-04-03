using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.Managers;
using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.Views
{
    public partial class UserForm : Form
    {
        private readonly UserManager _userManager;
        public UserForm(UserManager userManager)
        {
            _userManager = userManager;
            InitializeComponent();
            this.Load += UserForm_Load;
            this.UsersGridView.SelectionChanged += UsersGridView_SelectionChanged;
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            UsersGridView.DataSource = _userManager.GetAllUsers();
        }
        private void UsersGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (UsersGridView.SelectedRows.Count == 1)
            {
                ChangeUserBtn.Enabled = true;
                DeleteUserBtn.Enabled = true;
            }
            else
            {
                ChangeUserBtn.Enabled = false;
                DeleteUserBtn.Enabled = false;
            }
        }
        private void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            if (UsersGridView.SelectedRows.Count == 0)
            {
                var user = (User)UsersGridView.SelectedRows[0].DataBoundItem;
                _userManager.DeleteUser(user.Id);
                UsersGridView.DataSource = null;
                UsersGridView.DataSource = _userManager.GetAllUsers();
                DeleteUserBtn.Enabled = false;
            }
        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
