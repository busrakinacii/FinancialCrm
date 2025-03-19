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

            FrmSpendings fr = new FrmSpendings();
            fr.Show();
        }
        void spendingList()
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
        private void btnSpendingList_Click(object sender, EventArgs e)
        {
            spendingList();
        }

        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            spendingList();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DataSource = db.Categories.ToList();
        }

        private void btnCreateSpending_Click(object sender, EventArgs e)
        {
            string spendingTitle = txtSpendingTitle.Text;
            decimal spendingAmount = decimal.Parse(txtSpendingAmount.Text);
            DateTime spendingDate = DateTime.Parse(txtSpendingDate.Text);
            int categoryID = int.Parse(cmbCategory.SelectedValue.ToString());

            Spendings spendings = new Spendings();
            spendings.SpendingTitle = spendingTitle;
            spendings.SpendingAmount = spendingAmount;
            spendings.SpendingDate = spendingDate;
            spendings.CategoryId = categoryID;

            db.Spendings.Add(spendings);
            db.SaveChanges();
            MessageBox.Show("Giderler Başarılı Bir Şekilde Sisteme Eklendi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //spendings List Process
            //
            spendingList();

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemoveSpending_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingId.Text);
            var removeValue = db.Spendings.Find(id);
            db.Spendings.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Giderler Başarılı Bir Şekilde Sistemden Silinmiştir.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //spendings List Process
            //
            spendingList();
        }

        private void btnUpdateSpending_Click(object sender, EventArgs e)
        {
            string spendingTitle = txtSpendingTitle.Text;
            decimal spendingAmount = decimal.Parse(txtSpendingAmount.Text);
            DateTime spendingDate = DateTime.Parse(txtSpendingDate.Text);
            int CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            int Id = int.Parse(txtSpendingId.Text);

            var values = db.Spendings.Find(Id);
            values.SpendingDate = spendingDate;
            values.SpendingAmount = spendingAmount;
            values.SpendingTitle = spendingTitle;
            values.CategoryId = CategoryId;
            db.SaveChanges();
            MessageBox.Show("Giderler Başarılı Bir Şekilde Sistemde Güncellenmiştir.", "UYARI && GİDERLER", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //spendings List Process
            //
            spendingList();
        }
    }
}
