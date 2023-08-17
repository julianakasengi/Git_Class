using DBModules.SQL.Models;
using Microsoft.EntityFrameworkCore;
using Stream = DBModules.SQL.Models.Stream;

namespace DBModules.SQL
{
    public class EFTestDbContext : DbContext
    {

        public EFTestDbContext(DbContextOptions opt): base(opt) 
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=localhost;user=root;password=S!kuol@254 ;database=eftestdb",);
        //    base.OnConfiguring(optionsBuilder);
        //}

        //find out what OnConfiguring does alongside other overrides
        //create and run EF migrations of the models; using the .NET CLI or packet manager that will map the database models into the database tables
        //confirm you have the correct connection strings

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Teacher db model
            modelBuilder.Entity<Teacher>().ToTable("Teachers");

            modelBuilder.Entity<Teacher>().
                HasOne(d => d.School)
                .WithMany(d => d.Teachers);
            //Student db model
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Student>().
                HasOne(d => d.School)
                .WithMany(d => d.Students);
            //Stream db model
            modelBuilder.Entity<Stream>().ToTable("Streams");
            modelBuilder.Entity<Stream>().
                HasOne(d => d.School)
                .WithMany(d => d.Streams);

            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<Subject>()
                .HasOne(r => r.Teacher)
                .WithMany(r => r.Subjects);

            modelBuilder.Entity<StudentSubjectJoin>()
                .HasKey(x => new { x.SubjectId, x.StudentID })
                .HasName("Pk_Joined");
            modelBuilder.Entity<StudentSubjectJoin>()
               .HasOne(f => f.Subject)
               .WithMany(f => f.Students);






            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<Student> Students { get; set; } 

        public virtual DbSet<Stream> Streams { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public object Subject { get; internal set; }
    }
}      