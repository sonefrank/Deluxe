using Deluxe.BLL;
using Deluxe.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deluxe.WinForms
{
    public partial class FrmProductEdit : Form
    {
        private Action callback;
        private Product oldProduct;

        public FrmProductEdit()
        {
            InitializeComponent();
        }

        public FrmProductEdit(Action callback) : this()
        {
            this.callback = callback;
        }

        public FrmProductEdit(Product product,Action callback) : this(callback)
        {
            this.oldProduct = product;
            txtName.Text = product.Name;
            txtPrice.Text = product.UnitPrice.ToString();
            txtReference.Text = product.Reference;
            txtTax.Text = product.Tax.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                checkForm();
                Product newProduct = new Product(txtReference.Text.ToUpper(), txtName.Text, double.Parse(txtPrice.Text), float.Parse(txtTax.Text));
                ProductBLO productBLO = new ProductBLO(ConfigurationManager.AppSettings["DbFolder"]);

                if (this.oldProduct == null)
                    productBLO.CreateProduct(newProduct);
                else
                    productBLO.EditProduct(oldProduct, newProduct);

                MessageBox.Show
                    (
                     "Save Done!",
                     "Confirmation",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                    );

                if (callback != null)
                    callback();
                if (oldProduct != null)
                   Close();

                txtReference.Clear();
                txtPrice.Clear();
                txtName.Clear();
                txtTax.Clear();
                txtReference.Focus();
            }
            catch (TypingErreur ex)
            {
                MessageBox.Show
                   (
                    ex.Message,
                    "Typing error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                   );
            }
            catch (DuplicateNameException ex)
            {
                MessageBox.Show
                   (
                    ex.Message,
                    "Duplicate error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                   );
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show
                   (
                    ex.Message,
                    " Not found error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                   );
            }
            catch (Exception ex)
            {
                ex.WriteToFile();
                MessageBox.Show
                   (
                    "An error occurred ! please try again",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                   );
            }
        }

        private void checkForm()
        {
            string text = string.Empty;
            txtName.BackColor = Color.White;
            txtReference.BackColor = Color.White;
            if (string.IsNullOrWhiteSpace(txtReference.Text))
            {
                text += "- Reference can't be empty !";
                txtReference.BackColor = Color.Red;
            }
              
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                text += "- Name can't be empty !";
                txtName.BackColor = Color.Red;
            }
               

            if (!string.IsNullOrEmpty(text))
                throw new TypingException(text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
