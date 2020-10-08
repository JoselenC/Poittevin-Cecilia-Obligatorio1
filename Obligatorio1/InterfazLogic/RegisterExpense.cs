using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace InterfazLogic
{
    public partial class RegisterExpense : UserControl
    {
        private Repository repository;
        public RegisterExpense(Repository vRepository)
        {
            InitializeComponent();
            repository = vRepository; 
        }

        private void CompleteCategories()
        {
            if (repository.Categories.Count == 0)
            {
                lblCategories.Text = "There are no categories registered in the system";
            }
            for (int i = 0; i < repository.Categories.Count; i++)
            {
                lstCategories.Items.Add(repository.Categories[i].Name);
            }
        }


        private void btnRegistrExpense_Click(object sender, EventArgs e)
        {
            try
            {
                string description = tbDescription.Text;
                double amount = decimal.ToDouble(nAmount.Value);
                DateTime creationDate = dateTime.Value;
                Expense expense = new Expense( amount, creationDate,description);
                Category category = repository.FindCategoryByDescription(description);
                if (expense.Category == null)
                {
                    CompleteCategories();
                    string categoryName= lstCategories.SelectedItem.ToString();
                    category = repository.FindCategoryByName(categoryName);
                }
               
                repository.addExpense(expense);
                lbDescription.Text = "";
                lblAmount.Text = "";
                lblCategories.Text = "";
                lblDate.Text = "";
            }
            catch (ExcepcionInvalidDescriptionLengthExpense)
            {
                lbDescription.Text = "The name must be between 3 and 20 characters long.";

            }
            catch (ExcepcionNegativeAmountExpense)
            {
                lblAmount.Text = "The amount must be positive";
            }
            catch (ExcepcionInvalidYearExpense)
            {
                lblDate.Text = "The year must be between 2018 and 2030.";
            }
            catch (ExcepcionExpenseWithEmptyCategory)
            {
                lblCategories.Text = "The category should not be empty ";
            }
        }
    }
}
