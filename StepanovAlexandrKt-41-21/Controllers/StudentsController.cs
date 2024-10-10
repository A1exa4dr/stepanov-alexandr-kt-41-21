using StepanovAlexandrKt_41_21.Filters.StudentFilters;
using StepanovAlexandrKt_41_21.Interfaces.StudentsInterfaces;
using StepanovAlexandrKt_41_21.Models;
using Microsoft.AspNetCore.Mvc;
using StepanovAlexandrKt_41_21.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace StepanovAlexandrKt_41_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;
        StudentDbContext _context;
        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService, StudentDbContext context)
        {
            _logger = logger;
            _studentService = studentService;
            _context = context;
        }

        //добавление
        [HttpPost("AddStudent", Name = "AddStudent")]
        public IActionResult CreateStudent([FromBody] StudentAddFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = new Student();
            student.FirstName = filter.FirstName;
            student.LastName = filter.LastName;
            student.MiddleName = filter.MiddleName;
            //student.GroupId = _context.Set<Models.Group>().FirstOrDefault(g => g.GroupId == filter.GroupId).GroupId;
            student.GroupId=filter.GroupId;
            student.IsDeleted = false;

            _context.Set<Student>().Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPut("EditStudent")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentAddFilter filter)
        {
            var UpdStudent = _context.Set<Student>().FirstOrDefault(g => g.StudentId == id);

            if (UpdStudent == null)
            {
                return NotFound();
            }

            UpdStudent.FirstName = filter.FirstName;
            UpdStudent.LastName = filter.LastName;
            UpdStudent.MiddleName = filter.MiddleName;
            //student.GroupId = _context.Set<Models.Group>().FirstOrDefault(g => g.GroupId == filter.GroupId).GroupId;
            UpdStudent.GroupId = filter.GroupId;
            UpdStudent.IsDeleted = filter.IsDeleted;

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("GetStudentsByGroupId")]
        public async Task<IActionResult> GetStudentsByGroupIdAsync(StudentGroupIdFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupIdAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("GetStudentsByFIO")]
        public async Task<IActionResult> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByFIOAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("GetStudentsByLastName")]
        public async Task<IActionResult> GetStudentsByLastNameAsync(StudentLastNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByLastNameAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("GetStudentsByName")]
        public async Task<IActionResult> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByNameAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("GetStudentsIsDeleted")]
        public async Task<IActionResult> GetStudentsByExistAsync(StudentDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsIsDeletedAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteGroup(int id)
        {
            var existingStudent = _context.Set<Student>().FirstOrDefault(g => g.StudentId == id);

            if (existingStudent == null)
            {
                return NotFound();
            }
            //_context.Set<Student>().Remove(existingStudent);
            existingStudent.IsDeleted = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
