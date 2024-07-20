using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class StudentService : IStudentService
    {
        private readonly DbContextData _dbContext;
        public StudentService(DbContextData dbContext) { 
            _dbContext = dbContext;
        }


        /*data fatch*/

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _dbContext.Student.FromSqlRaw<Student>("GetStudentList").ToListAsync();
        }


        /*data fatch by id*/
        public async Task< IEnumerable<Student>> GetStudentByIdAsync(int StudentId)
        {
            var param = new SqlParameter("@StudentId", StudentId);

            var StudentDetails = await Task.Run(() => _dbContext.Student
                               .FromSqlRaw(@"exec GetStudentIdByID @StudentId", param).ToListAsync());

            return StudentDetails;
            
        }


        /*add api*/
        public async Task<int> AddStudentAsync(Student student)
        {
            var parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@StudentName", student.StudentName));
            parameter.Add(new SqlParameter("@StudentEmail ", student.StudentEmail));
            parameter.Add(new SqlParameter("@Course ", student.Course));
            parameter.Add(new SqlParameter("@PhoneNumber  ", student.PhoneNumber));
            /*   parameter.Add(new SqlParameter("@StudentStatus  ", student.StudentStatus));*/

            var result = await Task.Run(() => _dbContext.Database
                    .ExecuteSqlRawAsync(@"exec AddStudent @StudentName, @StudentEmail, @Course, @PhoneNumber",
                    parameter.ToArray()));
               
            return result;

        }


        /*update api*/
        public async Task<int> UpdateStudentAsync(Student student)
        {
            var parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@StudentName", student.StudentName));
            parameter.Add(new SqlParameter("@StudentEmail ", student.StudentEmail));
            parameter.Add(new SqlParameter("@Course ", student.Course));
            parameter.Add(new SqlParameter("@PhoneNumber  ", student.PhoneNumber));
            /*   parameter.Add(new SqlParameter("@StudentStatus  ", student.StudentStatus));*/

            var result = await Task.Run(() => _dbContext.Database
                    .ExecuteSqlRawAsync(@"exec UpdateStudent @StudentName, @StudentEmail, @Course, @PhoneNumber",
                    parameter.ToArray()));

            return result;

        }


        /*delete api*/
        public async Task<int> DeleteStudentAsync(int StudentId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteStudentByID {StudentId}"));
        }


    }
}
