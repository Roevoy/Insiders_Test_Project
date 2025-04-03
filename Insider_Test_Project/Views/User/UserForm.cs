using Insiders_Test_Project.Managers;
using Insiders_Test_Project.Views.User;

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
            this.DeleteUserBtn.Click += DeleteUserBtn_Click;
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
            try
            {

                if (UsersGridView.SelectedRows.Count == 1)
                {
                    var selectedRow = UsersGridView.SelectedRows[0];
                    var userId = (Guid)selectedRow.Cells["Id"].Value;
                    _userManager.DeleteUser(userId);
                    UsersGridView.DataSource = _userManager.GetAllUsers();
                    DeleteUserBtn.Enabled = false;
                }
            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }
        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            var createUserForm = new CreateUserForm(UsersGridView, _userManager);
            createUserForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsersGridView.DataSource = _userManager.GetAllUsers();
        }

        private void ChangeUserBtn_Click(object sender, EventArgs e)
        {
            try
            {

            var selectedRow = UsersGridView.SelectedRows[0];
            var userId = (Guid)selectedRow.Cells["Id"].Value;
            var createUserForm = new UpdateUserForm(_userManager, userId);
            createUserForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void FindUserBtn_Click(object sender, EventArgs e)
        {
            var findUserForm = new FindUserForm(_userManager, UsersGridView);
            findUserForm.ShowDialog();
        }
    }
}
