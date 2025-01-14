using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {

        }

        FinancialCrmDbEntities db= new FinancialCrmDbEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password1=txtUserPassword.Text;
            string password2 = txtUserPassword2.Text;
            if(password1==password2)
            {

                var userId = db.Users
               .Where(x => x.UserName == username)
               .Select(x => x.UserId)
               .SingleOrDefault();
                var values = db.Users.Find(userId);

                values.UserName= username;
                values.Password = password1;
                db.SaveChanges();
                MessageBox.Show("Şifre Başarıyla Güncellendi. Giriş Sayfasına Yönlendiriliyorsunuz.", "Şifre Değiştirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmLogin loginPage = new FrmLogin();
                loginPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girdiğiniz İki Şifre Farklı");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDashboard dashboardPage = new FrmDashboard();
            dashboardPage.Show();
            this.Hide();
        }
    }
}
