using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Repository;

namespace InterfazLogic
{
    public partial class EditCategory : UserControl
    {
        private CategoryController categoryController;
        private Category category;
        private List<string> EditableKeyWords = new List<string>();
        private int indexKeyWordToEdit;

        public EditCategory(ManagerRepository vRepository)
        {
            InitializeComponent();
            categoryController = new CategoryController(vRepository);
            MaximumSize = new Size(500, 600);
            MinimumSize = new Size(500, 600);
            CompleteCategories();
            indexKeyWordToEdit = -1;
            txtKeyWord.Enabled = false;
            txtName.Enabled = false;
        }

        private void CompleteCategories()
        {
            if (categoryController.GetCategories().Count > 0)
            {
                foreach (Category category in categoryController.GetCategories())
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
            EditableKeyWords = new List<string>();
            string nameCategory = lstCatgories.SelectedItem.ToString();
            category = categoryController.FindCategoryByName(nameCategory);
            txtName.Text = category.Name;
            foreach (string keyWord in category.KeyWords)
            {
                EditableKeyWords.Add(keyWord);
            }           
            lstKwywords.DataSource = EditableKeyWords;
            txtKeyWord.Enabled = true;
            txtName.Enabled = true;
        }

        private void SetMessage(string messsage, Label lblToSetMessage)
        {
            if (lblToSetMessage != lblName)
                lblName.Text = "";
            if (lblToSetMessage != lblEditCategories)
                lblEditCategories.Text = "";
            if (lblToSetMessage != lblKeyWord)
                lblKeyWord.Text = "";
            if (lblToSetMessage != lblKyWords)
                lblKyWords.Text = "";
            lblToSetMessage.Text = messsage;
            lblToSetMessage.ForeColor = Color.Red;
        }

        private void BtnEditCategory_Click(object sender, EventArgs e)
        {
            if (lstCatgories.SelectedIndex >= 0)
                EditTheCategory();
            else
            {
                SetMessage("Select a category to edit", lblEditCategories);
            }
        }

        private void TryAddKeyWord(string keyWord)
        {
            KeyWord key = new KeyWord(keyWord, EditableKeyWords);
            categoryController.AlreadyExistKeyWordInAnoterCategory(keyWord);
            EditableKeyWords.Add(keyWord);
            lstKwywords.DataSource = new List<string>();
            lstKwywords.DataSource = EditableKeyWords;
            txtKeyWord.Text = "";
        }

        private void BtnAddKeyWord_Click(object sender, EventArgs e)
        {
            if (lstCatgories.SelectedIndex >= 0)
            {
                string keyWord = txtKeyWord.Text;
                try
                {
                    TryAddKeyWord(keyWord);
                }
                catch (ExcepcionInvalidRepeatedKeyWordsInAnotherCategory)
                {
                    SetMessage("You already entered that keyword in another category", lblKeyWord);
                }
                catch (ExcepcionInvalidKeyWordsLengthCategory)
                {
                    SetMessage("You cannot add more than 10 keywords.", lblKeyWord);
                }
                catch (ExcepcionInvalidRepeatedKeyWordsCategory)
                {
                    SetMessage("You already entered that keyword", lblKeyWord);
                }
                catch (InvalidKeyWord)
                {
                    SetMessage("The keyword cannot be empty.", lblKeyWord);
                }
            }
            else
            {
                SetMessage("Select a category to edit", lblEditCategories);
            }
        }

        
        private void TryDeleteKeyWord()
        {
            if (lstKwywords.SelectedIndex >= 0)
            {
               List<string> keyWords = new List<string>();
               EditableKeyWords.Remove(lstKwywords.SelectedItem.ToString());
               lstKwywords.DataSource = keyWords;
               lstKwywords.DataSource = EditableKeyWords;
               lblKyWords.Text = "";
            }        
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstCatgories.SelectedIndex >= 0)
            {
                try
                {
                    TryDeleteKeyWord();
                }
                catch (ArgumentOutOfRangeException)
                {
                    SetMessage("Select key word to delete", lblKyWords);
                }
            }
            else
            {
                SetMessage("Select a category to edit", lblEditCategories);
            }
        }       

         private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (lstCatgories.SelectedIndex >= 0)
            {
                EditSelectedKyWord();
            }
            else
            {
                SetMessage("Select a category to edit", lblEditCategories);
            }
        }

        private void EditKeyWord()
        {
            EditKeyWord editKeyWord = new EditKeyWord(lstKwywords.SelectedItem.ToString(), indexKeyWordToEdit, categoryController, EditableKeyWords, lstKwywords);
            editKeyWord.ShowDialog();
            EditableKeyWords = editKeyWord.KeyWords;
            lstKwywords.DataSource = EditableKeyWords;
            txtKeyWord.Enabled = true;
            txtName.Enabled = true;
        }

        private void EditSelectedKyWord()
        {
            if (lstKwywords.Items.Count > 0)
            {
                indexKeyWordToEdit = lstKwywords.SelectedIndex;
                if (indexKeyWordToEdit >= 0)
                {
                    EditKeyWord();
                }
                else
                {
                    SetMessage("Select key word to edit", lblKyWords);
                }
            }
            else if (lstKwywords.Items.Count <= 0)
            {
                SetMessage("There aren't key words to edit", lblKyWords);
            }
        }

        private void TryRegisterCategory()
        {
            if (lstCatgories.SelectedIndex < 0)
            {
                SetMessage("Select a category to edit o delete", lblEditCategories);
            };
            Category newCategory = new Category()
            {
                Name = txtName.Text,
                KeyWords = EditableKeyWords
            };
            categoryController.UpdateCategory(category, newCategory);
            MessageBox.Show("Category " + txtName.Text + " was edited successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lstCatgories.Items.Remove(category);
            Visible = false;
            
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                TryRegisterCategory();
            }
            catch (ExcepcionInvalidNameLengthCategory)
            {
                SetMessage("The name must be between 3 and 15 characters long.", lblName);
            }
            catch (ExcepcionInvalidNameDigitCategory)
            {
                SetMessage("The name of the category cannot be just numbers.", lblName);
            }
            catch (ExcepcionInvalidRepeatedNameCategory)
            {
                if (category.Name == txtName.Text)
                {
                    TryRegisterCategory();
                }
                else
                {
                    SetMessage("The entered name already exists.", lblName);
                }
            }
            catch (ExcepcionInvalidRepeatedKeyWordsCategory)
            {
                SetMessage("The entered keyword already exists in another category, edit or delete it.", lblKyWords);
            }
            catch (ExcepcionInvalidKeyWordsLengthCategory)
            {
                SetMessage("You cannot add more than 10 keywords.", lblKyWords);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
