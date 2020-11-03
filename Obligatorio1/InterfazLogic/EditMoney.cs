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
    public partial class EditMoney : UserControl
    {
        private MoneyController moneyController;
        public EditMoney(MemoryRepository vRepository)
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
                Money money = moneyController.FindMoney((Money)lstMonies.SelectedItem);
                tbName.Text = money.Name;
                tbSymbol.Text = money.Symbol;
                nQuotation.Value = (decimal)money.Quotation;

            }
            catch (NoFindMoney)
            {
                lblMonies.Text = "";
            }
        }


        private void DeleteMoney()
        {
            moneyController.DeleteMoney((Money)lstMonies.SelectedItem);
            lstMonies.Items.RemoveAt(lstMonies.SelectedIndex);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {            
            string name = tbName.Text;
            string symbol = tbSymbol.Text;
            double quotation = (double)nQuotation.Value;
            moneyController.setMoney(name, symbol, quotation);
            Visible = false;
            DeleteMoney();
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
