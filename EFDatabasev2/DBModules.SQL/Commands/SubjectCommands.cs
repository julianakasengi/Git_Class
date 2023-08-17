using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public class SubjectCommands : ISubjectCommands
    {
        private readonly EFTestDbContext _dbContext;
        private Guid subjectId;

        public SubjectCommands(EFTestDbContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public async Task<SubjectCreatedResults>CreateSubject(CreateSubjectRequest Subjectrequest)
        {
            Subject subject = new Subject()
            {
                Name=Subjectrequest.Name,
                Score=Subjectrequest.Score,
                TeacherId=Subjectrequest.TeacherId,
                
            };
            try
            {
                _dbContext.Subjects.Add(subject);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            SubjectCreatedResults subjectCreatedResults = new SubjectCreatedResults()
            {
                Name =subject.Name,
                Score=subject.Score,
                

            };
            return subjectCreatedResults;
        }
        public async Task DeleteSubject(Guid SubjectId)
        {
            var Subject = await _dbContext.Subjects.FirstOrDefaultAsync(t => t.SubjectId==subjectId);
            if (Subject!=null)
            {
                _dbContext.Subjects.Remove(Subject);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateSubject(Guid SubjectId, UpdateSubjectRequest UpdateRequest)
        {
            var Subject = await _dbContext.Subjects.FirstOrDefaultAsync(t => t.SubjectId==subjectId);
            if (Subject!=null)
            {
                Subject.Name = UpdateRequest.Name;
                Subject.Score = UpdateRequest.Score;
                Subject.TeacherId = UpdateRequest.TeacherId;

                await _dbContext.SaveChangesAsync();
            }
        }
        
    }
}
