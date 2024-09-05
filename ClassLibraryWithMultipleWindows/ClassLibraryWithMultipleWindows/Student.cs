using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryWithMultipleWindows
{
    public class Student
    {
        //Data Members
        private string firstName;
        private string lastName;
        private int age;
        private string campus;
        private string gender;


        //Constructor
        public Student(string firstName, string lastName, int age, string campus, string gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.campus = campus;
            this.gender = gender;
        }


        //Properties
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string Campus { get {  return campus; } set {  campus = value; } }
        public string Gender { get {  return gender; } set {  gender = value; } }

        



    }
}
