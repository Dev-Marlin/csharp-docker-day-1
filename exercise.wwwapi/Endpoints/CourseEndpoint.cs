using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("courses");
            students.MapGet("/all", GetCourses);
            students.MapGet("/{id}", GetCourseById);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { Data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourseById(IRepository repository, int id)
        {
            var results = await repository.GetCourseById(id);
            var payload = new Payload<Course>() { Data = results };
            return TypedResults.Ok(payload);
        }
    }
}
