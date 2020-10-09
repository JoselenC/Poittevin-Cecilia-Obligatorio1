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
    public partial class ExpenseReport : UserControl
    {
        private Repository repository;
        public ExpenseReport(Repository vRepository)
        {
            InitializeComponent();
            repository = vRepository;
            monthsWithExpenses();

        }

        private void monthsWithExpenses(){
            List <string> months= repository.MonthsOrdered();
            for (int i = 0; i < months.Count; i++)
            {
                lstMonths.Items.Add(months[i]);
            }
        }


        private void btnConsult_Click(object sender, EventArgs e)
        {
           

        }
    }
}
