using BusinessLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InterfazLogic
{
    public partial class Menu : Form
    {
        private BudgetController categoryController;
        private BudgetController expenseController;
        private BudgetController budgetController;
        private MoneyController moneyController;
        public Menu(MemoryRepository repository)
        {
            InitializeComponent();
            categoryController = new BudgetController(repository);
            expenseController = new BudgetController(repository);
            budgetController = new BudgetController(repository);
            moneyController = new MoneyController (repository);
            MaximumSize = new Size(615, 500);
            MinimumSize = new Size(615, 500);
        }

        private void btnRegisterCategory_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl registerCategory = new RegisterCategory(categoryController.Repository);
            mainPanel.Controls.Add(registerCategory);
        }

        private void btnRegisterExpense_Click(object sender, EventArgs e)
        {
           mainPanel.Controls.Clear();
           UserControl registerExpense = new RegisterExpense(expenseController.Repository);
           mainPanel.Controls.Add(registerExpense);
        }

        private void btnExpenseReport_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl expenseReport = new ExpenseReport(expenseController.Repository);
            mainPanel.Controls.Add(expenseReport);
        }

        private void btnRegisterBudget_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl addBudgetForm = new AddAndEditBudget(budgetController.Repository);
            mainPanel.Controls.Add(addBudgetForm);
        }

        private void btnEditExpenses_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl editExpense = new EditExpense(expenseController.Repository);
            mainPanel.Controls.Add(editExpense);
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl editCategory= new EditCategory(categoryController.Repository);
            mainPanel.Controls.Add(editCategory);
        }     

        private void btnBudgetReport_Click_1(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl budgetReport = new BudgetReport(budgetController.Repository);
            mainPanel.Controls.Add(budgetReport);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl addMoney = new AddMoney(moneyController.Repository); ;
            mainPanel.Controls.Add(addMoney);
        }

        private void btnEditMoney_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            UserControl editMoney = new EditMoney(moneyController.Repository); ;
            mainPanel.Controls.Add(editMoney);
        }
    }

}

