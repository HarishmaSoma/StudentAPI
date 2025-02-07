using StudentAPI.Models;

namespace StudentAPI.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}