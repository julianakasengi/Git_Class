using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DBModules.SQL;
using Microsoft.Extensions.Logging;
using DBModules.SQL.Commands;
using EFDatabase;
using DBModules.SQL.Commands.DBModules.SQL.Commands;

public class Program
{
    public static void Main(string[] args)
    {
        var hostBuilder= CreateHostBuilder(args);
        //hostBuilder.Build().Run();
        //CreateHostBuilder(args).Build().Run();
        //var ServiceCollection = new ServiceCollection();
        //using (var serviceProvider = ServiceCollection.BuildServiceProvider())
        //{
        //    var QImplementations=serviceProvider.GetRequiredService<QueryImplementation>();
        //}
        var host = hostBuilder.Build();
        using (var serviceProvider = host.Services.CreateScope())
        {
            var commandImplementation =serviceProvider.ServiceProvider.GetRequiredService<CommandImplementation>();
            //commandImplementation.CreateSchool();
            //commandImplementation.CreateStudent();
           //commandImplementation.CreateTeacher();
            commandImplementation.CreateSubject();

        }
        host.Run();
    }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(config =>
            {

            }).ConfigureServices(services =>
            {
                // Replace with your connection string.
                var connectionString = "server=localhost;user=root;password=1234 ;database=eftestdb";

                // Replace with your server version and type.
                // Use 'MariaDbServerVersion' for MariaDB.
                // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
                // For common usages, see pull request #1233.
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

                // Replace 'YourDbContext' with the name of your own DbContext derived class.
                services.AddDbContext<EFTestDbContext>(
                            dbContextOptions => dbContextOptions
                                .UseMySql(connectionString, serverVersion, s => { s.MigrationsAssembly("EFDatabase");

                                })

                                     // The following three options help with debugging, but should
                                     // be changed or removed for production.
                                     .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors());
                //add services as Transient, scope
                services.AddTransient<IStudentCommands, StudentCommands>();
                services.AddTransient<QueryImplementation>();
                services.AddTransient<CommandImplementation>();
                services.AddTransient<ISchoolCommands, SchoolCommands>();
                services.AddTransient<ISubjectCommands, SubjectCommands>();
                services.AddTransient<ITeacherCommands,  TeacherCommands>();


            });

    }
