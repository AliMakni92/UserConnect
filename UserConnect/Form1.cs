using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserConnect
{
    public partial class FnPrincipalp : Form
    {
        public FnPrincipalp()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            String longin = txtLogin.Text;
            String mdp = txtMdp.Text;
            String connectionString = @" Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\UsersConnectBd.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connect = new SqlConnection(connectionString);
            String query = "SELECT * FROM Users WHERE Login=@login AND mdp=@mdp";
            try
            {
                SqlCommand command = new SqlCommand(query,connect);
                connect.Open();
                SqlParameter paramOne = new SqlParameter("@login",SqlDbType.NVarChar);
                SqlParameter paramTwo = new SqlParameter("@mdp", SqlDbType.NVarChar);
                paramOne.Value = longin;
                paramTwo.Value = mdp;
                command.Parameters.Add(paramOne);
                command.Parameters.Add(paramTwo);
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    MessageBox.Show("vous etes connectés", "Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("identifiant ou mot de passe  Incorrect", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                reader.Close();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
