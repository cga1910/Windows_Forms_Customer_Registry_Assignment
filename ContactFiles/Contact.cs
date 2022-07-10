using System;

namespace Assignment_05.ContactFiles
{
    /// <summary>
    /// Class <c>Contact</c> holds a customer's contact info.
    /// </summary>
    /// <remarks>
    /// <para>
    /// All fields can be accessed through properties.
    /// </para>
    /// <para>
    /// Do not initialize the <c>_firstName</c> field for new instances of the <c>Contact</c> class 
    /// with anything else than null - a new/empty contact is identified by checking whether 
    /// this field is null.
    /// </para>
    /// </remarks>
    /// <value>
    /// <para>FirstName and LastName are strings stored directly in this class.</para>
    /// <para>Address, Phone and Email are separate classes, though their object references 
    /// are kept in fields here.</para>
    /// </value>
    public class Contact
    {
        private string _firstName; // Do not initialize this field
        private string _lastName;

        private Address _address;
        private Phone _phone;
        private Email _email;

        public Contact()
        {
            _address = new Address();
            _phone = new Phone();
            _email = new Email();
        }

        public string FirstName
        {
            get { return _firstName; }
            set { if (NameValidated(value)) _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { if (NameValidated(value)) _lastName = value; }
        }

        public Address Address 
        { 
            get { return _address; } 
            set { _address = value; }
        }

        public Phone Phone
        { 
            get { return _phone; }
            set { _phone = value; }
        }

        public Email Email
        {
            get { return _email; } 
            set { _email = value; }
        }

        /// <summary>
        /// Validates that a customer's name does not contain digits.
        /// </summary>
        /// <param name="name">The string to be validated.</param>
        /// <returns><c>true</c> if the string validates successfully.</returns>
        /// <exception cref="ArgumentException">The string contains numbers.</exception>
        private bool NameValidated(string name)
        {
            if (Utils.HasNumbers(name))
                throw new ArgumentException("Numbers are not allowed in the name.");
            else return true;
        }

        /// <summary>
        /// Checks whether contact data (stored in the instance of this class) contains
        /// the obligatory information: first and/or last name, city and country.
        /// </summary>
        /// <returns><c>true</c> if all the obligatory information was found.</returns>
        public bool CheckRequiredData()
        {
            string city = Address.City;
            Countries? country = Address.Country;

            if (FirstNamePresent() || LastNamePresent())
            {
                if (Utils.IsStringValid(city) && (int)country >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks for the presence of a customer's first name.
        /// </summary>
        /// <returns><c>true</c> if <c>FirstName</c> contained a string longer than 0.</returns>
        public bool FirstNamePresent()
        {
            if (Utils.IsStringValid(FirstName)) return true;
            else return false;
        }

        // TODO: Replace all methods below with one universal method.
        // TODO: Having many methods does benefit code readability though.
        public bool LastNamePresent()
        {
            if (Utils.IsStringValid(LastName)) return true;
            else return false;
        }

        public bool ZipCodePresent()
        {
            if (Utils.IsStringValid(Address.ZipCode)) return true;
            else return false;
        }

        public bool StreetPresent()
        {
            if (Utils.IsStringValid(Address.Street)) return true;
            else return false;
        }

        public bool EmailPrivatePresent()
        {
            if (Utils.IsStringValid(Email.EmailPrivate)) return true;
            else return false;
        }

        public bool EmailBusinessPresent()
        {
            if (Utils.IsStringValid(Email.EmailBusiness)) return true;
            else return false;
        }

        public bool PhoneHomePresent()
        {
            if (Utils.IsStringValid(Phone.NumberHome)) return true;
            else return false;
        }

        public bool PhoneCellPresent()
        {
            if (Utils.IsStringValid(Phone.NumberCell)) return true;
            else return false;
        }

    }
}
