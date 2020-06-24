using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Task1.Models
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public float AvgMark { get; set; }

        public Student() { }

        public Student(string name, float avgMark) 
        {
            Name = name;
            AvgMark = avgMark;
        }
    }
}