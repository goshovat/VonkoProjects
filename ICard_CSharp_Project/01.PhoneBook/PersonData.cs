using System;
using System.Collections.Generic;

namespace PhoneBook
{
    public class PersonData
    {
        private string firstName;
        private string lastName;
        private string phone;
        private string address;

        public PersonData
            (string firstName, string lastName, string phone, string address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.address = address;
        }

        public string FirstName
        {
            get { return this.firstName; }
        }

        public string LastName
        {
            get { return this.lastName; }
        }

        public string Phone
        {
            get { return this.phone; }
        }

        public string Address
        {
            get { return this.address; }
        }

        public override string ToString()
        {
            return  this.firstName + "; " + this.lastName
                + "; " + this.phone + "; " + this.address;
        }
    }
}
