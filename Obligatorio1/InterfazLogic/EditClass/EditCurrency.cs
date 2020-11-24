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

        private void SetMessage(string messsage, Label lblToSetMessage)
        {
            if (lblToSetMessage != lblName)
                lblName.Text = "";
            if (lblToSetMessage != lblcurrencies)
                lblcurrencies.Text = "";
            if (lblToSetMessage != lblQuotation)
                lblQuotation.Text = "";
            if (lblToSetMessage != lblSymbol)
                lblSymbol.Text = "";
            lblToSetMessage.Text = messsage;
            lblToSetMessage.ForeColor = Color.Red;
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
                SetMessage("The currency selected to delete is being used", lblcurrencies);
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
                SetMessage("Already exist de currency name", lblName);
            }
            catch (ExceptionAlreadyExistTheCurrencySymbol)
            {
                SetMessage("Already exist de currencysymbol", lblSymbol);
            }
            catch (ExceptionInvalidLengthCurrencyName)
            {
                SetMessage("The name must be between 3 and 20 characters long.", lblName);
            }
            catch (ExceptionInvalidLengthSymbol)
            {
                SetMessage("The symbol must be between 3 and 20 characters long.", lblSymbol);
            }
            catch (ExceptionNegativeQuotation)
            {
                SetMessage("The quotation must be positive", lblQuotation);
            }
            catch (ExceptionInvalidQuotation)
            {
                SetMessage("The quotation cannot have more than two decimal places.", lblQuotation);

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
                SetMessage("Select a category to delete", lblcurrencies);
            }
        }

        private void BtnEditcurrency_Click(object sender, EventArgs e)
        {
            if (lstCurrencies.SelectedIndex >= 0)
                Edit();
            else
            {
                SetMessage("Select a category to edit", lblcurrencies);
            }
        }
    }
}
