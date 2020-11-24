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
    public partial class EditCurrency : UserControl
    {
        private CurrencyController currencyController;
        private Currency currencyToEdit;
        public EditCurrency(IManageRepository vRepository)
        {
            InitializeComponent();
            currencyController = new CurrencyController(vRepository);
            CompleteCurrency();
        }

        private void CompleteCurrency()
        {
            if (currencyController.GetCurrencies().Count == 1)
            {
                MessageBox.Show("There are no currencies registered in the system");
                Visible = false;
            }
            else
            {
                for (int i = 1; i < currencyController.GetCurrencies().Count; i++)
                {
                    lstCurrencies.Items.Add(currencyController.GetCurrencies()[i]);
                }
            }           
        }

        private void Edit()
        {
            try
            {
                currencyToEdit = currencyController.FindCurrency((Currency)lstCurrencies.SelectedItem);
                tbName.Text = currencyToEdit.Name;
                tbSymbol.Text = currencyToEdit.Symbol;
                nQuotation.Value = (decimal)currencyToEdit.Quotation;

            }
            catch (NoFindCurrency)
            {
                lblcurrencies.Text = "";
            }
        }


        private void DeleteCurrency()
        {
            try
            {
                currencyController.DeleteCurrency((Currency)lstCurrencies.SelectedItem);
                lstCurrencies.Items.RemoveAt(lstCurrencies.SelectedIndex);
            }
            catch
            {
                lblcurrencies.Text = "The currency selected to delete is being used";
                lblcurrencies.ForeColor = Color.Red;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Text;
                string symbol = tbSymbol.Text;
                double quotation = (double)nQuotation.Value;
                Currency newCurrency = new Currency()
                {
                    Name = name,
                    Symbol = symbol,
                    Quotation = quotation
                };
                currencyController.UpdateCurrency(currencyToEdit, newCurrency);
                Visible = false;
            }
            catch (ExceptionUnableToSaveData)
            {
                lblName.Text = "Already exist de currency name";
                lblName.ForeColor = Color.Red;
                lblSymbol.Text = "";
            }
            catch (ExceptionAlreadyExistTheCurrencySymbol)
            {
                lblSymbol.Text = "Already exist de currencysymbol";
                lblSymbol.ForeColor = Color.Red;
                lblName.Text = "";
            }
            catch (ExceptionInvalidLengthCurrencyName)
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }      

        private void BtnDeletecurrency_Click(object sender, EventArgs e)
        {
            if (lstCurrencies.SelectedIndex >= 0)
                DeleteCurrency();
            else
            {
                lblcurrencies.Text = "Select a category to delete";
                lblcurrencies.ForeColor = Color.Red;
            }
        }

        private void BtnEditcurrency_Click(object sender, EventArgs e)
        {
            if (lstCurrencies.SelectedIndex >= 0)
                Edit();
            else
            {
                lblcurrencies.Text = "Select a category to edit";
                lblcurrencies.ForeColor = Color.Red;
            }
        }
    }
}
