using System;
using System.Collections.Generic;
using System.Text;

// A simple class for a single user definition
// Another possible usage of this class - to automatically determine monthly user's taxes

namespace Smart_Saver.Backend
{
    class User
    {
        public User()
        {
            //Nothing
        }
        public User(int id, string firstNames, string surname, string email, int income)
        {
            this.Id = id;
            this.FirstNames = firstNames;
            this.Surname = surname;
            this.Email = email;
            this.Income = income;
        }
        public int Id { get; set; }
        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Income { get; set; }
    }
}
