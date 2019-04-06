using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothing_Industry
{
    public partial class AuthentificationForm : Form
    {
        private string username;
        private string password;

        public AuthentificationForm()
        {
            InitializeComponent();
            AcceptButton = buttonOK;
            textBoxLogin.Focus();
        }

        private bool CheckServer()
        {
            string connString = "Server=localhost;charset=UTF8;Database=main_database;port=" + 3306 + ";user id=test_server";
            MySqlConnection connection = new MySqlConnection(connString);

            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                MessageBox.Show(this, "Нет подключения к серверу. Вероятно последний находится в выключенном состоянии",
                    "Ошибка соединения с сервером", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!CheckServer())
            {
                return;
            }

            username = textBoxLogin.Text;
            password = textBoxPassword.Text;

            string connString = "Server=localhost;charset=UTF8;Database=main_database;port=" + 3306 + ";user id=" + username + ";password=" + password;

            MySqlConnection connection = new MySqlConnection(connString);
            try
            {
                connection.Open();
                Properties.Settings.Default.main_databaseConnectionString = connString;
                Form MainForm = new MainForm();
                this.Hide();
                MainForm.Show();
            }
            catch
            {
                MessageBox.Show("Неверные логин или пароль!");
            }

        }
    }
}
