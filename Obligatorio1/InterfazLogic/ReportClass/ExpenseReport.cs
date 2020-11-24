using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;
using System.IO;
using BusinessLogic.Repository;
using BusinessLogic.Domain;

namespace InterfazLogic
{
    public partial class ExpenseReport : UserControl
    {
        private ExpenseController expenseController;

        public List<Expense> expenseReportByMonth;
        public string name;
        public string route;
        public ExpenseReport(IManageRepository vRepository)
        {
            InitializeComponent();
            expenseController = new ExpenseController(vRepository);
            monthsWithExpenses();
            MaximumSize = new Size(500, 650);
            MinimumSize = new Size(500, 650);
            btnExportar.Enabled = false;
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
                BusinessLogic.Domain.ExpenseReport expenseReport = expenseController.GetExpenseReport(month);

                listView1.Items.Clear();
                ListViewItem item = new ListViewItem();
                foreach(ExpenseReportLine vExpense in expenseReport.ExpenseReportLine)
                {
                        item = listView1.Items.Add(vExpense.CreationDate.ToString("dd/MM/yyyy"));
                        item.SubItems.Add(vExpense.Description);
                        item.SubItems.Add(vExpense.Category.ToString());
                        item.SubItems.Add(vExpense.Currency.Symbol);
                        item.SubItems.Add(vExpense.Amount.ToString());                   

                }
                lblTotalAmount.Text = "Total amount of the month " + month + " in pesos was " + expenseReport.TotalAmount.ToString();
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

        private void btnExportar_Click(object sender2, EventArgs e)
        {
           
            SaveFileDialog saveFile = new SaveFileDialog();
            string fileName;
            saveFile.Title = "Export Report";
            saveFile.Filter = "Txt File (.txt)| *.txt|Csv File (.csv)| *.csv";  
            fileName = saveFile.FileName.ToString();
            saveFile.ShowDialog();
            string extension = Path.GetExtension(fileName);
            switch (extension)
            {
                case ".txt":
                    expenseController.ExportExpenseReport(expenseReportByMonth, fileName, "txt");
                    break;
                case ".csv":
                    expenseController.ExportExpenseReport(expenseReportByMonth, fileName, "csv");
                    break;
                default:
                    MessageBox.Show("Select a correct type to export expens report" );
                    break;
            }
                                  
        }

      
    }
}
