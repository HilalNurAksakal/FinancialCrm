using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmSpending : Form
    {
        public FrmSpending()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard dashboardPage = new FrmDashboard();
            dashboardPage.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        FinancialCrmDbEntities db= new FinancialCrmDbEntities();
        private void FrmSpending_Load(object sender, EventArgs e)
        {
            var lastSpending = db.Spendings.OrderBy(x => x.SpendingId).Take(1).FirstOrDefault();
            lblLastSpendingName.Text = lastSpending.SpendingTitle;
            lblLastSpendingBalance.Text = lastSpending.SpendingAmount.ToString();
            lblLastSpendingDate.Text = lastSpending.SpendingDate.ToString();
            var values = db.Spendings
               .Select(b => new
               {
                   b.SpendingId,
                   b.SpendingTitle,
                   b.SpendingDate,
                   b.SpendingAmount,

               })
               .ToList();
            dataGridView1.DataSource = values;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankProcess bankProcessPage = new FrmBankProcess();
            bankProcessPage.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings settingsPage = new FrmSettings();
            settingsPage.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();

        }

        
    }
}
