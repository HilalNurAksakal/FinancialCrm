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
    public partial class FrmBankProcess : Form
    {
        public FrmBankProcess()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSpending spendingPage = new FrmSpending();
            spendingPage.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
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

        FinancialCrmDbEntities db=new FinancialCrmDbEntities();
        private void FrmBankProcess_Load(object sender, EventArgs e)
        {
            var lastProcess = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblLastProcessTitle.Text = lastProcess.Description;
            lblLastProcessType.Text = lastProcess.ProcessType;
            lblLastProcessAmount.Text = lastProcess.Amount.ToString();

            var values = db.BankProcesses
               .Select(b => new
               {
                   b.BankProcessId,  
                   b.Description,    
                   b.ProcessDate,
                   b.ProcessType,   
                   b.Amount,

               })
               .ToList();
            dataGridView1.DataSource = values;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings settingsPage = new FrmSettings();
            settingsPage.Show();
            this.Hide();
        }
    }
}
