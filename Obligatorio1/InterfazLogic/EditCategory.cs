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
        private Repository repository;
        Category category;

        public EditCategory(Repository vRepository)
        {
            InitializeComponent();
            repository = vRepository;
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);
            CompleteCategories();
            tbEdit.Visible = false;
        }

        private void CompleteCategories()
        {
            if (repository.Categories.Count > 0)
            {
                foreach (Category category in repository.Categories)
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
                this.category = repository.FindCategoryByName(nameCategory);
                txtName.Text=category.Name;
                List<string> keyWords = category.KeyWords;
                KeyWords = keyWords;
                foreach(var keyWord in keyWords)
                {
                    lstKwywords.Items.Add(keyWord);
                }
                repository.Categories.Remove(category);
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
                else if (repository.AlreadyExistThisKeyWordInAnoterCategory(keyWord))
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lstKwywords.SelectedIndex;
                KeyWords.RemoveAt(index);
                lstKwywords.Items.RemoveAt(index);
                lblKyWords.Text = "";
            }
            catch (ArgumentOutOfRangeException)
            {
                lblKyWords.Text = "Select key word to delete";
                lblKyWords.ForeColor = Color.Red;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string keyWordEdited = tbEdit.Text;
            if (keyWordEdited != "")
                lstKwywords.Items.Add(keyWordEdited);
            else
            {
                lblKyWords.Text = "The keyword cannot be empty";
                lblKyWords.ForeColor = Color.Red;
            }
            tbEdit.Visible = false;
            tbEdit.Text = "";

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (KeyWords.Count > 0)
                {
                    int index = lstKwywords.SelectedIndex;
                    lstKwywords.Items.RemoveAt(index);
                    this.KeyWords.RemoveAt(index);
                    tbEdit.Visible = true;
                    lblKyWords.Text = "";
                    lblKyWords.Text = "";
                }
                else
                {
                    lblKyWords.Text = "There aren't key words to edit";
                    lblKyWords.ForeColor = Color.Red;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                lblKyWords.Text = "Select key word to edit";
                lblKyWords.ForeColor = Color.Red;
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                category.Name = txtName.Text;
                category.KeyWords = KeyWords;
                repository.Categories.Add(category);
                MessageBox.Show("the category was edited correctly");
                Visible = false;
            }
            else
            {
                lblName.Text = "The category name cannot be empty ";
                lblName.ForeColor = Color.Red;
            }
        }

       
    }
}
