using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment_05.ContactFiles;

namespace Assignment_05
{
    /// <summary>
    /// Partial class <c>ContactForm</c> provides a GUI window which allows 
    /// the user to add/edit customer data.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is responsible for user interaction, validating user input, 
    /// displaying data and error messages.
    /// </para>
    /// <para>
    /// This class hold an instance of <c>Contact</c> which provides storage for
    /// a customer's contact data while it is being created / edited by the user.
    /// The reference to the <c>Contact</c> object is forwarded from <c>MainForm</c>
    /// through the constructor parameter.
    /// </para>
    /// <para>
    /// The boolean field <c>_keyWasPressed</c> is set to true if the user presses
    /// any key while the form is open. The value is used as an indication that the 
    /// contact data may have been edited.
    /// </para>
    /// </remarks>
    public partial class ContactForm : Form
    {
        private Contact _contact;
        private bool _keyWasPressed;

        public Contact Contact
        {
            get { return _contact; }
        }
        
        // My previous solution involved overloading with a second constructor
        // without parameters. The add/edit mode was determined based on which 
        // constructor was called. This ultimately required more lines of code
        // and also felt less readable than having only one code path like below.

        public ContactForm(Contact contact)
        {
            _contact = contact;
            _keyWasPressed = false;

            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>
        /// Method for initializing the GUI.
        /// </summary>
        /// <remarks>
        /// Initializes the GUI differently depending on whether the <c>Contact</c> 
        /// object is new, or has been previously saved.
        /// </remarks>
        private void InitializeGUI()
        {
            InitializeCountryComboBox();

            if (_contact.FirstName == null) // The contact is new / untouched
            {
                this.Text = "Add new customer";
                txtFirstname.Focus();
            }
            else
            {
                this.Text = "Edit customer";
                PopulateTextboxes();
            }
            MarkRequiredInputFields();
        }

        /// <summary>
        /// Loads previously saved <c>Contact</c> data into the textboxes.
        /// </summary>
        private void PopulateTextboxes()
        {
            txtFirstname.Text = _contact.FirstName;
            txtLastname.Text = _contact.LastName;
            txtPhoneHome.Text = _contact.Phone.NumberHome;
            txtPhoneCell.Text = _contact.Phone.NumberCell;
            txtEmailBusiness.Text = _contact.Email.EmailBusiness;
            txtEmailPrivate.Text = _contact.Email.EmailPrivate;
            txtAddressStreet.Text = _contact.Address.Street;
            txtAddressCity.Text = _contact.Address.City;
            txtAddressZip.Text = _contact.Address.ZipCode;
            cmbAddressCountry.SelectedIndex = (int)_contact.Address.Country;
        }

        /// <summary>
        /// Fills the combobox with country names from the <c>Countries</c> enum.
        /// </summary>
        private void InitializeCountryComboBox()
        {
            int enumLength = Enum.GetNames(typeof(Countries)).Length;

            for (int i = 0; i < enumLength; i++)
            {
                string count_ry = Enum.GetValues(typeof(Countries)).GetValue(i).ToString();
                string country = Utils.ReplaceCharsInString(count_ry, '_', ' ');
                cmbAddressCountry.Items.Add(country);
            }
        }

        /// <summary>
        /// Executes when the OK button is clicked. 
        /// </summary>
        /// <remarks>
        /// This button's <c>DialogResult</c> property is not set, because we want 
        /// the window to stay open until required data is provided by the user. 
        /// By setting <c>DialogResult</c> programmatically, we can decide when 
        /// the window will close or stay open.
        /// </remarks>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ReadUserInput() != null) // Contact was stored successfully
            {
                _contact = ReadUserInput(); // TODO: Reading data twice is not optimal

                bool isInputComplete = _contact.CheckRequiredData();

                if (isInputComplete) this.DialogResult = DialogResult.OK;
                else MessageBox.Show("Make sure to enter a name, city, and country.", 
                    "Missing required input");
            }
        }

        /// <summary>
        /// Executes when the Cancel button is clicked.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Shows a confirmation dialog if a keypress was detected earlier by 
        /// the <c>KeyEventHandler</c>.
        /// </para>
        /// <para>
        /// A keypress is not proof that an edit has been made. Also, this solution 
        /// detects keystrokes even if no textbox is focused. On the positive side, 
        /// the absence of keystrokes proves the absence of editing.
        /// </para>
        /// </remarks>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_keyWasPressed) // If true, the user might have changed some text
            {
                DialogResult confirmCancel =
                    MessageBox.Show("Changes have been made - do you really want to discard them?", 
                    "Please confirm", MessageBoxButtons.YesNo);

                if (confirmCancel == DialogResult.Yes) this.Dispose();
            }
            else this.Dispose(); // Since no key was pressed, no changes were made
        }

        /// <summary>
        /// Tries to store user input into a new <c>Contact</c> object.
        /// </summary>
        /// <returns>
        /// <para>
        /// A new <c>Contact</c> object with the user-provided data from the textboxes,
        /// </para>
        /// <para>
        /// or <c>null</c> if an exception was thrown when validating the data.
        /// </para>
        /// </returns>
        private Contact ReadUserInput()
        {
            try
            {
                Contact contact = new Contact();
                contact.FirstName = ReadTextBox(txtFirstname);
                contact.LastName = ReadTextBox(txtLastname);

                contact.Phone.NumberHome = ReadTextBox(txtPhoneHome);
                contact.Phone.NumberCell = ReadTextBox(txtPhoneCell);

                contact.Email.EmailBusiness = ReadTextBox(txtEmailBusiness);
                contact.Email.EmailPrivate = ReadTextBox(txtEmailPrivate);

                contact.Address.Street = ReadTextBox(txtAddressStreet);
                contact.Address.City = ReadTextBox(txtAddressCity);
                contact.Address.ZipCode = ReadTextBox(txtAddressZip);
                contact.Address.Country = (Countries)cmbAddressCountry.SelectedIndex; // returns -1 if no selection

                return contact;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error storing data");
                return null;
            }
        }

        /// <summary>
        /// A wrapper for a simple string-validation method in class <c>Utils</c>,
        /// checking that a string contains characters besides spaces, and isn't null.
        /// </summary>
        /// <param name="textBox">An object of the class <c>TextBox</c>.</param>
        /// <returns>
        /// The (trimmed) string found in the textbox <c>Text</c> property.
        /// Returns an empty string if validation failed.
        /// </returns>
        private string ReadTextBox(TextBox textBox)
        {
            string str = textBox.Text;

            if (Utils.IsStringValid(str)) return str.Trim();
            else return string.Empty;
        }

        /// <summary>
        /// Highlights the obligatory input controls that are empty, and removes highlights
        /// from obligatory input controls that are not empty.
        /// </summary>
        private void MarkRequiredInputFields()
        {
            bool isFirstnameEmpty = IsTextBoxEmpty(txtFirstname);
            bool isLastnameEmpty = IsTextBoxEmpty(txtLastname);
            bool isCityEmpty = IsTextBoxEmpty(txtAddressCity);
            bool isCountryEmpty = cmbAddressCountry.Text.Length == 0;

            if (isFirstnameEmpty)
            {
                MarkTextBoxRequired(txtFirstname);
                MarkLabelRequired(lblFirstName);
            }
            else
            {
                UnmarkTextBox(txtFirstname);
                UnmarkLabel(lblFirstName);
            }

            if (isLastnameEmpty)
            {
                MarkTextBoxRequired(txtLastname);
                MarkLabelRequired(lblLastname);
            }
            else
            {
                UnmarkTextBox(txtLastname);
                UnmarkLabel(lblLastname);
            }

            if (isCityEmpty)
            {
                MarkTextBoxRequired(txtAddressCity);
                MarkLabelRequired(lblCity);
            }
            else
            {
                UnmarkTextBox(txtAddressCity);
                UnmarkLabel(lblCity);
            }

            if (isCountryEmpty)
            {
                MarkLabelRequired(lblCountry);
            }
            else
            {
                UnmarkLabel(lblCountry);
            }
        }

        /// <summary>
        /// Executes if a key is pressed when the form window is open, regardless
        /// of the currently focused control.
        /// </summary>
        private void ContactForm_KeyDown(object sender, KeyEventArgs e)
        {
            _keyWasPressed = true;
        }

        /// <summary>
        /// Executes when focus leaves the <c>txtFirstname</c> TextBox. Calls a method
        /// to update the highlights for obligatory input fields.
        /// </summary>
        private void txtFirstname_Leave(object sender, EventArgs e)
        {
            MarkRequiredInputFields();
        }

        private void txtLastname_Leave(object sender, EventArgs e)
        {
            MarkRequiredInputFields();
        }

        private void txtAddressCity_Leave(object sender, EventArgs e)
        {
            MarkRequiredInputFields();
        }

        private void cmbAddressCountry_Leave(object sender, EventArgs e)
        {
            MarkRequiredInputFields();
        }

        /// <summary>
        /// Executes when the user commits to a selected country in the <c>cmbAddressCountry</c> 
        /// ComboBox. Calls a method to update the highlights for obligatory input fields.
        /// </summary>
        private void cmbAddressCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MarkRequiredInputFields();
        }

        /// <summary>
        /// Executes when the text of the <c>txtAddressCity</c> TextBox is changed.
        /// Calls a method to update the highlights for obligatory input fields.
        /// </summary>
        private void txtAddressCity_TextChanged(object sender, EventArgs e)
        {
            MarkRequiredInputFields();
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
            MarkRequiredInputFields();
        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {
            MarkRequiredInputFields();
        }

        /// <summary>
        /// Highlights a textbox by changing its background color property.
        /// </summary>
        /// <param name="textBox">The <c>TextBox</c> object to be modified.</param>
        private void MarkTextBoxRequired(TextBox textBox)
        {
            textBox.BackColor = Color.MistyRose;
        }

        /// <summary>
        /// Highlights a label by changing its foreground color property.
        /// </summary>
        /// <param name="textBox">The <c>Label</c> object to be modified.</param>
        private void MarkLabelRequired(Label label)
        {
            label.ForeColor = Color.Red;
            //label.Font = new Font(label.Font, FontStyle.Bold);
        }

        private void UnmarkTextBox(TextBox textBox)
        {
            textBox.BackColor = Color.White;
        }

        private void UnmarkLabel(Label label)
        {
            label.ForeColor = Color.Black;
            //label.Font = new Font(label.Font, FontStyle.Regular);
        }

        /// <summary>
        /// Checks whether a textbox is empty (after trimming the string).
        /// </summary>
        /// <param name="textBox">The <c>TextBox</c> object to be checked.</param>
        /// <returns>Returns <c>true</c> if the textbox is empty.</returns>
        private bool IsTextBoxEmpty(TextBox textBox)
        {
            return textBox.Text.Trim() == string.Empty;
        }

    }
}
