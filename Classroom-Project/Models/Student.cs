using Classroom_Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom_Project.Models
{
    public class Student
    {
        private static int _Id;
        public int Id;

        public string ?Name { get; set; }
        public string ?Surname { get; set; }

        public Classroom Classroom { get; set; } = new();
        public Student()
        {
            Id = ++_Id;
        }
        public Student(string name,string surname)
        {
            Id = ++_Id;
            Name = name;
            Surname = surname;
        }
        public Student(string name,string surname,TypeStudent typeStudent)
        {
            Id = ++_Id;
            Name = name;
            Surname = surname;
            Classroom!.Type=typeStudent;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Id:{Id}\nName:{Name}\nSurname:{Surname}\nStudentType:{Classroom.Type}");
        }
    }


}
