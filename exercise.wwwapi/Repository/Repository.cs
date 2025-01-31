using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }
        public async Task<Course> GetCourseById(int id)
        {
            return await _db.Courses.FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _db.Students.FirstAsync(x => x.Id == id);
        }

        public async Task<Student> UpdateStudent(PutStudent putStudent, int id)
        {
            Student student = await _db.Students.FirstAsync(x => x.Id==id);
            var studentToUpdate = _db.Students.Update(student).Entity;

            if(putStudent.CourseId != null)
            {
                studentToUpdate.CourseId = (int)putStudent.CourseId;
            }

            if (putStudent.Name != null)
            {
                studentToUpdate.Name = putStudent.Name;
            }
            await _db.SaveChangesAsync();

            return student;
        }

        public async Task<Student> AddStudent(PostStudent postStudent)
        {
            Student studentTobeAdded = new Student()
            {
                Name = postStudent.Name,
                CourseId = postStudent.CourseId
            };

            await _db.Students.AddAsync(studentTobeAdded);
            await _db.SaveChangesAsync();

            return studentTobeAdded;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            Student studentToDelete = await _db.Students.FirstAsync(x=> x.Id==id);
            _db.Students.Remove(studentToDelete);
            await _db.SaveChangesAsync();

            return studentToDelete;
        }
    }
}
