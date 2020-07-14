using StudentService.BLL.Interfaces;
using StudentService.DAL.Interfaces;
using StudentService.DAL.Models;
using System;
using System.Collections.Generic;

namespace StudentService.BLL.Managers
{
    public class StudentManager : IStudentManager
    {
        private readonly IRepository<Student> _repository;

        public StudentManager(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Student> GetStudents()
        {
            try
            {
                return this._repository.GetAll();
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("An invalid operation during getting the students: " + ex.Message, ex);
            }
        }

        public void AddStudent(Student student)
        {
            try
            {
                this._repository.Add(student);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An invalid operation during adding a student: " + ex.Message, ex);
            }
        }

        public void UpdateStudent(Student student)
        {
            try
            {
                this._repository.Update(student);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An invalid operation during updating a student: " + ex.Message, ex);
            }
        }

        public Student DeleteStudent(int id)
        {
            try
            {
                return this._repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An invalid operation during deleting a student: " + ex.Message, ex);
            }
        }
    }
}
