using Classroom_Project.Enums;
using Classroom_Project.Exceptions;
using Classroom_Project.Models;



public class Classroom
{
    private static int _Id;
    public int Id;
    public string Name { get; set; }
    public Student[] Students;
    public TypeStudent Type { get; set; }

    public Classroom(string name, TypeStudent typeStudent)
    {
        if (name.Length != 5 || !char.IsUpper(name[0]) || !char.IsUpper(name[1]) || !char.IsDigit(name[2]) || !char.IsDigit(name[3]) || !char.IsDigit(name[4]))
        {
            throw new ArgumentException("ClassRoom name is not correct format!");
        }

        Id = ++_Id;
        Name = name;
        Type = typeStudent;
        Students = new Student[0];
    }
    public Classroom()
    {
        Id = ++_Id;
        Students= new Student[0];
        
    }
    public void AddStudent(Student student)
    {
        if (Students==null)
        {
            throw new ClassRoomNotFoundException("Classroom has not been created!");
        }
        else
        {
            if ((Type == TypeStudent.BackEnd && Students.Length >= 20) || (Type == TypeStudent.FrontEnd && Students.Length >= 15))
            {
                throw new ArgumentException("Classroom limit has been reached!");
            }

            Array.Resize(ref Students, Students.Length + 1);
            Students[Students.Length - 1] = student;
        }
    }

    public void DeleteStudent(int id)
    {
        try
        {
            int index = -1; 
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i].Id == id)
                {
                    index = i; 
                    break; 
                }
            }

            if (index != -1)
            {
                Array.Copy(Students, index + 1, Students, index, Students.Length - index - 1);
                Array.Resize(ref Students, Students.Length - 1);
                Console.WriteLine("Student has been deleted successfully.");
            }
            else
            {
                throw new StudentNotFoundException("Student Not Found!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void ShowAllStudents()
    {
        if (Students != null && Students.Length > 0)
        {
            foreach (var student in Students)
            {
                student.ShowInfo();
                Console.WriteLine("-------------");
            }
        }
        else
        {
            Console.WriteLine("Empty!");
        }
    }

    public Student FindId(int id)
    {
        foreach (var student in Students)
        {
            if (student.Id == id)
            {
                student.ShowInfo();
                return student;
            }
        }
        throw new StudentNotFoundException("Student not found!");
    }
}
