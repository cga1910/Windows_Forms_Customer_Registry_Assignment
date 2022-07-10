using System;

namespace Assignment_05.ContactFiles
{
    /// <summary>
    /// Class <c>Email</c> holds the customer's email addresses.
    /// </summary>
    /// <value>
    /// <para>
    /// <c>_emailBusiness</c> is a string for storing a business email address.
    /// </para>
    /// <para>
    /// <c>_emailPrivate</c> is a string for storing a private email address.
    /// </para>
    /// </value>
    public class Email
    {
        private string _emailBusiness;
        private string _emailPrivate;

        public string EmailBusiness 
        { 
            get { return _emailBusiness; } 
            set { EmailValidated(value); _emailBusiness = value; }
        }

        public string EmailPrivate 
        { 
            get { return _emailPrivate; }
            set { EmailValidated(value); _emailPrivate = value; }
        }

        /// <summary>
        /// Validates the provided email string.
        /// </summary>
        /// <remarks>
        /// Since we don't require that an email address is provided by the user, 
        /// validation is skipped if the string is empty.
        /// </remarks>
        /// <param name="email">The string to be validated.</param>
        /// <exception cref="ArgumentException">The string is not a properly formatted email address.</exception>
        private void EmailValidated(string email)
        {
            if (email != string.Empty && !Utils.IsProperEmail(email))
                throw new ArgumentException("Please make sure that email addresses are properly formatted.");
        }

    }
}
