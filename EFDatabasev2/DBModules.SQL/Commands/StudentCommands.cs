using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using DBModules.SQL.Models;
using Microsoft.EntityFrameworkCore;
namespace DBModules.SQL.Commands
{
    public class StudentCommands : IStudentCommands
    {
        private readonly EFTestDbContext _dbContext;
        public StudentCommands(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<StudentCreatedResults> CreateStudent(CreateStudentRequest studentRequest)
        {
            Student student = new Student()
            {
                Address = studentRequest.Address,
                Dob = studentRequest.Dob,
                Name = studentRequest.Name,
                SchoolId = studentRequest.SchoolId,
                StudentID= studentRequest.StudentId,
            };
            try
            {
                _dbContext.Students.Add(student);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            StudentCreatedResults studentCreatedResults = new StudentCreatedResults()
            {
                Age = (((DateTime.Now - student.Dob).Days) / 365),
                Name = student.Name,
                StudentID = student.StudentID
            };

            return studentCreatedResults;
        }
        public async Task DeleteStudent(Guid stuID)
        {
            // Query the DB to retrieve the student record from the database.
            var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentID == stuID);

            if (student != null)
            {
                // Step 2: Remove the student from the DbContext.
                _dbContext.Students.Remove(student);

                // Step 3: Save the changes to the database.
                await _dbContext.SaveChangesAsync();
            }
        }



        public async Task UpdateStudent(Guid stuID, UpdateStudentRequest updateRequest)
        {
            // Step 1: Retrieve the student record from the database.
            var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentID == stuID);

            if (student != null)
            {
                // Step 2: Update student information in the DbContext.
                student.Name = updateRequest.Name;
                student.Address = updateRequest.Address;
                student.Dob = updateRequest.Dob;
                student.SchoolId = updateRequest.SchoolId;

                // Step 3: Save the changes to the database.
                await _dbContext.SaveChangesAsync();
            }

            // You can return a Task.FromResult if needed, but since the method doesn't return any specific result,
            // you can simply use Task.CompletedTask.

        }


        // Create rqeuest results for delete students and update students (shambamba)
        // Write Implementions for update and delete students following DBContext to update and delete
        // Create new commands for the other entities (School, subjects, streams, teachers)
        // Create query for student and other entities
    }

}
