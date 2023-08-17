using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public interface ISchoolCommands
    {
        Task<SchoolCreatedResults> CreateSchool(CreateSchoolRequest schoolRequest);
        Task DeleteSchool(Guid SchoolId);
        Task UpdateSchool(Guid schoolId, UpdateSchoolRequest updateRequest);

    }
}
