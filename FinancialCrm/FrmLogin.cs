using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db= new FinancialCrmDbEntities();
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName=txtUserName.Text;
            string userPassword=txtUserPassword.Text;
            var user=db.Users.Where(x=>x.UserName==userName).Select(y=>y.Password).FirstOrDefault();
            if (user != null)
            {
                string useridentity = user.ToString();
                if (useridentity == userPassword)
                {
                    FrmDashboard dashboardPage = new FrmDashboard();
                    dashboardPage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Şifre Girişi");
                }
            }

            else
            {
                MessageBox.Show("Hatalı Üye Girişi");
            }

        }
    }
}
