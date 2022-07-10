using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assignment_05
{
    /// <summary>
    /// Class <c>Utils</c> provides tools that might be useful in several classes. 
    /// </summary>
    /// <remarks>
    /// <para>
    /// The purpose of this class is to reduce redundancy by avoiding identical methods
    /// in multiple classes.
    /// </para>
    /// <para>
    /// Access the methods in this class by inheriting the class, or by typing out the
    /// class name, for example: <c>Utils.SomeMethod()</c>
    /// </para>
    /// </remarks>
    public class Utils
    {
        /// <summary>
        /// Checks if a string is valid, i.e. contains anything meaningful.
        /// </summary>
        /// <param name="str">The string to be checked.</param>
        /// <returns>
        /// <c>true</c> if the string is not null, and not empty / only spaces.
        /// </returns>
        public static bool IsStringValid(string str)
        {
            if (str != null) 
                if (str.Trim().Length != 0) return true;
            return false;
        }

        /// <summary>
        /// Searches a string and replaces all instances of a specified char with another char.
        /// </summary>
        /// <param name="inputString">The string to be processed.</param>
        /// <param name="targetChar">The char to be replaced.</param>
        /// <param name="newChar">The char to replace with.</param>
        /// <returns>The resulting string.</returns>
        public static string ReplaceCharsInString(string inputString, char targetChar, char newChar)
        {
            string result = string.Empty;
            List<char> charList = inputString.ToList();

            if (charList.Contains(targetChar))
            {
                for (int i = 0; i < charList.Count; i++)
                {
                    if (charList[i] == targetChar) result += newChar;
                    else result += charList[i];
                }
                return result;
            }
            else return inputString;
        }

        /// <summary>
        /// Checks that a string only contains letters, digits or spaces.
        /// </summary>
        /// <remarks>
        /// Regexp source: https://regex101.com
        /// </remarks>
        /// <param name="str">The string to be checked.</param>
        /// <returns>
        /// <c>true</c> if there are only letters and/or numbers in the string. 
        /// Spaces are allowed.
        /// </returns>
        public static bool IsAlphanumeric(string str)
        {
            Regex regex = new Regex("[^a-zA-Z0-9 ]"); // Matches all chars besides digits, letters, or spaces

            if (regex.IsMatch(str)) return false;
            else return true;
        }

        /// <summary>
        /// Checks if a string contains digits.
        /// </summary>
        /// <param name="str">The string to be checked.</param>
        /// <returns>
        /// <c>true</c> if the string contains any digits, otherwise <c>false</c>.
        /// </returns>
        public static bool HasNumbers(string str)
        {
            Regex regex = new Regex("[0-9]");

            if (regex.IsMatch(str)) return true;
            else return false;
        }

        /// <summary>
        /// Checks if a string contains periods (.) or @-symbols, which are always
        /// present in email addresses.
        /// </summary>
        /// <remarks>
        /// A very primitive and insufficient email string validator.
        /// </remarks>
        /// <param name="str">The string to be checked.</param>
        /// <returns><c>true</c> if the string contains periods or @-symbols.</returns>
        // 
        public static bool HasEmailChars(string str)
        {
            if (str.Contains<char>('@') && str.Contains<char>('.')) return true;
            else return false;
        }

        /// <summary>
        /// Checks whether a string holds a proper email address.
        /// </summary>
        /// <remarks>
        /// <para>Uses the following regular expression: ^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$</para>
        /// <para>Regexp author: Steven Smith</para>
        /// <para>Regexp source: https://www.regexlib.com/REDetails.aspx?regexp_id=21</para>
        /// </remarks>
        /// <param name="email">The string to be checked.</param>
        /// <returns><c>true</c> if the string matches the regular expression.</returns>
        public static bool IsProperEmail(string email)
        {
            Regex regex = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            if (regex.IsMatch(email)) return true;
            else return false;
        }

    }
}
