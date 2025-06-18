using BankingSystem.BLL;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BankingSystem.UI
{
    public partial class ClientDashboardForm : Form
    {
        private readonly Client _client;
        private readonly ClientService _clientService;

        public ClientDashboardForm(Client client, ClientService clientService)
        {
            _client = client;
            _clientService = clientService;
            InitializeComponent();
        }

        private void ClientDashboardForm_Load(object sender, EventArgs e)
        {
            RefreshInfo();
            SetupPersonnelControls();
        }

        private void RefreshInfo()
        {
            txtClientInfo.Text = _client.ToString();
        }

        private void SetupPersonnelControls()
        {
            var personnelGroup = this.Controls.Find("gbPersonnel", true).FirstOrDefault();
            if (personnelGroup == null) return;

            if (_client is LegalEntity)
            {
                personnelGroup.Visible = true;
                var lstWorkers = (ListBox)this.Controls.Find("lstCurrentWorkers", true).First();

                lstWorkers.DataSource = null;
                if (_client is LegalEntity company)
                {
                    lstWorkers.DataSource = company.Workers;
                }

                lstWorkers.DisplayMember = "DisplayName";
                lstWorkers.SelectedIndex = -1;
            }
            else
            {
                personnelGroup.Visible = false;
            }
        }

        private void PerformAction(Action action)
        {
            try
            {
                action();
                _clientService.SaveChanges();
                RefreshInfo();
                SetupPersonnelControls();
                MessageBox.Show("Операция выполнена успешно.", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTopUp_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTransactionAmount.Text, out var amount))
            {
                PerformAction(() => _client.TopUp(amount));
                txtTransactionAmount.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректную сумму для пополнения.", "Ошибка ввода", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTransactionAmount.Text, out var amount))
            {
                PerformAction(() => _client.Withdraw(amount));
                txtTransactionAmount.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректную сумму для снятия.", "Ошибка ввода", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnOpenDeposit_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDepositAmount.Text, out var amount))
            {
                if (_client is IDepositor depositor)
                {
                    PerformAction(() => depositor.OpenDeposit(amount));
                    txtDepositAmount.Clear();
                }
            }
            else
                MessageBox.Show("Введите корректную сумму депозита.", "Ошибка ввода", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private void btnCloseDeposit_Click(object sender, EventArgs e)
        {
            if (_client is IDepositor depositor) PerformAction(() => depositor.CloseDeposit());
        }

        private void btnTakeLoan_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtLoanAmount.Text, out var amount))
            {
                if (_client is ILoaner loaner)
                {
                    PerformAction(() => loaner.TakeLoan(amount));
                    txtLoanAmount.Clear();
                }
            }
            else
                MessageBox.Show("Введите корректную сумму кредита.", "Ошибка ввода", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private void btnPayLoan_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtLoanAmount.Text, out var amount))
            {
                if (_client is ILoaner loaner)
                {
                    PerformAction(() => loaner.PayLoan(amount));
                    txtLoanAmount.Clear();
                }
            }
            else
                MessageBox.Show("Введите корректную сумму погашения.", "Ошибка ввода", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            using (var form = new HireWorkerForm(_clientService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var workerToHire = form.SelectedWorker;
                    if (workerToHire != null && _client is LegalEntity company)
                    {
                        PerformAction(() => company.Hire(workerToHire));
                    }
                }
            }
        }

        private void btnPayWages_Click(object sender, EventArgs e)
        {
            if (_client is LegalEntity company)
            {
                PerformAction(() => company.PaymentForWorkers());
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}