using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        public readonly StudentContext _context;
        public StudentService(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
             _context.Students.Add(student);
             await _context.SaveChangesAsync();
             return student;

        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.Id);
            if(existingStudent== null) return false;
            existingStudent.Name=student.Name;
            existingStudent.Age=student.Age;
            existingStudent.Grade=student.Grade;

            await _context.SaveChangesAsync();
            return true;
        }

         public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if(student== null) return false;
            _context.Students.Remove(student);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}