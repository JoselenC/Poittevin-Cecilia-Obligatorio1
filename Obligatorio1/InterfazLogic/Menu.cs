using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace InterfazLogic
{
    public partial class Menu : Form
    {
        public Repository repository { get; set; }
        public Menu()
        {
            InitializeComponent();
            repository = new Repository();
            this.MaximumSize = new Size(650, 400);
            this.MinimumSize = new Size(650, 400);
        }

        private void btnRegisterCategory_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
           UserControl registerCategory = new RegisterCategory(repository);
            mainPanel.Controls.Add(registerCategory);
        }

        private void btnRegisterExpense_Click(object sender, EventArgs e)
        {
           mainPanel.Controls.Clear();
           UserControl registerExpense = new RegisterExpense(repository);
            mainPanel.Controls.Add(registerExpense);
        }

        private void btnExpenseReport_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl expenseReport = new ExpenseReport(repository);
            mainPanel.Controls.Add(expenseReport);
        }


        private void btnRegisterBudget_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl addBudgetForm = new AddAndEditBudget(repository);
            mainPanel.Controls.Add(addBudgetForm);
        }

        private void btnEditExpenses_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl editExpense = new EditExpense(repository);
            mainPanel.Controls.Add(editExpense);
        }
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl editCategory= new EditCategory(repository);
            mainPanel.Controls.Add(editCategory);
        }

      

        private void btnBudgetReport_Click_1(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl budgetReport = new BudgetReport(repository);
            mainPanel.Controls.Add(budgetReport);
        }
    }

}

