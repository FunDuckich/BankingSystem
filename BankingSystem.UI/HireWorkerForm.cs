using BankingSystem.BLL;
using System;
using System.Windows.Forms;

namespace BankingSystem.UI
{
    public partial class HireWorkerForm : Form
    {
        private readonly ClientService _clientService;
        public Individual SelectedWorker { get; private set; }

        public HireWorkerForm(ClientService clientService)
        {
            _clientService = clientService;
            InitializeComponent();
        }

        private void HireWorkerForm_Load(object sender, EventArgs e)
        {
            var unemployed = _clientService.GetUnemployedIndividuals();
            lstUnemployed.DataSource = unemployed;
            lstUnemployed.DisplayMember = "DisplayName";
        }

        private void btnConfirmHire_Click(object sender, EventArgs e)
        {
            if (lstUnemployed.SelectedItem is Individual selected)
            {
                SelectedWorker = selected;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите работника из списка.", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}