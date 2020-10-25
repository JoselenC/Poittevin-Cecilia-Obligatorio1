using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace InterfazLogic
{
    public partial class EditKeyWord : Form
    {
        public List<string> keyWords { get; set; }

        public int index { get; set; }

        private LogicController logicController;

        public bool edited { get; set; } = false;

        private ListBox lstkw;

        public EditKeyWord(List<string> vKeyWords,int indexToEdit,ListBox lstkeyWords, LogicController vLogicController)
        {            
            InitializeComponent();
            keyWords = vKeyWords;
            index = indexToEdit;
            lstkw = lstkeyWords;
            logicController = vLogicController;
            this.MaximumSize = new Size(380, 200);
            this.MinimumSize = new Size(380, 200);
            StartPosition = FormStartPosition.CenterScreen;
            tbEdit.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string keyWordEdited = tbEdit.Text;
            if (keyWordEdited != "")
            {
                if (keyWords.Contains(keyWordEdited))
                {
                    lblKeyWord.Text = "You already entered that keyword";
                    lblKeyWord.ForeColor = Color.Red;
                }
                else if (logicController.AlreadyExistKeyWordInAnoterCategory(keyWordEdited))
                {
                    lblKeyWord.Text = "You already entered that keyword in another category";
                    lblKeyWord.ForeColor = Color.Red;
                }
                else
                {
                    keyWords.RemoveAt(index);
                    keyWords.Add(tbEdit.Text);
                    lstkw.Items.RemoveAt(index);
                    lstkw.Items.Add(keyWordEdited);
                    Close();
                }
            }
            else
            {
                lblKeyWord.Text = "The keyword cannot be empty";
                lblKeyWord.ForeColor = Color.Red;
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
