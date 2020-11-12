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
using BusinessLogic.Repository;

namespace InterfazLogic
{
    public partial class EditMoney : UserControl
    {
        private MoneyController moneyController;
        private Money moneyToEdit;
        public EditMoney(IManageRepository vRepository)
        {
            InitializeComponent();
            moneyController = new MoneyController(vRepository);
            CompleteMoney();
        }

        private void CompleteMoney()
        {
            if (moneyController.GetMonies().Count == 1)
            {
                MessageBox.Show("There are no moneis registered in the system");
                Visible = false;
            }
            else
            {
                for (int i = 1; i < moneyController.GetMonies().Count; i++)
                {
                    lstMonies.Items.Add(moneyController.GetMonies()[i]);
                }
            }
           
        }

        private void Edit()
        {
            try
            {
                moneyToEdit = moneyController.FindMoney((Money)lstMonies.SelectedItem);
                tbName.Text = moneyToEdit.Name;
                tbSymbol.Text = moneyToEdit.Symbol;
                nQuotation.Value = (decimal)moneyToEdit.Quotation;

            }
            catch (NoFindMoney)
            {
                lblMonies.Text = "";
            }
        }


        private void DeleteMoney()
        {
            try
            {
                moneyController.DeleteMoney((Money)lstMonies.SelectedItem);
                lstMonies.Items.RemoveAt(lstMonies.SelectedIndex);
            }
            catch
            {
                lblMonies.Text = "The money selected to delete is being used";
                lblMonies.ForeColor = Color.Red;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Text;
                string symbol = tbSymbol.Text;
                double quotation = (double)nQuotation.Value;
                moneyController.EditMoney(moneyToEdit, name, symbol, quotation);
                Visible = false;
            }
            catch (ExceptionAlreadyExistTheMoneyName)
            {
                lblName.Text = "Already exist de money name";
                lblName.ForeColor = Color.Red;
                lblSymbol.Text = "";
            }
            catch (ExceptionAlreadyExistTheMoneySymbol)
            {
                lblSymbol.Text = "Already exist de money symbol";
                lblSymbol.ForeColor = Color.Red;
                lblName.Text = "";
            }
            catch (ExceptionInvalidLengthMoneyName)
            {
                lblName.Text = "The name must be between 3 and 20 characters long.";
                lblName.ForeColor = Color.Red;
                lblSymbol.Text = "";
            }
            catch (ExceptionInvalidLengthSymbol)
            {
                lblSymbol.Text = "The symbol must be between 3 and 20 characters long.";
                lblSymbol.ForeColor = Color.Red;
                lblName.Text = "";
            }
            catch (ExceptionNegativeQuotation)
            {
                lblQuotation.Text = "The quotation must be positive";
                lblQuotation.ForeColor = Color.Red;
                lblSymbol.Text = "";
                lblName.Text = "";
            }
            catch (ExceptionInvalidQuotation)
            {
                lblSymbol.Text = "The quotation cannot have more than two decimal places.";
                lblQuotation.ForeColor = Color.Red;
                lblSymbol.Text = "";
                lblName.Text = "";

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void btnEditMoney_Click_1(object sender, EventArgs e)
        {
            if (lstMonies.SelectedIndex >= 0)
                Edit();
            else
            {
                lblMonies.Text = "Select a category to edit";
                lblMonies.ForeColor = Color.Red;
            }                
           
        }

        private void btnDeleteMoney_Click_1(object sender, EventArgs e)
        {
            if (lstMonies.SelectedIndex >= 0)
                DeleteMoney();
            else
            {
                lblMonies.Text = "Select a category to delete";
                lblMonies.ForeColor = Color.Red;
            }
        }
    }
}
