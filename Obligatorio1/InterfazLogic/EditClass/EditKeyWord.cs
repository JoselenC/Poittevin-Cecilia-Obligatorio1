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

        public string KeyWord { get; set; }

        public EditKeyWord(string keyWord, CategoryController vCategoryController)
        {            
            InitializeComponent();
            categoryController = vCategoryController;
            MaximumSize = new Size(380, 200);
            MinimumSize = new Size(380, 200);
            StartPosition = FormStartPosition.CenterScreen;
            tbEdit.Clear();
            tbEdit.Text = keyWord;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                categoryController.AlreadyExistKeyWordInAnoterCategory(tbEdit.Text);
                KeyWord = tbEdit.Text;
                Close();
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
