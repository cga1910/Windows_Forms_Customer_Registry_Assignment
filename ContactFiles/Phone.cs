namespace Assignment_05.ContactFiles
{
    /// <summary>
    /// Class <c>Phone</c> holds the customer's phone numbers.
    /// </summary>
    /// <value>
    /// <para>
    /// <c>_numberHome</c> is a string for storing a private phone number.
    /// </para>
    /// <para>
    /// <c>_numberCell</c> is a string for storing a business phone number.
    /// </para>
    /// </value>
    public class Phone
    {
        private string _numberHome;
        private string _numberCell;

        public string NumberHome // TODO: Add format validation
        { 
            get { return _numberHome; } 
            set { _numberHome = value; }
        }

        public string NumberCell // TODO: Add format validation
        {
            get { return _numberCell; }
            set { _numberCell = value; }
        }

    }
}
