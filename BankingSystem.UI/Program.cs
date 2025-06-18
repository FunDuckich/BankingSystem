using BankingSystem.BLL;
using BankingSystem.DAL;
using System;
using System.IO;
using System.Windows.Forms;

namespace BankingSystem.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            string clientsFile = Path.Combine(dataDirectory, "clients.dat");
            string usersFile = Path.Combine(dataDirectory, "users.dat");

            var dataAccess = new DataAccess(clientsFile, usersFile);
            var userService = new UserService(dataAccess);
            var clientService = new ClientService(dataAccess, userService);

            while (true)
            {
                User loggedInUser;
                using (var loginForm = new LoginForm(userService))
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        loggedInUser = loginForm.LoggedInUser;
                    }
                    else
                    {
                        break;
                    }
                }

                Form dashboard = null;
                if (loggedInUser.Role == UserRole.Admin)
                {
                    dashboard = new AdminDashboardForm(clientService);
                }
                else if (loggedInUser.Role == UserRole.Client && loggedInUser.ClientId.HasValue)
                {
                    var client = clientService.GetClientById(loggedInUser.ClientId.Value);
                    if (client != null)
                    {
                        dashboard = new ClientDashboardForm(client, clientService);
                    }
                    else
                    {
                        MessageBox.Show("Связанный с пользователем клиент не найден.", "Критическая ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (dashboard != null)
                {
                    Application.Run(dashboard);
                }

                if (dashboard == null || dashboard.DialogResult != DialogResult.Retry)
                {
                    break;
                }
            }
        }
    }
}