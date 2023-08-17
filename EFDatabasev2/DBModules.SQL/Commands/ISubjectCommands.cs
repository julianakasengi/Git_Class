using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public interface ISubjectCommands
    {
        Task<SubjectCreatedResults> CreateSubject(CreateSubjectRequest SubjectRequest);
        Task DeleteSubject(Guid SubjectId);
        Task UpdateSubject(Guid SubjectId, UpdateSubjectRequest UpdateRequest);
    }
}
