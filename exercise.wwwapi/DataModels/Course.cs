namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
