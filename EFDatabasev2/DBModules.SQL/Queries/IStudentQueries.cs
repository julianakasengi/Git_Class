using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Queries
{
    public interface IStudentQueries
    {
        Task<List<StudentCreatedResults>> ListStudents();
        // Add more Queries that accept parameters to filter the list of students
        
    }

    public class StudentQueries : IStudentQueries
    {
        private readonly EFTestDbContext _dbContext;

        public StudentQueries(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
       
        }
        public async Task<List<StudentCreatedResults>> ListStudents()
        {
            var studentList = await _dbContext.Students.Select(s => new StudentCreatedResults
            {
                Age = s.Age,
                Name = s.Name,
                StudentID = s.StudentID,
            }).ToListAsync();

            return studentList;
        }
    }

}
