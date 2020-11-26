using BusinessLogic;
using BusinessLogic.Repository;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace InterfazLogic
{
    public partial class Menu : Form
    {
        private readonly ManagerRepository repository;
        public Menu(ManagerRepository repository)
        {
            this.repository = repository;

            InitializeComponent();
            MaximumSize = new Size(630, 530);
            MinimumSize = new Size(630, 530);
        }

        private void BtnRegisterCategory_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl registerCategory = new RegisterCategory(repository);
            mainPanel.Controls.Add(registerCategory);
        }

        private void BtnRegisterExpense_Click(object sender, EventArgs e)
        {
           mainPanel.Controls.Clear();
           UserControl registerExpense = new RegisterExpense(repository);
           mainPanel.Controls.Add(registerExpense);
        }

        private void BtnExpenseReport_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl expenseReport = new ExpenseReport(repository);
            mainPanel.Controls.Add(expenseReport);
        }

        private void BtnRegisterBudget_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl addBudgetForm = new AddAndEditBudget(repository);
            mainPanel.Controls.Add(addBudgetForm);
        }

        private void BtnEditExpenses_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl editExpense = new EditExpense(repository);
            mainPanel.Controls.Add(editExpense);
        }

        private void BtnEditCategory_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl editCategory= new EditCategory(repository);
            mainPanel.Controls.Add(editCategory);
        }     

        private void BtnBudgetReport_Click_1(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl budgetReport = new BudgetReport(repository);
            mainPanel.Controls.Add(budgetReport);
        }

        private void BtnAddCurrency_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl addCurrency = new AddCurrency(repository); ;
            mainPanel.Controls.Add(addCurrency);
        }

        private void BtnEditCurrency_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl editCurrency = new EditCurrency(repository); ;
            mainPanel.Controls.Add(editCurrency);
        }

        private void BRegisteredObjects_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl registeredObjects = new RegisteredOBjects(repository);
            mainPanel.Controls.Add(registeredObjects);
        }
    }

}

