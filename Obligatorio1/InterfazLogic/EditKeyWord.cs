using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;

namespace InterfazLogic
{
    public partial class EditKeyWord : Form
    {
        public List<string> KeyWords { get; set; }

        public int Index { get; set; }

        private CategoryController categoryController;

        public bool Edited { get; set; } = false;

        private ListBox listKeyWords;

        private string editKeyWord;

        public EditKeyWord(List<string> vKeyWords,int indexToEdit,ListBox lstkeyWords, CategoryController vCategoryController)
        {            
            InitializeComponent();
            KeyWords = vKeyWords;
            Index = indexToEdit;
            listKeyWords = lstkeyWords;
            categoryController = vCategoryController;
            MaximumSize = new Size(380, 200);
            MinimumSize = new Size(380, 200);
            StartPosition = FormStartPosition.CenterScreen;
            tbEdit.Clear();
            editKeyWord= lstkeyWords.SelectedItem.ToString();
            tbEdit.Text = editKeyWord;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string keyWordEdited = tbEdit.Text;
            try
            {
                categoryController.AlreadyExistKeyWordInAnoterCategory(keyWordEdited);
                KeyWord key = new KeyWord(KeyWords);
                key.DeleteKeyWord(editKeyWord);
                key.AddKeyWord(keyWordEdited);
                listKeyWords.Items.RemoveAt(Index);
                listKeyWords.Items.Add(keyWordEdited);
                Close();
            }
            catch (ExcepcionInvalidRepeatedKeyWordsInAnotherCategory)
            {
                lblKeyWord.Text = "You already entered that keyword in another category";
                lblKeyWord.ForeColor = Color.Red;
            }

            catch (ExcepcionInvalidKeyWordsLengthCategory)
            {
                lblKeyWord.Text = "You cannot add more than 10 keywords.";
                lblKeyWord.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidRepeatedKeyWordsCategory)
            {
                lblKeyWord.Text = "You already entered that keyword";
                lblKeyWord.ForeColor = Color.Red;
            }
            catch (InvalidKeyWord)
            {
                lblKeyWord.Text = "The keyword cannot be empty.";
                lblKeyWord.ForeColor = Color.Red;
            }          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            KeyWords.Add(editKeyWord);
            Close();
        }
    }
}
