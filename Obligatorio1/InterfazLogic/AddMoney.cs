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
    public partial class AddMoney : UserControl
    {
        private MoneyController moneyController;
        public AddMoney(MemoryRepository vRepository)
        {
            InitializeComponent();
            moneyController = new MoneyController(vRepository);
        }       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                TryAddNewMoney();
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

        private void TryAddNewMoney()
        {
            string name = tbName.Text;
            string symbol = tbSymbol.Text;
            double quotation = (double)nQuotation.Value;
            moneyController.setMoney(name, symbol, quotation);
            Visible = false;
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
