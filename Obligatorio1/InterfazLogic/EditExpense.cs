﻿using System;
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
    public partial class EditExpense : UserControl
    {
        private LogicController logicController;
        private int indexToEdit;
        private string descriptionExpense;
        private bool edit;
        private Expense expenseToEdit;
        public EditExpense(Repository vRepository)
        {
            InitializeComponent();
            logicController = new LogicController(vRepository);
            this.MaximumSize = new Size(800, 800);
            this.MinimumSize = new Size(800, 800);
            lstCategories.Visible = false;
            indexToEdit = -1;
            descriptionExpense="";
            edit = false;
            CompleteExpense();

        }
        private void CompleteExpense()
        {
            if (logicController.GetExpenses().Count > 0)
            {
                foreach (Expense expense in logicController.GetExpenses()) {
                    lstExpenses.Items.Add(expense);
                }
            }
            else
            {
                MessageBox.Show("There are no expenses registered in the system");
                Visible = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstExpenses.SelectedIndex >= 0)
            {
               descriptionExpense = lstExpenses.SelectedItem.ToString();
               expenseToEdit = logicController.FindExpense(descriptionExpense);
               tbDescription.Text = expenseToEdit.Description;
               nAmount.Value = (decimal)(expenseToEdit.Amount);
               dateTime.Value = expenseToEdit.CreationDate;
               lblCategory.Text = expenseToEdit.Category.ToString();
               indexToEdit = lstExpenses.SelectedIndex;
               
            }
            else if (logicController.GetExpenses().Count == 0)
            {
                lblExpenses.Text = "There are no more expenses to edit";
                lblExpenses.ForeColor = Color.Red;
            }
            else
            {
                lblExpenses.Text = "Select expense to edit";
                lblExpenses.ForeColor = Color.Red;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstExpenses.SelectedIndex >= 0)
            {
                logicController.DeleteExpense(lstExpenses.SelectedItem.ToString());
                int index = lstExpenses.SelectedIndex;
                lstExpenses.Items.RemoveAt(index);
            }
            else if (logicController.GetExpenses().Count == 0)
            {
                lblExpenses.Text = "There are no more expenses to delete";
                lblExpenses.ForeColor = Color.Red;
            }
            else
            {
                lblExpenses.Text = "Select expense to delete";
                lblExpenses.ForeColor = Color.Red;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                TryRegisterNewExpense();
            }
            catch (ExcepcionInvalidDescriptionLengthExpense)
            {
                lbDescription.Text = "The name must be between 3 and 20 characters long.";
                lbDescription.ForeColor = Color.Red;
            }
            catch (ExcepcionNegativeAmountExpense)
            {
                lblAmount.Text = "The amount must be positive";
                lblAmount.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidAmountExpense)
            {
                lblAmount.Text = "The amount cannot have more than two decimal places";
                lblAmount.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidYearExpense)
            {
                lblDate.Text = "The year must be between 2018 and 2030.";
                lblDate.ForeColor = Color.Red;
            }
            catch (ExcepcionExpenseWithEmptyCategory)
            {
                lblCategories.Text = "The category should not be empty ";
                lblCategories.ForeColor = Color.Red;
            }
        }

        private void TryRegisterNewExpense()
        {
            Category category = new Category();
            if (lstCategories.SelectedIndex < 0 && edit)
            {
                lblCategories.Text = "You must select a category";
                lblCategories.ForeColor = Color.Red;
            }
            else if (lstCategories.SelectedIndex >= 0 && edit)
            {
                string nameCategory = lstCategories.SelectedItem.ToString();
                category = logicController.FindCategoryByName(nameCategory);
                string description = tbDescription.Text;
                double amount = decimal.ToDouble(nAmount.Value);
                DateTime creationDate = dateTime.Value;
                logicController.SetExpense(amount, creationDate, description, category);
                MessageBox.Show("The expense was recorded successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
                if (indexToEdit >= 0)
                {
                    lstExpenses.Items.RemoveAt(indexToEdit);
                    logicController.DeleteExpense(descriptionExpense);
                }
            }
            else
            {
                category = expenseToEdit.Category;
                string description = tbDescription.Text;
                double amount = decimal.ToDouble(nAmount.Value);
                DateTime creationDate = dateTime.Value;
                logicController.SetExpense(amount, creationDate, description, category);
                MessageBox.Show("The expense was recorded successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
                if (indexToEdit >= 0)
                {
                    lstExpenses.Items.RemoveAt(indexToEdit);
                    logicController.DeleteExpense(descriptionExpense);
                }
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            lstCategories.Visible = true;
            foreach (Category category in logicController.GetCategories())
            {
                lstCategories.Items.Add(category);
            }
            edit = true;
        }
    }
}