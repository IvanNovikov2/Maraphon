using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Марафон
{
    public partial class Sponsor : Form
    {
        public Sponsor()
        {
            InitializeComponent();
        }
        private void check()
        {
            if (textBox1.Text == "" | textBox3.Text == "" | textBox4.Text == "" | textBox5.Text == "" | textBox6.Text == "" | textBox7.Text == "" | comboBox1.Text == "") button5.Enabled = false; else button5.Enabled = true;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.TextLength == 0) textBox7.Text = "0";
            label11.Text = textBox7.Text;
            if (Convert.ToInt32(textBox7.Text) <= 0)
            {
                MessageBox.Show("Вы должны пожертвовать хотя бы 1$");
                button5.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
            }

        }

        private void Sponsor_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Марафон.Properties.Settings.Default.MaraphonConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT        [User].FirstName + ' ' + [User].LastName + ' - ' + CONVERT(varchar(20),RegistrationEvent.BibNumber) + ' (' + Runner.CountryCode +')' AS Runner FROM Runner INNER JOIN              [User] ON Runner.Email = [User].Email INNER JOIN                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId WHERE([User].RoleId = N'R')"; SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0]);
                }
                conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(Марафон.Properties.Settings.Default.MaraphonConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT CharityName  FROM Charity";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                conn.Close();
            }

        }
    }
}
