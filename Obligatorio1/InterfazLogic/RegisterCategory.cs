﻿using System;
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
            this.MinimumSize = new Size(650, 300);
            this.MaximumSize= new Size(650, 300);
            lstCategories.Items.Clear();
            tbName.Clear();
        }


        private void btnAddKeyWord_Click(object sender, EventArgs e)
        {
                string keyWord = tbKeyWord.Text;
                if (keyWord.Length > 0)
                {
                    if (keyWords.Contains(keyWord.ToLower()))
                    {
                        lblKeyWords.Text = "You already entered that keyword";
                    }
                    else if (keyWords.Count > 10)
                    {
                        lblKeyWords.Text = "You cannot add more than 10 keywords.";
                    }
                    else
                    {                     
                        this.keyWords.Add(keyWord);
                        lstCategories.Items.Add(keyWord);
                        tbKeyWord.Text = "";
                    }
                }
                else
                    lblKeyWords.Text = "The keyword cannot be empty.";
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (keyWords.Count > 0)
                {
                    int index = lstCategories.SelectedIndex;
                    lstCategories.Items.RemoveAt(index);
                    this.keyWords.RemoveAt(index);
                    tbEdit.Visible = true;
                    lblKeyWordToEdit.Text = "";
                    lblKeyWords.Text = "";
                }
                else
                {
                    lblKeyWordToEdit.Text = "There aren't key words to edit";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                lblKeyWordToEdit.Text = "Select key word to edit";
            }          
           
        }

        private void btnRegisterCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Text;
                List<string> kW = this.keyWords;
                Category category = new Category(name, kW);
                repository.addCategory(category);
                MessageBox.Show("Category " + category.Name + " was added successfully");                
                lblKeyWords.Text = "";
                lblName.Text = "";
                this.Visible = false;
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
            catch (ExcepcionInvalidRepeatedKeyWordsCategory)
            {
                lblKeyWords.Text = "The entered keyword already exists in another category," +
                    " modify or delete it.";
            }
            catch (ExcepcionInvalidKeyWordsLengthCategory)
            {
                lblKeyWords.Text = "You cannot add more than 10 keywords.";
            }

            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string keyWordEdited = tbEdit.Text;
            if (keyWordEdited != "")
                lstCategories.Items.Add(keyWordEdited);
            else
                lblKeyWordToEdit.Text = "The keyword cannot be empty";
            tbEdit.Visible = false;
            tbEdit.Text = "";
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lstCategories.SelectedIndex;
                keyWords.RemoveAt(index);
                lstCategories.Items.RemoveAt(index);
                lblKeyWordToEdit.Text = "";
                lblKeyWords.Text = "";
            }
            catch (ArgumentOutOfRangeException)
            {
                lblKeyWordToEdit.Text = "Select key word to delete";
            }
        }
    }
}
