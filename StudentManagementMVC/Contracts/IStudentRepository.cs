using StudentManagementMVC.Models;

namespace StudentManagementMVC.Contracts
{
    public interface IStudentRepository
    {
        Task<ICollection<Student>> GetAllStudents();

        Task<Student> GetStudentById(int id);

        Task CreateStudent(Student student);

        Task UpdateStudent(Student student);

        Task DeleteStudent(int id);
    }
}