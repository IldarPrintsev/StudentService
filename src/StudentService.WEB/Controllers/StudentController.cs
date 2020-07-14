using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentService.BLL.Interfaces;
using StudentService.DAL.Models;
using System;
using System.Collections.Generic;

namespace StudentService.WEB.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _manager;

        public StudentController(IStudentManager manager)
        {
            this._manager = manager;
        }

        [HttpGet, Authorize(Roles = "User, Admin, Manager")]
        public IEnumerable<Student> GetStudents()
        {
            return this._manager.GetStudents();
        }

        [HttpPost, Authorize(Roles = "Admin, Manager")]
        public IActionResult AddStudent(Student student)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._manager.AddStudent(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("InternalError", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut, Authorize(Roles = "Admin, Manager")]
        public IActionResult UpdateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._manager.UpdateStudent(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("InternalError", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}"), Authorize(Roles = "Manager")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                Student student = this._manager.DeleteStudent(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("InternalError", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
