using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<IEnumerable<Student>> GetStudentByIdAsync(int StudentId);

        public Task<int> AddStudentAsync(Student student);

        public Task<int> UpdateStudentAsync(Student student);

        public Task<int> DeleteStudentAsync(int StudentId);
    }
}
