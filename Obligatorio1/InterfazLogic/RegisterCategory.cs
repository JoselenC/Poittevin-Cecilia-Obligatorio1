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
    public partial class RegisterCategory : UserControl
    {
        private Repository repository;

        public string keyWordToEdit { get; set; }
        public List<string> keyWords { get; set; }
        public RegisterCategory(Repository vRepository)
        {
            InitializeComponent();
            repository = vRepository;
            keyWords = new List<string>();
            tbEdit.Visible = false;
        }


        private void btnAddKeyWord_Click(object sender, EventArgs e)
        {
            try
            {
                string keyWord = tbKeyWord.Text;
                if (keyWord != "")
                {
                    this.keyWords.Add(keyWord);
                    lstCategories.Items.Add(keyWord);
                    tbKeyWord.Text = "";
                }
            }
            catch (ExcepcionInvalidRepeatedKeyWordsCategory)
            {
                lblKeyWords.Text = "The entered keyword already exists in another category.";
               
            }
            catch (ExcepcionInvalidKeyWordsLengthCategory)
            {
                lblKeyWords.Text = "You cannot add more than 10 keywords.";
            }


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            int index = lstCategories.SelectedIndex;
            lstCategories.Items.RemoveAt(index);
            tbEdit.Visible = true;
           
        }

        private void btnRegisterCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Text;
                Category category = new Category(name, keyWords);
                repository.addCategory(category);
                MessageBox.Show("Category " + category.Name + " was added successfully");
            }
            catch (ExcepcionInvalidNameLengthCategory)
            {
                lblName.Text = "The name must be between 3 and 15 characters long.";
                lblKeyWords.Text = "";
            }
            catch (ExcepcionInvalidNameDigitCategory)
            {
                lblName.Text = "The name of the category cannot be just numbers.";
                lblKeyWords.Text = "";
            }
            catch (ExcepcionInvalidRepeatedNameCategory)
            {
                lblName.Text = "The entered name already exists.";
                lblKeyWords.Text = "";
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string keyWordEdited = tbEdit.Text;
            lstCategories.Items.Add(keyWordEdited);
            tbEdit.Visible = false;
           
        }
    }
}
