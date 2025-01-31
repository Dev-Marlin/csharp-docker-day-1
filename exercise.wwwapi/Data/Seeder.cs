using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        private List<string> nameList;
        private List<string> courseCodeList;
        public List<Course> CoursesList { get; set; } = new List<Course>();
        public List<Student> StudentsList { get; set; } = new List<Student>();
        public Seeder() { 
            nameList = new List<string>();
            courseCodeList = new List<string>();

            InitializeNames();
            InitializeCourseCodes();
            InitializeStudents();
            InitializeCourses();
        }

        private void InitializeStudents()
        {
            Random randCourse = new Random();
            for (int i = 1; i <= 20; i++)
            {
                Student student = new Student()
                {
                    Name = nameList[i-1],
                    CourseId = randCourse.Next(5)+1,
                    Id = i
                };

                StudentsList.Add(student);
            }
        }

        private void InitializeCourses()
        {
            Random randCourse = new Random();

            int counter = 1;
            for (int i = 1; i <= 5; i++)
            {
                Course course = new Course()
                {
                    Id = i,
                    CourseCode = courseCodeList[randCourse.Next(5)],
                };
                counter++;
                CoursesList.Add(course);
            }
        }

        private void InitializeNames()
        {
            nameList.Add("Martin");
            nameList.Add("Nigel");
            nameList.Add("Mattias");
            nameList.Add("Sofia");
            nameList.Add("Amanda");
            nameList.Add("Leif");
            nameList.Add("Elias");
            nameList.Add("Johannes");
            nameList.Add("Karl");
            nameList.Add("Anna");
            nameList.Add("Erik");
            nameList.Add("David");
            nameList.Add("Melker");
            nameList.Add("Emma");
            nameList.Add("Malin");
            nameList.Add("Frida");
            nameList.Add("Matilda");
            nameList.Add("Samuel");
            nameList.Add("Arvid");
            nameList.Add("Petter");
        }

        private void InitializeCourseCodes()
        {
            courseCodeList.Add("EDA-15");
            courseCodeList.Add("AFF-19");
            courseCodeList.Add("EDA-55");
            courseCodeList.Add("EPF-25");
            courseCodeList.Add("AKL-43");
        }
    }
}
