using StudentCRUDMongoDB.Models;

namespace StudentCRUDMongoDB.Services.Student
{
    public interface IStudentService
    {
        public Task<List<Students>> GetStudentsListAsync();

        public Task<Students> GetStudentAsync(string id);

        public Task InsertStudentAsync(Students students);

        public Task UpdateStudentAsync(Students students);

        public Task DeleteStudentAsync(string id);
    }
}
