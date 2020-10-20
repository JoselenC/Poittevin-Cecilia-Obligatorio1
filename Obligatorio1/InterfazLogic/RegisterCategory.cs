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
    public partial class RegisterCategory : UserControl
    {
        private LogicController logicController;

        public string keyWordToEdit { get; set; }
        public List<string> keyWords { get; set; }
        public RegisterCategory(Repository vRepository)
        {
            InitializeComponent();
            logicController = new LogicController(vRepository);
            keyWords = new List<string>();
            tbEdit.Visible = false;
            this.MaximumSize = new Size(800, 800);
            this.MinimumSize = new Size(800, 800);
            lstCategories.Items.Clear();
            tbName.Clear();
        }


        private void btnRegisterCategory_Click(object sender, EventArgs e)
        {
            try
            {
                logicController.SetCategory(tbName.Text, keyWords);                
                lblKeyWords.Text = "";
                lblKeyWordToEdit.Text = "";
                lblName.Text = "";
                MessageBox.Show("Category " + tbName.Text + " was added successfully","",MessageBoxButtons.OK,MessageBoxIcon.Information);                
                this.Visible = false;
            }
            catch (ExcepcionInvalidNameLengthCategory)
            {
                lblName.Text = "The name must be between 3 and 15 characters long.";
                lblName.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidNameDigitCategory)
            {
                lblName.Text = "The name of the category cannot be just numbers.";
                lblName.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidRepeatedNameCategory)
            {
                lblName.Text = "The entered name already exists.";
                lblName.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidRepeatedKeyWordsCategory)
            {
                lblKeyWords.Text = "The entered keyword already exists in another category, edit or delete it.";
                lblKeyWords.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidKeyWordsLengthCategory)
            {
                lblKeyWords.Text = "You cannot add more than 10 keywords.";
                lblKeyWords.ForeColor = Color.Red;
            }           

        }


        private void btnAddKeyWord_Click(object sender, EventArgs e)
        {
            string keyWord = tbKeyWord.Text;
            if (keyWord.Length > 0)
            {
                if (keyWords.Contains(keyWord.ToLower()))
                {
                    lblKeyWords.Text = "You already entered that keyword";
                    lblKeyWords.ForeColor = Color.Red;
                }
                else if (keyWords.Count > 10)
                {
                    lblKeyWords.Text = "You cannot add more than 10 keywords.";
                    lblKeyWords.ForeColor = Color.Red;
                }
                else if (logicController.AlreadyExistThisKeyWordInAnoterCategory(keyWord))
                {
                    lblKeyWords.Text = "You already entered that keyword in another category";
                    lblKeyWords.ForeColor = Color.Red;
                }
                else
                {
                    this.keyWords.Add(keyWord);
                    lstCategories.Items.Add(keyWord);
                    tbKeyWord.Text = "";
                    lblKeyWords.Text = "";
                }
            }
            else
            {
                lblKeyWords.Text = "The keyword cannot be empty.";
                lblKeyWords.ForeColor = Color.Red;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (keyWords.Count > 0)
                {
                    int index = lstCategories.SelectedIndex;
                    lstCategories.Items.RemoveAt(index);
                    this.keyWords.RemoveAt(index);
                    tbEdit.Visible = true;
                    lblKeyWordToEdit.Text = "";
                    lblKeyWords.Text = "";
                }
                else
                {
                    lblKeyWordToEdit.Text = "There aren't key words to edit";
                    lblKeyWords.ForeColor = Color.Red;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                lblKeyWordToEdit.Text = "Select key word to edit";
                lblKeyWords.ForeColor = Color.Red;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string keyWordEdited = tbEdit.Text;
            if (keyWordEdited != "")
                lstCategories.Items.Add(keyWordEdited);
            else
            {
                lblKeyWordToEdit.Text = "The keyword cannot be empty";
                lblKeyWordToEdit.ForeColor = Color.Red;
            }
            tbEdit.Visible = false;
            tbEdit.Text = "";
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lstCategories.SelectedIndex;
                keyWords.RemoveAt(index);
                lstCategories.Items.RemoveAt(index);
                lblKeyWordToEdit.Text = "";
                lblKeyWords.Text = "";
            }
            catch (ArgumentOutOfRangeException)
            {
                lblKeyWordToEdit.Text = "Select key word to delete";
                lblKeyWordToEdit.ForeColor = Color.Red;
            }
        }
    }
}
