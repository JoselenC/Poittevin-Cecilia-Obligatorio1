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
        public RegisterCategory()
        {
            InitializeComponent();
        }

        private void btnAddKeyWord_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnRegisterCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = tbName.Text;
                Category category = new Category(Name, keyWords);
                repository.addCategory(category);
                MessageBox.Show("Category " + category.Name + " was added successfully");
            }
            catch (ExcepcionInvalidNameLengthCategory)
            {
                lblErrorName.Text = "The name must be between 3 and 15 characters long.";
                tbName.BackColor = Color.Red;
            }
            catch (ExcepcionInvalidNameDigitCategory)
            {
                lblErrorName.Text = "The name of the category cannot be just numbers.";
                tbName.BackColor = Color.Red;
            }
            catch (ExcepcionInvalidRepeatedNameCategory)
            {
                lblErrorName.Text = "The entered name already exists.";
                tbName.BackColor = Color.Red;
            }

        }


    }
}
