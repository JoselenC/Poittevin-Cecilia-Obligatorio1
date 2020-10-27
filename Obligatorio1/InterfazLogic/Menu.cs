using BusinessLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InterfazLogic
{
    public partial class Menu : Form
    {
        private LogicController controller;
        public Menu(MemoryRepository repository)
        {
            InitializeComponent();
            controller = new LogicController(repository);
            MaximumSize = new Size(650, 400);
            MinimumSize = new Size(650, 400);
        }

        private void btnRegisterCategory_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl registerCategory = new RegisterCategory(controller.Repository);
            mainPanel.Controls.Add(registerCategory);
        }

        private void btnRegisterExpense_Click(object sender, EventArgs e)
        {
           mainPanel.Controls.Clear();
           UserControl registerExpense = new RegisterExpense(controller.Repository);
           mainPanel.Controls.Add(registerExpense);
        }

        private void btnExpenseReport_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl expenseReport = new ExpenseReport(controller.Repository);
            mainPanel.Controls.Add(expenseReport);
        }

        private void btnRegisterBudget_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl addBudgetForm = new AddAndEditBudget(controller.Repository);
            mainPanel.Controls.Add(addBudgetForm);
        }

        private void btnEditExpenses_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl editExpense = new EditExpense(controller.Repository);
            mainPanel.Controls.Add(editExpense);
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl editCategory= new EditCategory(controller.Repository);
            mainPanel.Controls.Add(editCategory);
        }     

        private void btnBudgetReport_Click_1(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl budgetReport = new BudgetReport(controller.Repository);
            mainPanel.Controls.Add(budgetReport);
        }
    }

}

