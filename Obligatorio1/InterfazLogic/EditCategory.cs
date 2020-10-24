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

            if (lstCatgories.SelectedIndex >= 0)
            {
                txtKeyWord.Enabled = true;
                txtName.Enabled = true;
                string nameCategory = lstCatgories.SelectedItem.ToString();
                category = logicController.FindCategoryByName(nameCategory);
                txtName.Text = category.Name;
                List<string> keyWords =category.KeyWords.AsignKeyWordToList(category.KeyWords);                   
                KeyWords = keyWords;
                foreach (var keyWord in keyWords)
                {
                    lstKwywords.Items.Add(keyWord);
                }
            }
            else
            {
                txtKeyWord.Enabled = false;
                txtName.Enabled = false;
                lblEditCategories.Text = "Select a category to edit";
                lblEditCategories.ForeColor = Color.Red;
            }
           
        }

        private void btnAddKeyWord_Click(object sender, EventArgs e)
        {

            if (lstCatgories.SelectedIndex >= 0)
            {
                string keyWord = txtKeyWord.Text;
                if (keyWord.Length > 0)
                {
                    if (KeyWords.Contains(keyWord.ToLower()))
                    {
                        lblKyWords.Text = "You already entered that keyword";
                        lblKyWords.ForeColor = Color.Red;
                    }
                    else if (KeyWords.Count >= 10)
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
            else
            {
                txtKeyWord.Enabled = false;
                txtName.Enabled = false;
                lblEditCategories.Text = "Select a category to edit";
                lblEditCategories.ForeColor = Color.Red;
            }

        }

        private void TryDeleteKeyWord()
        {
            if (lstKwywords.SelectedIndex >= 0) { 
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
                    
                    txtKeyWord.Enabled = false;
                    txtName.Enabled = false;
                    lblKyWords.Text = "Select key word to delete";
                    lblKyWords.ForeColor = Color.Red;
                }
            }
            else
            {
                txtKeyWord.Enabled = false;
                txtName.Enabled = false;
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
                txtKeyWord.Enabled = false;
                txtName.Enabled = false;
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
            logicController.GetCategories().Remove(category);
            logicController.SetCategory(txtName.Text, KeyWords);         
            logicController.EditCategoryExpense(category, txtName.Text, KeyWords);
            logicController.EditCategoryBudget(category, txtName.Text, KeyWords);
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
