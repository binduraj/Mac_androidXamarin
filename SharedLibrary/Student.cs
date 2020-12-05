using System;

namespace SharedLibrary
{
    public class Student
    {
        private string name { get; set; }
        private int age { get; set; }

        public void Name(string inputName)
        {
            name = inputName;
        }

        public void Age (int inputAge)
        {
            age = inputAge;
        }


        public string GetStudentInfo()
        {
            return "Student name is " + name + " and age is " + age.ToString();
        }

    }
}
