using DBModules.SQL;
using DBModules.SQL.Commands;
using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabase
{
    public class CommandImplementation
    {
        private readonly IStudentCommands _studentCommands;
        private readonly ISchoolCommands _schoolCommands;
        private readonly ISubjectCommands _subjectCommands;
        private readonly ITeacherCommands _teacherCommands;
        private readonly EFTestDbContext _dbContext;


        public CommandImplementation(IStudentCommands studentCommands,
            ISchoolCommands schoolCommands, ISubjectCommands subjectCommands,
            ITeacherCommands teacherCommands, EFTestDbContext dbContext)
        {
            _studentCommands = studentCommands;
            _schoolCommands = schoolCommands;
            _subjectCommands = subjectCommands;
            _teacherCommands = teacherCommands;
            _dbContext=dbContext;

        }
        public int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            {
                age -= 1;
            }
            return age;
        }
        public async void CreateSchool()
        {
            Console.WriteLine("Enter Name of a School");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the schools address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the grade");
            string grade = Console.ReadLine();


            var SchoolRequest = new CreateSchoolRequest
            {
                SchoolID=Guid.NewGuid(),
                Name=name,
                Address=address,
                Grade = Convert.ToInt32(grade),
                IsPublic=true
            };
            var result = await _schoolCommands.CreateSchool(SchoolRequest);
            Console.WriteLine($"School has been created as{result.Name}");
        }
        public async void CreateStudent()
        {
            Console.WriteLine("Enter the name of a student");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the date of birth of the student");
            string dobInput = Console.ReadLine();
            Console.WriteLine("Enter the student Address");
            string address = Console.ReadLine();
            var school = _dbContext.Schools.FirstOrDefault();
            if (DateTime.TryParse(dobInput, out DateTime dob))
            {
                var age = CalculateAge(dob);

                var StudentRequest = new CreateStudentRequest
                {
                    Name=name,
                    Dob=Convert.ToDateTime(dob),
                    Address=address,
                    SchoolId=school.SchoolId,
                    StudentId=Guid.NewGuid(),
                    Age=age
                    



                };
                var result = await _studentCommands.CreateStudent(StudentRequest);
                Console.WriteLine($"Student has been created as{result.StudentID} ");
            }
            else {
                Console.WriteLine("Invalid date of birth");
                    }
        }
        public async void CreateTeacher()
        {

            Console.WriteLine("Enter the Title of a Teacher");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the full name of the Teacher ");
            string fullname = Console.ReadLine();
            Console.WriteLine("Enter the Tsc Number of the Teacher ");
            string TscNumber = Console.ReadLine();
            Console.WriteLine("Enter the Teacher's Level(Junior, Intermediate, senior)");
            string levelinput = Console.ReadLine();
            var school= _dbContext.Schools.FirstOrDefault();
            if (Enum.TryParse(typeof(GradeLevel), levelinput, true, out object level))
            {

                var TeacherRequest = new CreateTeacherRequest
                {
                    Title=title,
                    FullName=fullname,
                    TscNumber=Convert.ToInt32(TscNumber),
                    SchoolId = school.SchoolId,
                    TeacherId=Guid.NewGuid(),
                    Level=(DBModules.SQL.Models.GradeLevel)level,
                };
                var result = await _teacherCommands.CreateTeacher(TeacherRequest);
                Console.WriteLine($"Teacher has been created as {result.TeacherId}");
            }
            else
            {
                Console.WriteLine("Invalid Teacher's level");
            }
        }


        public enum GradeLevel
        {
            Junior,
            Intermediate,
            Senior
        }


        public async void CreateSubject()
        {
            Console.WriteLine("Enter the name of the Subject");
            string name=Console.ReadLine();
            Console.WriteLine("Enter the score of the subject");
            string score = Console.ReadLine();
            var school=_dbContext.Schools.FirstOrDefault();
            var student= _dbContext.Students.FirstOrDefault();
            var teacher= _dbContext.Teachers.FirstOrDefault();
            

            var SubjectRequest = new CreateSubjectRequest
            {
                Name=name,
                Score=Convert.ToInt32(score),
                TeacherId = teacher.TeacherId,
                SchoolId=school.SchoolId,
                SubjectId=Guid.NewGuid(),
                StudentId=student.StudentID,

            };
            var result = await _subjectCommands.CreateSubject(SubjectRequest);
            Console.WriteLine($"Subject has been created as {result.SubjectId}");
        }
    }
    



}

