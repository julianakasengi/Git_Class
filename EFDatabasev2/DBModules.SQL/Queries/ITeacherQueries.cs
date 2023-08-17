using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Queries
{
    public interface ITeacherQueries
    {
        Task<List<TeacherCreatedResults>> ListTeachers();
    }
    public class TeacherQueries : ITeacherQueries

    {

        private readonly EFTestDbContext _dbContext;

        public TeacherQueries(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<List<TeacherCreatedResults>> ListTeachers()
        {
            var teacherList = await _dbContext.Teachers.Select(t => new TeacherCreatedResults
            {
                Title = t.Title,
                FullName = t.FullName,
                TscNumber = t.TscNumber,
                SchoolId = t.SchoolId

            }).ToListAsync();

            return teacherList;
        }
    }
}
