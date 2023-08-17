using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public interface ITeacherCommands
    {
        Task<TeacherCreatedResults> CreateTeacher(CreateTeacherRequest TeacherRequest);
        Task DeleteTeacher(Guid TeacherId);
        Task UpdateTeacher(Guid TeacherId, UpdateTeacherRequest UpdateRequest);
    }
}
