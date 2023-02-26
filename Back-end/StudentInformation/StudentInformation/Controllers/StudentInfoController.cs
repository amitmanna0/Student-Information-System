using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInformation.Data;
using StudentInformation.Models;

namespace StudentInformation.Controllers
{
    /// <summary>
    /// Only Authorized Users can View Details
    /// </summary>
    //[AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentInfoController : ControllerBase
    {
        private readonly StudentInformationContext _context;

        public StudentInfoController(StudentInformationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Allow only Admin 
        /// </summary>
        // GET: api/StudentInfo
        [HttpGet("GetAll"), Authorize(Roles = "Teacher")]
        public async Task<ActionResult<IEnumerable<StudentInfo>>> GetStudentInfo()
        {
            return await _context.StudentInfo.ToListAsync();
        }

        /// <summary>
        /// Allow both Admin and User
        /// </summary>
        // GET: api/StudentInfo/5
        [HttpGet("{id}"), Authorize(Roles = "Teacher, Student")]
        public async Task<ActionResult<StudentInfo>> GetStudentInfo(int id)
        {
            var studentInfo = await _context.StudentInfo.FindAsync(id);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return studentInfo;
        }

        /// <summary>
        /// Allow only Admin 
        /// </summary>
        // PUT: api/StudentInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize(Roles = "Teacher")]
        public async Task<IActionResult> PutStudentInfo(int id, StudentInfo studentInfo)
        {
            var data =await _context.StudentInfo.FindAsync(id);

            if (data == null)
            {
                return BadRequest("User Not found");
            }

            data.StudentRoll = studentInfo.StudentRoll;
            data.StudentName = studentInfo.StudentName;
            data.FatherName = studentInfo.FatherName;
            data.PhoneNumber = studentInfo.PhoneNumber;
            data.Email = studentInfo.Email;
            data.Address = studentInfo.Address;
            data.Course = studentInfo.Course;
            data.Department = studentInfo.Department;
            data.AdmissionYear = studentInfo.AdmissionYear;

            await _context.SaveChangesAsync();

            return Ok(data);
        }

        /// <summary>
        /// Allow only Admin 
        /// </summary>
        // POST: api/StudentInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize(Roles = "Teacher")]
        public async Task<ActionResult<StudentInfo>> PostStudentInfo(StudentInfo studentInfo)
        {
            _context.StudentInfo.Add(studentInfo);
            await _context.SaveChangesAsync();

            return Ok(studentInfo);
        }

        /// <summary>
        /// Allow only Admin 
        /// </summary>
        // DELETE: api/StudentInfo/5
        [HttpDelete("{id}"),Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteStudentInfo(int id)
        {
            var data = await _context.StudentInfo.FindAsync(id);
            if (data == null)
            {
                return Ok("User Not Found");
            }

            _context.StudentInfo.Remove(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }

        private bool StudentInfoExists(int id)
        {
            return _context.StudentInfo.Any(e => e.Id == id);
        }
    }
}
