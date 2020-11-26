using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Repository;

namespace InterfazLogic
{
    public partial class RegisteredOBjects : UserControl
    {
        private CategoryController categoryController;
        private ExpenseController expenseController;
        public RegisteredOBjects(ManagerRepository vRepository)
        {
            InitializeComponent();
            categoryController = new CategoryController(vRepository);
            expenseController = new ExpenseController(vRepository);
            MaximumSize = new Size(500, 600);
            MinimumSize = new Size(500, 600);
            CompleteCategories();
            Completecurrency();
            CompleteExpenses();
        }

        private void CompleteCategories()
        {
            if (categoryController.GetCategories().Count > 0)
            {
                foreach (Category category in categoryController.GetCategories())
                {
                    lstCatgories.Items.Add(category);
                }
            }
            else
            {
                lblCategories.Text = "There are no expenses registered in the system";
                lblCategories.ForeColor = Color.Red;
            }
        }

        private void Completecurrency()
        {
            foreach (Currency vcurrency in expenseController.GetCurrencies())
            {
                lstCurrencies.Items.Add(vcurrency);
            }
        }

        private void CompleteExpenses()
        {
            if (expenseController.GetExpenses().Count > 0)
            {
                foreach (Expense expense in expenseController.GetExpenses())
                {
                    lstExpenses.Items.Add(expense);
                }
            }
            else
            {
                lblExpenses.Text="There are no expenses registered in the system";
                lblExpenses.ForeColor = Color.Red;
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
