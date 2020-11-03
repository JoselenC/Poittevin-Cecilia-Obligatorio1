using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;
using System.IO;
using System;

namespace InterfazLogic
{
    public partial class ExpenseReport : UserControl
    {
        private ExpenseController expenseController;

        public List<Expense> expenseReportByMonth;
        public ExpenseReport(MemoryRepository vRepository)
        {
            InitializeComponent();
            expenseController = new ExpenseController(vRepository);
            monthsWithExpenses();
            MaximumSize = new Size(500, 650);
            MinimumSize = new Size(500, 650);
            btnExportar.Enabled = false;
            lstType.Items.Add("TXT");
            lstType.Items.Add("CSV");
            lstType.SelectedIndex = 0;
            lstMonths.SelectedIndex = 0;
        }

        private void monthsWithExpenses(){
            lblMonths.Text = "";
            List <string> months= expenseController.OrderedMonthsWithExpenses();
            if (months.Count < 1)
            {
                MessageBox.Show("There are no expenses registered in the system");
                Visible = false;
            }
            else
            {
                foreach (string month in months)
                {
                    lstMonths.Items.Add(month);
                }
                Visible = true;
            }
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            double totalAmount = 0;
            if (lstMonths.SelectedIndex >= 0)
            {
                lblMonths.Text = "";
                string month = lstMonths.SelectedItem.ToString();
                if (month.Length == 0)
                {
                    lblMonths.Text = "You must select a month to consult";
                    lblMonth.ForeColor = Color.Red;
                }
                expenseReportByMonth = expenseController.GetExpenseByMonth(month);
                listView1.Items.Clear();
                ListViewItem item = new ListViewItem();
                foreach(Expense vExpense in expenseReportByMonth)
                {
                    string date = vExpense.CreationDate.ToString("dd/MM/yyyy");
                    string description = vExpense.Description;
                    string name = vExpense.Category.Name;
                    string money = vExpense.Money.Symbol;
                    string amount = vExpense.Amount.ToString();
                        totalAmount += vExpense.ConvertToPesos();
                        item = listView1.Items.Add(date);
                        item.SubItems.Add(description);
                        item.SubItems.Add(name);
                        item.SubItems.Add(money);
                        item.SubItems.Add(amount);                   

                }                
                lblTotalAmount.Text = "Total amount of the month " + month + " was " + totalAmount.ToString();
            }
            else
            {
                lblMonths.Text = "Select a month to consult";
                lblMonth.ForeColor = Color.Red;
            }
            btnExportar.Enabled = true;
        }

      

        private void btnAccept_Click(object sender, EventArgs e)
        {
           Visible = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if(lstType.SelectedItem.ToString()=="TXT")
                GenerarTXT();
            else if (lstType.SelectedItem.ToString() =="CSV")
                GenerarCSV();
        }

        void GenerarTXT()
        {
                    
            Archive archive = new Archive();
            string name = archive.Name;
            string route = archive.Route;
            string rutaCompleta = @" D:\" + name + ".txt";
            using (StreamWriter mylogs = File.AppendText(rutaCompleta))
            {
                foreach (Expense vExpense in expenseReportByMonth)
                {
                    mylogs.WriteLine(vExpense.CreationDate.ToString("dd/MM/yyyy"));
                    mylogs.WriteLine(vExpense.Description);
                    mylogs.WriteLine(vExpense.Category.Name);
                    mylogs.WriteLine(vExpense.Money.Symbol);
                    mylogs.WriteLine(vExpense.Amount.ToString());
                    mylogs.WriteLine("####");
                }

            }
        }

        void GenerarCSV()
        {

            Archive archive = new Archive();
            string name = archive.Name;
            string route = archive.Route;
            string rutaCompleta = @" D:\" + name + ".csv";
            using (StreamWriter mylogs = File.AppendText(rutaCompleta))
            {
                foreach (Expense vExpense in expenseReportByMonth)
                {
                    mylogs.WriteLine(vExpense.CreationDate.ToString("dd/MM/yyyy")+","+ vExpense.Description+","+
                        vExpense.Category.Name+","+ vExpense.Money.Symbol+","+ vExpense.Amount.ToString());
                }

            }
        }
    }
}
