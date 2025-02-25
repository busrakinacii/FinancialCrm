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
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var categoryList = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName,
            }).ToList();
            dataGridView1.DataSource = categoryList;
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            //Category List Process
            //
            var categoryList = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName,
            }).ToList();
            dataGridView1.DataSource = categoryList;
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;
            Categories cat = new Categories();
            cat.CategoryName = categoryName;
            db.Categories.Add(cat);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sisteme Eklendi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Category List Process
            //
            var categoryList = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName,
            }).ToList();
            dataGridView1.DataSource = categoryList;
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var removeValue = db.Categories.Find(id);
            db.Categories.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sistemden Silindi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Category List Process
            //
            var categoryList = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName,
            }).ToList();
            dataGridView1.DataSource = categoryList;

        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string category = txtCategoryName.Text;
            int id = int.Parse(txtCategoryId.Text);
            var updateValue = db.Categories.Find(id);
            updateValue.CategoryName = category;
            db.SaveChanges();

            MessageBox.Show("Kategori Başarılı Bir Şekilde Sistemde Güncellendi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Category List Process
            //
            var categoryList = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName,
            }).ToList();
            dataGridView1.DataSource = categoryList;

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
            FrmBilling fr = new FrmBilling();
            fr.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard fr = new FrmDashboard();
            fr.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpending_Click(object sender, EventArgs e)
        {
            FrmDashboard fr = new FrmDashboard();
            fr.Show();
        }
    }
}

