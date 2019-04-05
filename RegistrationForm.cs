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
    public partial class RegistrationForm : Form
    {
        private string username;
        private string password;

        public RegistrationForm()
        {
            InitializeComponent();
            AcceptButton = buttonOK;
            textBoxLogin.Focus();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            username = textBoxLogin.Text;
            password = textBoxPassword.Text;

            string connString = "Server=localhost;charset=UTF8;Database=main_database;port=" + 3306 + ";user id=" + username + ";password=" + password;

            string host = "localhost";
            string database = "main_database";
            int port = 3306;

            /*String connString = "Server=" + host + ";Database=" + database
               + ";port=" + port + ";User Id=" + username + ";password=" + password;*/

            MySqlConnection connection = new MySqlConnection(connString);
            try
            {
                connection.Open();
                Properties.Settings.Default.main_databaseConnectionString = connString;
                Form MainForm = new MainForm();
                this.Hide();
                MainForm.Show();
                
                //Application.Run(new MainForm());
            }
            catch
            {
                MessageBox.Show("Неверные логин или пароль!");
            }

        }
    }
}
