using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Assignment_05.ContactFiles;

namespace Assignment_05
{
    /// <summary>
    /// Partial class <c>FormMain</c> provides the main GUI window.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is responsible for user interaction, validating user input, 
    /// formatting and displaying data and error messages.
    /// </para>
    /// <para>
    /// <c>FormMain</c> instantiates the class <c>CustomerManager</c> which is used for 
    /// adding, deleting, changing and getting customer/contact data.
    /// </para>
    /// <para>
    /// This form uses the font Cascadia Code: https://github.com/microsoft/cascadia-code
    /// </para>
    /// </remarks>
    public partial class MainForm : Form
    {
        // Throughout this project I've been using an underscore to indicate field variables,
        // which I found quite helpful. Fields become easy to see regardless of color theme,
        // and easy to find when starting typing in Visual Studio.

        private CustomerManager _customerManager;

        public MainForm()
        {
            _customerManager = new CustomerManager();

            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            // Nothing to do here, yet
        }

        /// <summary>
        /// Executes when the Add button is clicked. Instantiates a new contact form, 
        /// providing it with an empty <c>Contact</c> object.
        /// </summary>
        /// <remarks>
        /// Uses the <c>DialogReult</c> enum to determine whether to save customer
        /// data after the contact form has been closed.
        /// </remarks>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm(new Contact());
            DialogResult dialogResults = contactForm.ShowDialog();

            if (dialogResults == DialogResult.OK) // Save customer data
            {
                Contact contact = contactForm.Contact;
                _customerManager.AddCustomer(new Customer(contact));
                UpdateCustomerList();
            }
            else 
                MessageBox.Show("Any data entered was discarded.");
        }

        /// <summary>
        /// Loops through the entire customer list stored in <c>CustomerManager</c>
        /// in order to update the <c>lstCustomers</c> listbox.
        /// </summary>
        /// <remarks>
        /// It may not be a good idea to use this method often if the list is very long, 
        /// but ensures the GUI list represents the actual customer list stored in the 
        /// customer manager.
        /// </remarks>
        private void UpdateCustomerList()
        {
            Customer customer;
            string format = "{0, -5} {1, -34} {2, -19} {3, 29}";
            string customerRow;
            int index = 0;

            lstCustomers.Items.Clear();

            while (_customerManager.CheckIndex(index))
            {
                customer = _customerManager.GetCustomer(index);
                
                customerRow = string.Format(format,
                    customer.Id,
                    FormatCustomerName(customer.Contact),
                    customer.Contact.Phone.NumberCell,
                    customer.Contact.Email.EmailBusiness);
                lstCustomers.Items.Add(customerRow);
                index++;
            }
        }

        /// <summary>
        /// Formats the customer's name to be displayed in the list.
        /// </summary>
        private string FormatCustomerName(Contact contact)
        {
            // If either first or last name is present (but not both)
            if (contact.FirstNamePresent() ^ contact.LastNamePresent())
            {
                if (contact.FirstNamePresent()) return contact.FirstName;
                if (contact.LastNamePresent()) return contact.LastName;
            }
            else // Both are present
            {
                return contact.LastName + ", " + contact.FirstName;
            }
            return "[no name found]";
        }

        /// <summary>
        /// Executes when the Edit button is clicked. Instantiates a new contact form 
        /// with contact data from the selected customer.
        /// </summary>
        /// <remarks>
        /// Uses the <c>DialogResult</c> enum to decide whether to update the customer data 
        /// after the contact form has been closed.
        /// </remarks>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstCustomers.SelectedIndex;

            if (selectedIndex >= 0)
            {
                Customer customer = _customerManager.GetCustomer(selectedIndex);
                ContactForm contactForm = new ContactForm(customer.Contact);

                DialogResult dialogResults = contactForm.ShowDialog();

                if (dialogResults == DialogResult.OK) // Update the customer's contact data
                {
                    Contact contact = contactForm.Contact;
                    _customerManager.ChangeCustomerContact(contact, selectedIndex);
                    UpdateCustomerList();
                    lstCustomers.SelectedIndex = selectedIndex;
                }
                else
                {
                    //MessageBox.Show("Changes were discarded.");
                }
            }
            else MessageBox.Show("Please select a customer from the list first.");
        }

        /// <summary>
        /// Executes when the Delete button is clicked. Calls method in <c>CustomerManager</c>
        /// to delete the selected customer, if one has been selected.
        /// </summary>
        /// <remarks>
        /// Shows a confirmation dialog to avoid accidental deletion.
        /// </remarks>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a customer from the list first.");
            }
            else if (lstCustomers.SelectedItems.Count == 1)
            {
                DialogResult confirmDelete = MessageBox.Show
                    ("Do you really want to delete the selected customer?", "Please confirm", 
                    MessageBoxButtons.YesNo);

                if (confirmDelete == DialogResult.Yes)
                {
                    lblContactDetails.Text = string.Empty;
                    _customerManager.DeleteCustomer(lstCustomers.SelectedIndex);
                    UpdateCustomerList();
                }
            }
        }

        /// <summary>
        /// Executes when the selected index of the customer list changes.
        /// </summary>
        /// <remarks>
        /// When clicking in the listbox without selecting an index, this method will be executed
        /// anyway since the index changes from null to -1 (none selected). We therefore need to
        /// check for that, and make sure there's always an item selected.
        /// </remarks>
        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lstCustomers.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Customer selectedCustomer = _customerManager.GetCustomer(selectedIndex);
                List<string> contactDetails = PrepareContactDetails(selectedCustomer.Contact);
                DisplayContactDetails(contactDetails);
            }
            else lstCustomers.SelectedIndex = 0;
        }

        /// <summary>
        /// Reads contact data from a contact object and returns a list of formatted strings, 
        /// ready to be displayed in the contact details section.
        /// </summary>
        /// <param name="contact">The <c>Contact</c> object to be read.</param>
        /// <returns>A <c>List</c> of strings.</returns>
        private List<string> PrepareContactDetails(Contact contact)
        {
            // One benefit of storing the formatted strings in a list, is that they are
            // then ready to be used or outputted in other ways, maybe to some other type
            // of form component (without much change of code), or to a file.

            List<string> contactDetails = new List<string>();

            // Getting of data before adding to the list:

            Address address = contact.Address;
            Email email = contact.Email;
            Phone phone = contact.Phone;
            string firstName = contact.FirstName;
            string lastName = contact.LastName;
            string street = address.Street;
            string zip = address.ZipCode;
            string city = address.City;
            string country = Utils.ReplaceCharsInString(address.Country.ToString(), '_', ' ');
            string emailBusiness = email.EmailBusiness;
            string emailPrivate = email.EmailPrivate;
            string phoneHome = phone.NumberHome;
            string phoneCell = phone.NumberCell;

            // Formatting and adding strings to the list:

            if (contact.FirstNamePresent()) firstName += " ";
            contactDetails.Add(firstName + lastName); // Name is obligatory

            if (contact.StreetPresent()) contactDetails.Add(street);
            if (contact.ZipCodePresent()) zip += " ";
            contactDetails.Add(zip + city); // City is obligatory

            contactDetails.Add(country); // Country is obligatory

            bool emailPrivatePresent = contact.EmailPrivatePresent();
            bool emailBusinessPresent = contact.EmailBusinessPresent();
            bool phoneHomePresent = contact.PhoneHomePresent();
            bool phoneCellPresent = contact.PhoneCellPresent();

            if (emailPrivatePresent || emailBusinessPresent)
            {
                contactDetails.Add("\nEmails");
                if (emailPrivatePresent) contactDetails.Add(" Private   " + emailPrivate);
                if (emailBusinessPresent) contactDetails.Add(" Office    " + emailBusiness);
            }
            if (phoneHomePresent || phoneCellPresent)
            {
                contactDetails.Add("\nPhone numbers");
                if (phoneHomePresent) contactDetails.Add(" Private   " + phoneHome);
                if (phoneCellPresent) contactDetails.Add(" Office    " + phoneCell);
            }
            return contactDetails;
        }

        /// <summary>
        /// Displays the contact details by appending strings one by one, to the label's text.
        /// </summary>
        /// <param name="contactDetails">A <c>List</c> of strings.</param>
        private void DisplayContactDetails(List<string> contactDetails)
        {
            lblContactDetails.Text = string.Empty;

            foreach (string contactDetail in contactDetails)
                lblContactDetails.Text += contactDetail + "\n";
        }

        /// <summary>
        /// Copies the currently displayed contact details to the user's clipboard.
        /// </summary>
        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string detailsText = lblContactDetails.Text;

            if (detailsText != string.Empty && detailsText != null)
                Clipboard.SetText(lblContactDetails.Text);
        }

    }
}
