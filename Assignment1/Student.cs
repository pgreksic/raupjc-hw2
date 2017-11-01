using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }


        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            Student comparison = (Student) obj;
            if (this.Jmbag == comparison.Jmbag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator == (Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        public static bool operator != (Student student1, Student student2)
        {
            return !student1.Equals(student2);
        }

        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode();
        }
    }

    public enum Gender
    {
        Male, Female
    }
}
