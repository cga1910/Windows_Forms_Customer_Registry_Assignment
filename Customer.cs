using Assignment_05.ContactFiles;

namespace Assignment_05
{
    /// <summary>
    /// Class <c>Customer</c> is the base class for a customer record.
    /// </summary>
    /// <value>
    /// <para>
    /// <c>_contact</c> holds a reference to a <c>Contact</c> object.
    /// </para>
    /// <para>
    /// <c>_id</c> holds a customer ID of type integer.
    /// </para>
    /// </value>
    public class Customer
    {
        private Contact _contact;
        private int _id;

        public Customer(Contact contact)
        {
            _contact = contact;
        }

        public Contact Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        public int Id 
        { 
            get { return _id; } 
            set { _id = value; } 
        }

    }
}
