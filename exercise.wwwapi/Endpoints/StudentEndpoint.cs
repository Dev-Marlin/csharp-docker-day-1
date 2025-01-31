using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint
    /// </summary>
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/all", GetStudents);
            students.MapGet("/{id}", GetStudentById);
            students.MapPost("/add", AddStudent);
            students.MapPut("/update/{id}", UpdateStudent);
            students.MapDelete("/delete/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { Data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudentById(IRepository repository, int id)
        {
            var results = await repository.GetStudentById(id);
            var payload = new Payload<Student>() { Data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddStudent(IRepository repository, PostStudent postStudent)
        {
            var payload = new Payload<Student>() { Data = await repository.AddStudent(postStudent) };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id, PutStudent putStudent)
        {
            var payload = new Payload<Student>() { Data = await repository.UpdateStudent(putStudent, id) };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var payload = new Payload<Student>() { Data = await repository.DeleteStudent(id) };
            return TypedResults.Ok(payload);
        }

    }
  

}
