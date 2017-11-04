using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Assignment1;

namespace Assignment4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(number => number).OrderBy(number => number.Key).Select(number => "Broj " + number.Key + " ponavlja se " + number.Count() + " puta")
                .ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray
                .Where(university => university.Students.All(student => student.Gender.Equals(Gender.Male)))
                .ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {

            int average = (int) universityArray.Average(university => university.Students.Length);
                
            return universityArray.Where(university => university.Students.Length <  average)
                .ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(university => university.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray
                .Where(university => university.Students.All(student => student.Gender.Equals(Gender.Male)) ||
                                     university.Students.All(student => student.Gender.Equals(Gender.Female)))
                .SelectMany(university => university.Students)
                .Distinct()
                .ToArray();
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(university => university.Students)
                .GroupBy(student => student)
                .Where(student => student.Count() >= 2)
                .Select(student => student.Key)
                .ToArray();
        }

    }
}
