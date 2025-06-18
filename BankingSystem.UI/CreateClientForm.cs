using System;
using System.Windows.Forms;

namespace BankingSystem.UI
{
    public partial class CreateClientForm : Form
    {
        public string ClientName => txtName.Text;
        public bool IsIndividual => rbIndividual.Checked;
        public string Username => txtUsername.Text;
        public string Password => txtPassword.Text;

        public CreateClientForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}