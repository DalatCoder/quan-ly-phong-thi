using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Student
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return LastName + " " + FirstName; } }
        public string FullNameAndId { get { return ID + " - " + LastName + " " + FirstName; } }

        public Student()
        {

        }

        public Student(string iD, string firstName, string lastName)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
