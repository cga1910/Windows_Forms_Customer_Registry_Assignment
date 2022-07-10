using System.Collections.Generic;
using Assignment_05.ContactFiles;

namespace Assignment_05
{
    /// <summary>
    /// Class <c>CustomerManager</c> is responsible for managing customer data records.
    /// <para>
    /// It provides methods for adding, deleting, replacing and getting <c>Customer</c> 
    /// object references.
    /// </para>
    /// </summary>
    /// <value>
    /// <c>_customers</c> holds a reference to a <c>List</c> of <c>Customer</c> objects.
    /// </value>
    public class CustomerManager
    {
        private List<Customer> _customers;

        internal CustomerManager()
        {
            _customers = new List<Customer>();
        }

        /// <summary>
        /// Adds a customer to the list, after stamping it with an id.
        /// </summary>
        /// <remarks>
        /// The method will make sure that the new id is not occupied
        /// </remarks>
        /// <param name="newCustomer">The <c>Customer</c> object to be added.</param>
        internal void AddCustomer(Customer newCustomer)
        {
            int numOfCustomers = _customers.Count;
            int newId = numOfCustomers + 100;
            
            for (int i = 0; i < numOfCustomers; i++)
                if (_customers[i].Id == newId) newId += 1;

            newCustomer.Id = newId;
            _customers.Add(newCustomer);
        }

        /// <summary>
        /// Gets a <c>Customer</c> object from a specific index in the list.
        /// </summary>
        /// <param name="index">The index from which to get the <c>Customer</c> object.</param>
        /// <returns>
        /// The <c>Customer</c> object found,
        /// <para>
        /// or a new (empty) <c>Customer</c> object if the provided index was out of bounds.
        /// </para>
        /// </returns>
        internal Customer GetCustomer(int index)
        {
            if (CheckIndex(index)) return _customers[index];
            else return new Customer(new Contact());
        }

        /// <summary>
        /// Replaces a <c>Customer</c> object in the list, if the provided index is within bounds.
        /// </summary>
        /// <param name="newContact">The <c>Contact</c> object to replace with.</param>
        /// <param name="customerIndex">The index at which to replace the object.</param>
        internal void ChangeCustomerContact(Contact newContact, int customerIndex)
        {
            if (CheckIndex(customerIndex)) _customers[customerIndex].Contact = newContact;
        }

        /// <summary>
        /// Deletes a <c>Customer</c> object from the list.
        /// </summary>
        /// <param name="index">An integer value for the index at which to delete an object.</param>
        internal void DeleteCustomer(int index)
        {
            if (CheckIndex(index)) _customers.RemoveAt(index);
        }
        
        /// <summary>
        /// Checks whether an index is within the bounds of the list.
        /// </summary>
        /// <param name="index">An integer value for the index to checked.</param>
        /// <returns><c>true</c> if the index value is within the bounds of the list.</returns>
        internal bool CheckIndex(int index)
        {
            if (index < _customers.Count && index >= 0) return true;
            else return false;
        }

    }
}
