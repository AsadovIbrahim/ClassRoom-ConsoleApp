using Classroom_Project.Enums;
using Classroom_Project.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom_Project.Models
{
    public class Classroom
    {
        private static int _Id;
        public int Id;

        public string ?Name { get; set; }

        public List<Student> Students=new List<Student>(); 

        public TypeStudent Type { get; set; }

        public Classroom(string name,TypeStudent typeStudent)
        {
            if(name.Length!=5 || !char.IsUpper(name[0]) || !char.IsUpper(name[1]) 
                || !char.IsDigit(name[2]) || !char.IsDigit(name[3]) || !char.IsDigit(name[4]))
            {
                throw new ArgumentException("ClassRoom name is not correct format!");
            }
            Id = ++_Id;
            Name = name;
            Type = typeStudent;

            if((Type==TypeStudent.BackEnd && Students.Count>20)||(Type==TypeStudent.FrontEnd && Students.Count > 15)){
                throw new ArgumentException("Limit has been lifted!");
            }
        }
        public void AddStudent(Student student)
        {
            if (Students == null)
            {
                Students = new List<Student>();
            }
            else
            {
                Students.Add(student);
            }
        }
        public void DeleteStudent(int id)
        {
            
            Student student=Students.Find(s=>s.Id==id)!;
            if (student != null) {
                
                Students.Remove(student);
                Console.WriteLine($"Student:{id} successfully deleted...");
            }
            else
            {
                throw new StudentNotFoundException("Student Not Found!");
            }
        }
        public Student FindId(int id)
        {
            foreach (var item in Students)
            {
                if (item.Id == id)
                {
                    item.ShowInfo();
                }
            }
            return null;
        }
        
    }
}
