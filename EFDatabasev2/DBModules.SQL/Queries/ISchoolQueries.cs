using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Queries
{
    public interface ISchoolQueries
    {
        Task<List<SchoolCreatedResults>> ListSchools();
    }
    public class SchoolQueries : ISchoolQueries

    { 
            
        private readonly EFTestDbContext _dbContext;

        public SchoolQueries(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<List<SchoolCreatedResults>> ListSchools()
        {
            var schoolList = await _dbContext.Schools.Select(s => new SchoolCreatedResults
            {
                SchoolID = s.SchoolId,
                Name = s.Name,
                Address = s.Address,
                IsPublic=s.IsPublic,
                Grade=s.Grade

            }).ToListAsync();

            return schoolList;
        }
    }
}

