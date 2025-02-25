using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void btnSpending_Click(object sender, EventArgs e)
        {

            FrmDashboard fr = new FrmDashboard();
            fr.Show();
        }

        private void btnSpendingList_Click(object sender, EventArgs e)
        {

            //spendings List Process
            //
            var spendingList = db.Spendings.Select(x => new
            {
                x.SpendingId,
                x.SpendingTitle,
                x.SpendingAmount,
                x.SpendingDate,
                x.Categories.CategoryName
            }).ToList();
            dataGridView1.DataSource = spendingList;
        }

        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            //spendings List Process
            //
            var spendingList = db.Spendings.Select(x => new
            {
                x.SpendingId,
                x.SpendingTitle,
                x.SpendingAmount,
                x.SpendingDate,
                x.Categories.CategoryName
            }).ToList();
            dataGridView1.DataSource = spendingList;
        }

        private void btnCreateSpending_Click(object sender, EventArgs e)
        {

        }
    }
}
