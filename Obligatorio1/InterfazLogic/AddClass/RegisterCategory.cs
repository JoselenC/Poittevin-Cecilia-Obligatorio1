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

        public RegisterCategory(ManagerRepository vRepository)
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

        private void SetMessage(string messsage, Label lblToSetMessage)
        {
            if (lblToSetMessage != lblName)
                lblName.Text = "";
            if (lblToSetMessage != lblKeyWordToEdit)
                lblKeyWordToEdit.Text = "";
            if (lblToSetMessage != lblEdit)
                lblEdit.Text = "";
            if (lblToSetMessage != lblKeyWords)
                lblKeyWords.Text = "";
            lblToSetMessage.Text = messsage;
            lblToSetMessage.ForeColor = Color.Red;
        }

        private void BtnRegisterCategory_Click(object sender, EventArgs e)
        {
            try
            {
                TryRegisterCategoty();
            }
            catch (ExcepcionInvalidRepeatedNameCategory)
            {
                SetMessage("The entered name already exists.", lblName);
            }
            catch (ExcepcionInvalidNameLengthCategory)
            {
                SetMessage("The name must be between 3 and 15 characters long.", lblName);
            }
            catch (ExcepcionInvalidNameDigitCategory)
            {
                SetMessage("The name of the category cannot be just numbers.", lblName);
            }

            catch (ExcepcionInvalidRepeatedKeyWordsCategory)
            {
                SetMessage("The entered keyword already exists in another category, edit or delete it.", lblKeyWords);
            }
            catch (ExcepcionInvalidKeyWordsLengthCategory)
            {
                SetMessage("You cannot add more than 10 keywords.", lblKeyWords);
            }
        }

        private void TryAddKeyWord(string keyWord)
        {
            KeyWord key = new KeyWord(keyWord, KeyWords);
            categoryController.AlreadyExistKeyWordInAnoterCategory(keyWord);
            KeyWords.Add(keyWord);
            lstCategories.DataSource = new List<string>();
            lstCategories.DataSource = KeyWords;
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
                SetMessage("You already entered that keyword in another category", lblKeyWords);
            }
            catch (ExcepcionInvalidKeyWordsLengthCategory)
            {
                SetMessage("You cannot add more than 10 keywords.", lblKeyWords);
            }
            catch (ExcepcionInvalidRepeatedKeyWordsCategory)
            {
                SetMessage("You already entered that keyword", lblKeyWords);
            }
            catch (InvalidKeyWord)
            {
                SetMessage("The keyword cannot be empty.", lblKeyWords);
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
                    SetMessage("Select key word to edit", lblEdit);
                }
            }
            else if (KeyWords.Count <= 0)
            {
                SetMessage("There aren't key words to edit", lblEdit);
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
                SetMessage("Select key word to delete", lblEdit);
            }
        }

        private void BtnCanel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
