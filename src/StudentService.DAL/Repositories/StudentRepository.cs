using StudentService.DAL.Interfaces;
using StudentService.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentService.DAL.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly ApplicationContext _db;

        public StudentRepository(ApplicationContext db)
        {
            this._db = db;
        }

        public IEnumerable<Student> GetAll()
        {
            IEnumerable<Student> students = this._db.Students;

            return students;
        }

        public void Add(Student student)
        {
            this._db.Students.Add(student);
            this._db.SaveChanges();
        }

        public void Update(Student student)
        {
            this._db.Students.Update(student);
            this._db.SaveChanges();
        }

        public Student Delete(int id)
        {
            Student student = this._db.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                this._db.Students.Remove(student);
                this._db.SaveChanges();
            }

            return student;
        }
    }
}
