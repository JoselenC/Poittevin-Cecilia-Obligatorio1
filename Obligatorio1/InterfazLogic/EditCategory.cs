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
using System.Linq.Expressions;

namespace InterfazLogic
{
    public partial class EditCategory : UserControl
    {
        public List<string> KeyWords { get; set; }
        private LogicController logicController;
        private Category category;
        private int indexKeyWordToEdit;

        public EditCategory(Repository vRepository)
        {
            InitializeComponent();
            logicController = new LogicController(vRepository);
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);
            CompleteCategories();
            indexKeyWordToEdit = -1;
            txtKeyWord.Enabled = false;
            txtName.Enabled = false;
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


        private void EditTheCategory()
        {
            txtKeyWord.Enabled = true;
            txtName.Enabled = true;
            string nameCategory = lstCatgories.SelectedItem.ToString();
            category = logicController.FindCategoryByName(nameCategory);
            txtName.Text = category.Name;
            List<string> keyWords = category.KeyWords.AsignKeyWordToList(category.KeyWords);
            KeyWords = keyWords;
            foreach (var keyWord in keyWords)
            {
                lstKwywords.Items.Add(keyWord);
            }
            txtKeyWord.Enabled = true;
            txtName.Enabled = true;
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (lstCatgories.SelectedIndex >= 0)
                EditTheCategory();
            else
            {
                lblEditCategories.Text = "Select a category to edit";
                lblEditCategories.ForeColor = Color.Red;
            }
        }


        private void btnAddKeyWord_Click(object sender, EventArgs e)
        {
            string keyWord = txtKeyWord.Text;
            if (lstCatgories.SelectedIndex >= 0)
            {
                try
                {
                    logicController.AlreadyExistKeyWordInAnoterCategory(keyWord);
                    KeyWord key = new KeyWord(KeyWords);
                    key.AddKeyWord(keyWord);
                    lstCatgories.Items.Add(keyWord);
                }
                catch (ExcepcionInvalidRepeatedKeyWordsInAnotherCategory)
                {
                    lblKyWords.Text = "You already entered that keyword in another category";
                    lblKyWords.ForeColor = Color.Red;
                    txtKeyWord.Enabled = true;
                    txtName.Enabled = true;
                }
                catch (ExcepcionInvalidKeyWordsLengthCategory)
                {
                    lblKyWords.Text = "You cannot add more than 10 keywords.";
                    lblKyWords.ForeColor = Color.Red;
                }
                catch (ExcepcionInvalidRepeatedKeyWordsCategory)
                {
                    lblKyWords.Text = "You already entered that keyword";
                    lblKyWords.ForeColor = Color.Red;
                }
                catch (InvalidKeyWord)
                {
                    lblKyWords.Text = "The keyword cannot be empty.";
                    lblKyWords.ForeColor = Color.Red;
                }                
            }
            else
            {
                lblEditCategories.Text = "Select a category to edit";
                lblEditCategories.ForeColor = Color.Red;
            }
        }

        private void TryDeleteKeyWord()
        {
            if (lstKwywords.SelectedIndex >= 0)
            {
                int index = lstKwywords.SelectedIndex;
                KeyWords.RemoveAt(index);
                lstKwywords.Items.RemoveAt(index);
                lblKyWords.Text = "";
            }        
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCatgories.SelectedIndex >= 0)
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
            else
            {
                lblEditCategories.Text = "Select a category to edit";
                lblEditCategories.ForeColor = Color.Red;
            }
        }       

         private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstCatgories.SelectedIndex >= 0)
            {
                if (KeyWords.Count > 0)
                {
                    indexKeyWordToEdit = lstKwywords.SelectedIndex;
                    if (indexKeyWordToEdit >= 0)
                    {
                        EditKeyWord editKeyWord = new EditKeyWord(KeyWords, indexKeyWordToEdit, lstKwywords, logicController);
                        editKeyWord.Show();
                        lblKyWords.Text = "";
                        txtKeyWord.Enabled = true;
                        txtName.Enabled = true;
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
            else
            {
               
                lblEditCategories.Text = "Select a category to edit";
                lblEditCategories.ForeColor = Color.Red;
            }
        }

        private void TryRegisterCategory()
        {
            if (lstCatgories.SelectedIndex < 0)
            {
                lblEditCategories.Text = "Select a category to edit o delete";
                lblEditCategories.ForeColor = Color.Red;
            }
            logicController.EditCategory(category, txtName.Text, KeyWords);
            MessageBox.Show("Category " + txtName.Text + " was edited successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lstCatgories.Items.Remove(category);
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
                if (category.Name == txtName.Text)
                {
                    TryRegisterCategory();
                }
                else
                {
                    lblName.Text = "The entered name already exists.";
                    lblName.ForeColor = Color.Red;
                }
            }
            catch (ExcepcionInvalidRepeatedKeyWordsCategory)
            {
                lblKyWords.Text = "The entered keyword already exists in another category, edit or delete it.";
                lblKyWords.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidKeyWordsLengthCategory)
            {
                lblKyWords.Text = "You cannot add more than 10 keywords.";
                lblKyWords.ForeColor = Color.Red;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
