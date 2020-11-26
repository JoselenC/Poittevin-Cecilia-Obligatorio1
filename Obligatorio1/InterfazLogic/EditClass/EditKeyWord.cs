using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;

namespace InterfazLogic
{
    public partial class EditKeyWord : Form
    {
        private CategoryController categoryController;

        public int Index { get; set; }


        public bool Edited { get; set; } = false;

        public ListBox listKeyWords;
        public string KeyWord { get; set; }
        public List<string> KeyWords { get; set; }
        public EditKeyWord(string keyWord, int indexToEdit,CategoryController vCategoryController,List<string> vKeyWords, ListBox lstkeyWords)
        {            
            InitializeComponent();
            categoryController = vCategoryController;
            MaximumSize = new Size(380, 200);
            MinimumSize = new Size(380, 200);
            StartPosition = FormStartPosition.CenterScreen;
            tbEdit.Clear();
            tbEdit.Text = keyWord;
            KeyWords = vKeyWords;
            KeyWord = keyWord;
            Index = indexToEdit;
            listKeyWords = lstkeyWords;
        }

        private void UpdateKeyWord(string keyWordEdited)
        {
            KeyWord key = new KeyWord(keyWordEdited, KeyWords);
            categoryController.AlreadyExistKeyWordInAnoterCategory(keyWordEdited);
            KeyWords.Remove(KeyWord);
            KeyWords.Add(keyWordEdited);
            listKeyWords.DataSource = new List<string>();
            listKeyWords.DataSource = KeyWords;
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string keyWordEdited = tbEdit.Text;
            try
            {
                UpdateKeyWord(keyWordEdited);
            }
            catch (ExcepcionInvalidRepeatedKeyWordsInAnotherCategory)
            {
                lblKeyWord.Text = "You already entered that keyword in another category";
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
            Close();
        }
    }
}
