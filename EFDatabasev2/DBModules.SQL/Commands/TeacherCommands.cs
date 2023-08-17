using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public class TeacherCommands : ITeacherCommands
    {
        private readonly EFTestDbContext _dbContext;
        public TeacherCommands(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TeacherCreatedResults> CreateTeacher(CreateTeacherRequest teacherRequest)
        {
            Teacher teacher=new Teacher()
            {
                Title = teacherRequest.Title,
                FullName = teacherRequest.FullName,
                TscNumber = teacherRequest.TscNumber,
                SchoolId = teacherRequest.SchoolId,
                Level=teacherRequest.Level,
            };
            try
            {
                _dbContext.Teachers.Add(teacher);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            TeacherCreatedResults teacherCreatedResults = new TeacherCreatedResults()
            {
                Title= teacher.Title,
                FullName= teacher.FullName,
                TscNumber= teacher.TscNumber,
                TeacherId=teacher.TeacherId,
               
            };

            return teacherCreatedResults;
        }

        public async Task DeleteTeacher(Guid teacherId)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacherId);

            if (teacher != null)
            {
                _dbContext.Teachers.Remove(teacher);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateTeacher(Guid teacherId, UpdateTeacherRequest updateRequest)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacherId);

            if (teacher != null)
            {
                teacher.Title = updateRequest.Title;
                teacher.FullName = updateRequest.FullName;
                teacher.TscNumber = updateRequest.TscNumber;
                teacher.SchoolId = updateRequest.SchoolId;
                // Update other properties as needed
                await _dbContext.SaveChangesAsync();
            }
        }


    }
}
