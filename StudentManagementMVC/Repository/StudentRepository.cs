using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Contracts;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbcontext;

        public StudentRepository(AppDbContext context)
        {
            _dbcontext = context;
        }

        public async Task CreateStudent(Student student)
        {
            await _dbcontext.Students.AddAsync(student);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _dbcontext.Students.FirstOrDefaultAsync(x => x.Id == id);
            _dbcontext.Students.Remove(student);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<ICollection<Student>> GetAllStudents()
        {
            return await _dbcontext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _dbcontext.Students.FirstOrDefaultAsync(x => x.Id == id);
            return student;
        }

        public async Task UpdateStudent(Student student)
        {
            _dbcontext.Students.Update(student);
            await _dbcontext.SaveChangesAsync();
        }
    }
}