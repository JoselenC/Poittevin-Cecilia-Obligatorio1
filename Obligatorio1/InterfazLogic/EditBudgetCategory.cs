using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InterfazLogic
{
    public partial class EditBudgetCategory : Form
    {
        private BudgetCategory CurrentBudgetCategory { get; set; }
        private AddBudgetForm OriginForm { get; set; }
        public EditBudgetCategory(BudgetCategory budgetCategory, AddBudgetForm originForm)
        {
            InitializeComponent();
            OriginForm = originForm;
            CurrentBudgetCategory = budgetCategory;
            labelCategoryName.Text = budgetCategory.Category.Name;
            numericAmount.Value = (decimal) budgetCategory.Amount;
            this.MaximumSize = new Size(380, 200);
            this.MinimumSize = new Size(380, 200);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentBudgetCategory.Amount = (double) numericAmount.Value;
            OriginForm.Refresh();
            Close();
        }

    }
}
