using System;

namespace Assignment_05.ContactFiles
{
    /// <summary>
    /// Class <c>Address</c> holds the customer's address information.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class contains three chained constructors.
    /// </para>
    /// <para>
    /// The first one takes no arguments, but calls the second constructor and provides 
    /// two default parameter values. 
    /// </para>
    /// <para>
    /// The second constructor takes two parameters which are used to set the <c>City</c> 
    /// and <c>Street</c> properties. It calls the third constructor and forwards the 
    /// values as parameters, including a default value for zip code.
    /// </para>
    /// <para>
    /// The third constructor takes arguments for city, street and zip code, which 
    /// are used to set those properties. It also sets the <c>Country</c> parameter
    /// with a default value of -1.
    /// </para>
    /// <para>
    /// This chaining makes sure that all fields are initialized to default values,
    /// regardless of the amount of information provided to a constructor when called.
    /// </para>
    /// </remarks>
    /// <value>
    /// <para>
    /// <c>_street</c> is a string for storing a street name.
    /// </para>
    /// <para>
    /// <c>_city</c> is a string for storing a city name.
    /// </para>
    /// <para>
    /// <c>_zipCode</c> is a string for storing a zip code.
    /// </para>
    /// <para>
    /// <c>_country</c> is an Enum for storing a selected country.
    /// </para>
    /// </value>
    public class Address
    {
        private string _street;
        private string _city;
        private string _zipCode;
        private Countries _country;

        public Address() : this(string.Empty, string.Empty) { }

        public Address(string city, string street) : this(city, street, string.Empty)
        {
            City = city;
            Street = street;
        }

        public Address(string city, string street, string zipCode)
        {
            City = city;
            Street = street;
            ZipCode = zipCode;
            Country = (Countries)(-1);
        }

        public string Street // TODO: Add format validation
        {
            get { return _street; }
            set { _street = value; }
        }

        public string City
        {
            get { return _city; }
            set { ValidateCity(value); _city = value; }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set { ValidateZipCode(value); _zipCode = value; }
        }

        public Countries Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// Validates that a city name does not contain digits.
        /// </summary>
        /// <param name="city">The string to be validated.</param>
        /// <returns><c>true</c> if the string validates successfully.</returns>
        /// <exception cref="ArgumentException">The string contains digits.</exception>
        private void ValidateCity(string city)
        {
            if (Utils.HasNumbers(city))
                throw new ArgumentException("Numbers are not allowed in the city name.");
        }

        /// <summary>
        /// Validates that a zip code is alphanumeric.
        /// </summary>
        /// <remarks>
        /// Since we don't require that a zip code is provided by the user, 
        /// the alphanumeric check is skipped if <c>zipCode</c> is empty.
        /// </remarks>
        /// <param name="zipCode">The string to be validated.</param>
        /// <returns><c>true</c> if the string validates successfully.</returns>
        /// <exception cref="ArgumentException">The string is not alphanumeric.</exception>
        private void ValidateZipCode(string zipCode)
        {
            if (zipCode != string.Empty && !Utils.IsAlphanumeric(zipCode))
                throw new ArgumentException("Only numbers and letters are allowed in the zip code.");
        }
    }
}
