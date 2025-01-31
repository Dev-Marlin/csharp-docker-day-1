using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<Course>> GetCourses();
        public Task<Course> GetCourseById(int id);
        public Task<IEnumerable<Student>> GetStudents();
        public Task<Student> GetStudentById(int id);

        public Task<Student> AddStudent(PostStudent postStudent);
        public Task<Student> UpdateStudent(PutStudent putStudent, int id);
        public Task<Student> DeleteStudent(int id);

    }

}
