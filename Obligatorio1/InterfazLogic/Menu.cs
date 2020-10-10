using BusinessLogic;
using System;
using System.Windows.Forms;

namespace InterfazLogic
{
    public partial class Menu : Form
    {
        public Repository repository { get; set; }
        public Menu()
        {
            InitializeComponent();
            repository = new Repository();
        }

        private void btnRegisterCategory_Click(object sender, EventArgs e)
        {
        }
    }
}
