using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:LocalDockerInstance");//("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            Seeder seeder = new Seeder();

            /*modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>().HasOne(c => c.Course).WithMany(c => c.Students);//.HasForeignKey(s => s.Id);//HasPrincipalKey(s => new {s.Id, s.StudentId});
            modelBuilder.Entity<Student>().HasData(seeder.Students);

            modelBuilder.Entity<Course>().HasKey(c => c.Id);//(c =>  new { c.Id, c.StudentId});
            modelBuilder.Entity<Course>().HasMany(c => c.Students).WithOne(c => c.Course).HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<Course>().HasData(seeder.Courses);*/
            modelBuilder.Entity<Student>().HasOne(s => s.Course).WithMany(c => c.Students).HasForeignKey(s => s.CourseId);
            modelBuilder.Entity<Student>().HasData(seeder.StudentsList);
            modelBuilder.Entity<Course>().HasData(seeder.CoursesList);

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
