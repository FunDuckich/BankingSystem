using BankingSystem.BLL;
using System;
using System.Windows.Forms;

namespace BankingSystem.UI
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        public User LoggedInUser { get; private set; }

        public LoginForm(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = _userService.Login(txtUsername.Text, txtPassword.Text);
            if (user != null)
            {
                LoggedInUser = user;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка входа", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}