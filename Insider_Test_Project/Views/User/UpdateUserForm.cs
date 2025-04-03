using Insiders_Test_Project.Managers;

namespace Insiders_Test_Project.Views
{
    public partial class UpdateUserForm : Form
    {
        private readonly UserManager _userManager;
        private readonly Guid UserToUpdateId;
        public UpdateUserForm(UserManager userManager, Guid userToUpdateId)
        {
            _userManager = userManager;
            InitializeComponent();
            UserToUpdateId = userToUpdateId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string email = textBox2.Text;
                string password = textBox3.Text;
                var newUser = new Models.User()
                {
                    Id = UserToUpdateId,
                    Name = name,
                    Email = email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
                };
                _userManager.Updateuser(UserToUpdateId, newUser);
                MessageBox.Show("User updated!");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
