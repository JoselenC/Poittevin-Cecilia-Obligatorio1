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
    public partial class EditCategory : UserControl
    {
        public List<string> KeyWords { get; set; }
        private LogicController logicController;
        Category category;
        private int indexKeyWordToEdit;

        public EditCategory(Repository vRepository)
        {
            InitializeComponent();
            logicController = new LogicController(vRepository);
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);
            CompleteCategories();
            indexKeyWordToEdit = -1;
        }

        private void CompleteCategories()
        {
            if (logicController.GetCategories().Count > 0)
            {
                foreach (Category category in logicController.GetCategories())
                {
                    lstCatgories.Items.Add(category);
                }                
            }
            else
            {
                MessageBox.Show("There are no categories registered in the system");
                Visible = false;
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (lstCatgories.SelectedIndex>0)
            {
                lblEditCategories.Text = "Select a category to edit";
                lblEditCategories.ForeColor = Color.Red;
            }
            else {
                string nameCategory = lstCatgories.SelectedItem.ToString();
                category = logicController.FindCategoryByName(nameCategory);
                txtName.Text=category.Name;
                List<string> keyWords = category.KeyWords;
                KeyWords = keyWords;
                foreach(var keyWord in keyWords)
                {
                    lstKwywords.Items.Add(keyWord);
                }
               
            }
        }

        private void btnAddKeyWord_Click(object sender, EventArgs e)
        {

            string keyWord = txtKeyWord.Text;
            if (keyWord.Length > 0)
            {
                if (KeyWords.Contains(keyWord.ToLower()))
                {
                    lblKyWords.Text = "You already entered that keyword";
                    lblKyWords.ForeColor = Color.Red;
                }
                else if (KeyWords.Count > 10)
                {
                    lblKyWords.Text = "You cannot add more than 10 keywords.";
                    lblKyWords.ForeColor = Color.Red;
                }
                else if (logicController.AlreadyExistThisKeyWordInAnoterCategory(keyWord))
                {
                    lblKyWords.Text = "You already entered that keyword in another category";
                    lblKyWords.ForeColor = Color.Red;
                }
                else
                {
                    this.KeyWords.Add(keyWord);
                    lstKwywords.Items.Add(keyWord);
                    txtKeyWord.Text = "";
                    lblKyWords.Text = "";
                }
            }
            else
            {
                lblKyWords.Text = "The keyword cannot be empty.";
                lblKyWords.ForeColor = Color.Red;
            }

        }

        private void TryDeleteKeyWord()
        {
            int index = lstKwywords.SelectedIndex;
            KeyWords.RemoveAt(index);
            lstKwywords.Items.RemoveAt(index);
            lblKyWords.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                TryDeleteKeyWord();
            }
            catch (ArgumentOutOfRangeException)
            {
                lblKyWords.Text = "Select key word to delete";
                lblKyWords.ForeColor = Color.Red;
            }
        }       

         private void btnEdit_Click(object sender, EventArgs e)
        {
            if (KeyWords.Count > 0)
            {
                indexKeyWordToEdit = lstKwywords.SelectedIndex;
                if (indexKeyWordToEdit >= 0)
                {
                    EditKeyWord editKeyWord = new EditKeyWord(KeyWords, indexKeyWordToEdit, lstKwywords,logicController);
                    editKeyWord.Show();
                    lblKeyWords.Text = "";
                }
                else
                {
                    lblKyWords.Text = "Select key word to edit";
                    lblKyWords.ForeColor = Color.Red;
                }
            }
            else if (KeyWords.Count <= 0)
            {
                lblKyWords.Text = "There aren't key words to edit";
                lblKyWords.ForeColor = Color.Red;
            }
        }

        private void TryRegisterCategory()
        {
            logicController.GetCategories().Remove(category);
            lstCatgories.Items.Remove(category);
            logicController.SetCategory(txtName.Text, KeyWords);
            MessageBox.Show("Category " + category.Name + " was added successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Visible = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                TryRegisterCategory();
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

    }
}
