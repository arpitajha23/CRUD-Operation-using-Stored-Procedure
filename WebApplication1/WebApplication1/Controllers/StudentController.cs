using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("getstudentlist")]
        public async Task<List<Student>> GetStudentListAsync()
        {
            try
            {
                return await studentService.GetStudentListAsync();
            }
           catch
            {
                throw;
            }
        }

        [HttpGet("getstudentbyid")]
        public async Task<IEnumerable<Student>> GetStudentByIdAsync(int StudentId)
        {
            try
            {
                var response = await studentService.GetStudentByIdAsync(StudentId);

                /*if (response == null)
                {
                    return null;

                }*/
                return response;
            }
            catch
            {
                throw;
            }
        }


        [HttpPost("addstudent")]
        public async Task<IActionResult> AddStudentAsync(Student student)
        {

          /*  if (student == null)
            {
                return BadRequest();

            }*/

            try
            {
                var response = await studentService.AddStudentAsync(student);

                
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updatestudent")]
        public async Task<IActionResult> UpdateStudentAsync(Student student)
        {

        /*    if (student == null)
            {
                return BadRequest();

            }*/

            try
            {
                var result = await studentService.UpdateStudentAsync(student);


                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("deletestudent")]
        public async Task<int> DeleteStudentAsync(int StudentId)
        {
            try
            {
                var response = await studentService.DeleteStudentAsync(StudentId);
                return response;
            }
            catch
            {
                throw;
            }
        }

    }
}
