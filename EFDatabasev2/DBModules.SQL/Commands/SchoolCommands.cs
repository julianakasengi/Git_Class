using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using global::DBModules.SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace DBModules.SQL.Commands
{
   

    namespace DBModules.SQL.Commands
    {
        public class SchoolCommands : ISchoolCommands
        {
            private readonly EFTestDbContext _dbContext;
            public SchoolCommands(EFTestDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<SchoolCreatedResults> CreateSchool(CreateSchoolRequest schoolRequest)
            {
                School school = new School()
                {
                    Name = schoolRequest.Name,
                    Address = schoolRequest.Address,
                    Grade = schoolRequest.Grade,
                    IsPublic = schoolRequest.IsPublic
                    // Add other properties as needed
                };
                try
                {
                    _dbContext.Schools.Add(school);

                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                }

                SchoolCreatedResults schoolCreatedResults = new SchoolCreatedResults()
                {
                    SchoolID = school.SchoolId,
                    Name = school.Name,
                    // Add other properties as needed
                };

                return schoolCreatedResults;
            }

            public async Task DeleteSchool(Guid schoolId)
            {
                var school = await _dbContext.Schools.FirstOrDefaultAsync(s => s.SchoolId == schoolId);

                if (school != null)
                {
                    _dbContext.Schools.Remove(school);
                    await _dbContext.SaveChangesAsync();
                }
            }

            public async Task UpdateSchool(Guid schoolId, UpdateSchoolRequest updateRequest)
            {
                var school = await _dbContext.Schools.FirstOrDefaultAsync(s => s.SchoolId == schoolId);

                if (school != null)
                {
                    school.Name = updateRequest.Name;
                    school.Address = updateRequest.Address;
                    school.Grade = updateRequest.Grade;
                    school.IsPublic = updateRequest.IsPublic;
                    // Update other properties as needed
                    await _dbContext.SaveChangesAsync();
                }
            }


        }
    }

}
