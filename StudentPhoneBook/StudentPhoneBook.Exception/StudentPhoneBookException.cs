using System;

namespace StudentPhoneBook.Exceptions
{
    public class StudentPhoneBookException : ApplicationException
    {
        public StudentPhoneBookException() : base()
        {
        }

        public StudentPhoneBookException(string message) : base(message)
        {
        }
        public StudentPhoneBookException(string message, Exception innerException) : base(message, innerException)
        {
        }
        static void Main()
        {
        }
    }
}