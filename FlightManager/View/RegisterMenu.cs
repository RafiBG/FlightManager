using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FlightManager
{
    public partial class RegisterMenu : Form
    {
        
        public RegisterMenu()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register(textBox1.Text, textBox2.Text);
        }


        string connectionString = "server=localhost;user=root;database=flightmanager_db;port=3306;password=''; pooling = false; convert zero datetime=True";
        string connStr = "server=localhost;user=root;database=flightmanager_db;port=3306;password=''; pooling = false; convert zero datetime=True";
        public bool Register(string username, string password)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = $"SELECT username FROM users WHERE username = '{username}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (!rdr.Read())
                {
                     sql = $"INSERT INTO users (username, password) VALUES ('{username}', '{password}');";
                     cmd = new MySqlCommand(sql, conn);
                     rdr = cmd.ExecuteReader();

                    
                }
                else
                {
                    MessageBox.Show("This username is already!");
                }
  
                rdr.Close();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
