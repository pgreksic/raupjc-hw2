﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1;
using System.Threading;


namespace Assignement1Test
{
    class CaseTest
    {
        static void Main(string[] Args)
        {


            Case1();
            Case2();
            Case3();
            Thread.Sleep(15000);


        }

        static void Case1()
        {
            var topStudents = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 "),
                new Student (" Luka ", jmbag :" 3274272 "),
                new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            bool isIvanTopStudent = topStudents.Contains(ivan);
            Console.WriteLine(isIvanTopStudent.ToString());
        }


        static void Case2()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 "),
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            // 2 :(
            var distinctStudentsCount = list.Distinct().Count();
            Console.WriteLine(distinctStudentsCount.ToString());
        }


        static void Case3()
        {
            var topStudents = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 "),
                new Student (" Luka ", jmbag :" 3274272 "),
                new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            // == operator is a different operation from . Equals ()
            // Maybe it isn ’t such a bad idea to override it as well
            bool isIvanTopStudent = topStudents.Any(s => s == ivan);
            Console.WriteLine(isIvanTopStudent.ToString());
        }
    }
}
