using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Repository;
using BusinessLogic;

namespace InterfazLogic
{
    public partial class AddCurrency : UserControl
    {
        private CurrencyController currencyController;
        public AddCurrency(ManagerRepository vRepository)
        {
            InitializeComponent();
            currencyController = new CurrencyController(vRepository);
        }

        private void TryAddNewCurrency()
        {
            string name = tbName.Text;
            string symbol = tbSymbol.Text;
            double quotation = (double)nQuotation.Value;
            Currency currency = new Currency() { Name = name, Quotation = quotation, Symbol = symbol };
            currencyController.SetCurrency(currency);
            MessageBox.Show("Currency" + name + " was register successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Visible = false;

        }

        private void SetMessage(string messsage, Label lblToSetMessage)
        {
            if(lblToSetMessage!=lblName)
                lblName.Text = "";
            if (lblToSetMessage!=lblSymbol)
              lblSymbol.Text = "";
            if (lblToSetMessage != lblQuotation)
                lblQuotation.Text = "";
            lblToSetMessage.Text = messsage;
            lblToSetMessage.ForeColor = Color.Red;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                TryAddNewCurrency();
            }
            catch (ExceptionUnableToSaveData)
            {
                SetMessage("Already exist de currency name", lblName);
            }
            catch (ExceptionAlreadyExistTheCurrencyName)
            {
                SetMessage("Already exist de currency name", lblName);
            }
            catch (ExceptionAlreadyExistTheCurrencySymbol)
            {
                SetMessage("Already exist de currency symbol",lblSymbol);
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
                SetMessage("The quotation must be positive",lblQuotation);
            }
            catch (ExceptionInvalidQuotation)
            {
                SetMessage("The quotation cannot have more than two decimal places.", lblSymbol);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
