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

        public bool edited { get; set; } = false;
        private ListBox lstkw;
        public EditKeyWord(List<string> vKeyWords,int indexToEdit,ListBox lstkeyWords)
        {
            
            InitializeComponent();
            keyWords = vKeyWords;
            index = indexToEdit;
            lstkw = lstkeyWords;
            this.MaximumSize = new Size(380, 200);
            this.MinimumSize = new Size(380, 200);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string keyWordEdited = tbEdit.Text;
            if (keyWordEdited != "")
            {

                keyWords.RemoveAt(index);
                keyWords.Add(tbEdit.Text);
               lstkw.Items.RemoveAt(index);
                lstkw.Items.Add(keyWords[index]);
                
                Close();
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
