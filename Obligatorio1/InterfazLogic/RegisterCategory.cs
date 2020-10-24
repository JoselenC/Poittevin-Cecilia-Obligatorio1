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
        private int indexKeyWordToEdit;
        public RegisterCategory(Repository vRepository)
        {
            InitializeComponent();
            logicController = new LogicController(vRepository);
            keyWords = new List<string>();
            this.MaximumSize = new Size(800, 800);
            this.MinimumSize = new Size(800, 800);
            indexKeyWordToEdit = -1;
            lstCategories.Items.Clear();
            tbName.Clear();
        }


        private void TryRegisterCategoty()
        {
            logicController.SetCategory(tbName.Text, keyWords);
            lblKeyWords.Text = "";
            lblEdit.Text = "";
            lblName.Text = "";
            MessageBox.Show("Category " + tbName.Text + " was added successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Visible = false;
        }

        private void btnRegisterCategory_Click(object sender, EventArgs e)
        {
            try
            {
                TryRegisterCategoty();
            }
            catch (ExcepcionInvalidRepeatedNameCategory)
            {
                lblName.Text = "The entered name already exists.";
                lblName.ForeColor = Color.Red;
                lblKeyWords.Text = "";
            }
            catch (ExcepcionInvalidNameLengthCategory)
            {
                lblName.Text = "The name must be between 3 and 15 characters long.";
                lblName.ForeColor = Color.Red;
                lblKeyWords.Text = "";
            }
            catch (ExcepcionInvalidNameDigitCategory)
            {
                lblName.Text = "The name of the category cannot be just numbers.";
                lblName.ForeColor = Color.Red;
                lblKeyWords.Text = "";
            }
           
            catch (ExcepcionInvalidRepeatedKeyWordsCategory)
            {
                lblKeyWords.Text = "The entered keyword already exists in another category, edit or delete it.";
                lblKeyWords.ForeColor = Color.Red;
                lblName.Text = "";
            }
            catch (ExcepcionInvalidKeyWordsLengthCategory)
            {
                lblKeyWords.Text = "You cannot add more than 10 keywords.";
                lblKeyWords.ForeColor = Color.Red;
                lblName.Text = "";
            }           

        }


        private void btnAddKeyWord_Click(object sender, EventArgs e)
        {
            string keyWord = tbKeyWord.Text;
            if (keyWord.Length > 0)
            {
                if (keyWords.Contains(keyWord.ToLower()) || keyWords.Contains(keyWord.ToUpper()))
                {
                    lblKeyWords.Text = "You already entered that keyword";
                    lblKeyWords.ForeColor = Color.Red;
                }
                else if (keyWords.Count > 9)
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
            if (keyWords.Count > 0)
            {
                indexKeyWordToEdit = lstCategories.SelectedIndex;
                if (indexKeyWordToEdit >= 0)
                {
                    EditKeyWord editKeyWord = new EditKeyWord(keyWords, indexKeyWordToEdit, lstCategories,logicController);
                    editKeyWord.Show();
                    lblKeyWords.Text = "";
                }
                else
                {
                    lblEdit.Text = "Select key word to edit";
                    lblEdit.ForeColor = Color.Red;
                }
            }
            else if (keyWords.Count <= 0)
            {
                lblEdit.Text = "There aren't key words to edit";
                lblEdit.ForeColor = Color.Red;
            }
        }       


        private void TryDeleteKyWord()
        {
            int index = lstCategories.SelectedIndex;
            keyWords.RemoveAt(index);
            lstCategories.Items.RemoveAt(index);
            lblEdit.Text = "";
            lblKeyWords.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                TryDeleteKyWord();
            }
            catch (ArgumentOutOfRangeException)
            {
                lblEdit.Text = "Select key word to delete";
                lblEdit.ForeColor = Color.Red;
            }
        }

       
    }
}
