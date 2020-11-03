using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazLogic
{
    public partial class Archive : Form
    {
        public string NameArchive { get; set; }
        public string Route { get; set; }

        ExpenseReport expense;
        public Archive(ExpenseReport expenseReport)
        {
            InitializeComponent();
            tbRoute.Text=@"D:\";
            expense = expenseReport;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NameArchive = tbName.Text;
            Route=tbRoute.Text;
            expense.name = NameArchive;
            expense.route = Route;
            Close();
        }
    }
}
