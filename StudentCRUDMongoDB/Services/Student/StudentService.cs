using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using StudentCRUDMongoDB.Configurations;
using StudentCRUDMongoDB.Models;

namespace StudentCRUDMongoDB.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Students> _studentsCollection;
        public StudentService(IOptions<DatabaseSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _studentsCollection = database.GetCollection<Students>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Students>> GetStudentsListAsync()
        {
            return await _studentsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Students> GetStudentAsync(string id)
        {
            return await _studentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertStudentAsync(Students students)
        {
            await _studentsCollection.InsertOneAsync(students);
        }

        public async Task UpdateStudentAsync(Students students)
        {
            await _studentsCollection.ReplaceOneAsync(x => x.Id == students.Id, students);
        }

        public async Task DeleteStudentAsync(string id)
        {
            await _studentsCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
