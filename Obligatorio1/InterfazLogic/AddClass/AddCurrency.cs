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
        public AddCurrency(IManageRepository vRepository)
        {
            InitializeComponent();
            currencyController = new CurrencyController(vRepository);
        }

        private void TryAddNewCurrency()
        {
            string name = tbName.Text;
            string symbol = tbSymbol.Text;
            double quotation = (double)nQuotation.Value;
            currencyController.SetCurrency(name, symbol, quotation);
            Visible = false;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                TryAddNewCurrency();
            }
            catch (ExceptionAlreadyExistTheCurrencyName)
            {
                lblName.Text = "Already exist de currency name";
                lblName.ForeColor = Color.Red;
                lblSymbol.Text = "";
            }
            catch (ExceptionAlreadyExistTheCurrencySymbol)
            {
                lblSymbol.Text = "Already exist de currency symbol";
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

     
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
