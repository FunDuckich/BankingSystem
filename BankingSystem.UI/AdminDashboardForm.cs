using BankingSystem.BLL;
using System;
using System.Windows.Forms;

namespace BankingSystem.UI
{
    public partial class AdminDashboardForm : Form
    {
        private readonly ClientService _clientService;

        public AdminDashboardForm(ClientService clientService)
        {
            _clientService = clientService;
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            RefreshClientList();
        }

        private void RefreshClientList()
        {
            int selectedId = (lstClients.SelectedItem as Client)?.ClientId ?? -1;

            lstClients.DataSource = null;
            var clients = _clientService.GetAllClients();
            lstClients.DataSource = clients;
            lstClients.DisplayMember = "DisplayName";

            if (selectedId != -1)
            {
                foreach (var item in lstClients.Items)
                {
                    if ((item as Client)?.ClientId == selectedId)
                    {
                        lstClients.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClients.SelectedItem is Client selectedClient)
            {
                txtClientDetails.Text = selectedClient.ToString();
            }
            else
            {
                txtClientDetails.Text = "";
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (var form = new CreateClientForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool success;
                    string errorMessage;

                    if (form.IsIndividual)
                    {
                        success = _clientService.AddIndividual(form.ClientName, form.Username, form.Password,
                            out errorMessage);
                    }
                    else
                    {
                        success = _clientService.AddLegalEntity(form.ClientName, form.Username, form.Password,
                            out errorMessage);
                    }

                    if (success)
                    {
                        _clientService.SaveChanges();
                        MessageBox.Show("Клиент успешно создан и сохранен.", "Успех", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        RefreshClientList();
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка: {errorMessage}", "Ошибка создания клиента", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItem is Client clientToDelete)
            {
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить клиента '{clientToDelete.DisplayName}'? Это действие необратимо.",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _clientService.DeleteClient(clientToDelete.ClientId);
                    _clientService.SaveChanges();
                    RefreshClientList();
                    MessageBox.Show("Клиент успешно удален.", "Удаление", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для удаления из списка.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }
    }
}