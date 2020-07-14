using StudentService.DAL.Models;
using System.Collections.Generic;

namespace StudentService.BLL.Interfaces
{
    public interface IStudentManager
    {
        IEnumerable<Student> GetStudents();

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        Student DeleteStudent(int id);
    }
}
