using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Queries
{
    public interface ISubjectQueries
    {
        Task<List<SubjectCreatedResults>> ListSubjects();
    }
    public class SubjectQueries: ISubjectQueries
    {
        private readonly EFTestDbContext _dbContext;
        public SubjectQueries(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<SubjectCreatedResults>> ListSubjects()
        {
            var SubjectList= await _dbContext.Subjects.Select(t=> new SubjectCreatedResults
            {
                Name=t.Name,
                Score=t.Score,
                
            }).ToListAsync();

            return SubjectList;
        } 
    }
}
