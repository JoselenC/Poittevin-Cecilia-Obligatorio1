using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Repository;

namespace InterfazLogic
{
    public partial class RegisterCategory : UserControl
    {
        private CategoryController categoryController;
        public string KeyWordToEdit { get; set; }
        public List<string> KeyWords { get; set; }
        private int indexKeyWordToEdit;

        public RegisterCategory(IManageRepository vRepository)
        {
            InitializeComponent();
            categoryController = new CategoryController(vRepository);
            KeyWords = new List<string>();
            MaximumSize = new Size(800, 800);
            MinimumSize = new Size(800, 800);
            indexKeyWordToEdit = -1;
            lstCategories.Items.Clear();
            tbName.Clear();
        }

        private void TryRegisterCategoty()
        {
            categoryController.SetCategory(tbName.Text, KeyWords);
            lblKeyWords.Text = "";
            lblEdit.Text = "";
            lblName.Text = "";
            MessageBox.Show("Category " + tbName.Text + " was added successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Visible = false;
        }
       
        private void BtnRegisterCategory_Click(object sender, EventArgs e)
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

        private void TryAddKeyWord(string keyWord)
        {
            KeyWord key = new KeyWord(keyWord, KeyWords);
            categoryController.AlreadyExistKeyWordInAnoterCategory(keyWord);
            KeyWords.Add(keyWord);
            lstCategories.Items.Add(keyWord);
            tbKeyWord.Text = "";
            lblKeyWords.Text = "";
        }


        private void BtnAddKeyWord_Click(object sender, EventArgs e)
        {
            string keyWord = tbKeyWord.Text;
            try
            {
                TryAddKeyWord(keyWord);
            }
            catch (ExcepcionInvalidRepeatedKeyWordsInAnotherCategory)
            {
                lblKeyWords.Text = "You already entered that keyword in another category";
                lblKeyWords.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidKeyWordsLengthCategory)
            {
                lblKeyWords.Text = "You cannot add more than 10 keywords.";
                lblKeyWords.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidRepeatedKeyWordsCategory)
            {
                lblKeyWords.Text = "You already entered that keyword";
                lblKeyWords.ForeColor = Color.Red;
            }
            catch (InvalidKeyWord)
            {
                lblKeyWords.Text = "The keyword cannot be empty.";
                lblKeyWords.ForeColor = Color.Red;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            indexKeyWordToEdit = lstCategories.SelectedIndex;
            if (KeyWords.Count > 0)
            {
                if (indexKeyWordToEdit >= 0)
                {
                    EditKeyWord editKeyWord = new EditKeyWord(lstCategories.SelectedItem.ToString(), indexKeyWordToEdit, categoryController, KeyWords, lstCategories);

                    editKeyWord.Show();
                    lblKeyWords.Text = "";
                    lblEdit.Text = "";
                }
                else
                {
                    lblEdit.Text = "Select key word to edit";
                    lblEdit.ForeColor = Color.Red;
                }
            }
            else if (KeyWords.Count <= 0)
            {
                lblEdit.Text = "There aren't key words to edit";
                lblEdit.ForeColor = Color.Red;
            }
        }

        private void TryDeleteKyWord()
        {
            int index = lstCategories.SelectedIndex;
            KeyWords.RemoveAt(index);
            lstCategories.Items.RemoveAt(index);
            lblEdit.Text = "";
            lblKeyWords.Text = "";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
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

        private void BtnCanel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
