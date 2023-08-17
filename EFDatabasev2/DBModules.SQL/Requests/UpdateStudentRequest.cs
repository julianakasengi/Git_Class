namespace DBModules.SQL.Requests
{
    public class UpdateStudentRequest
    {
        public string? Name { get; internal set; }
        public string Address { get; internal set; }
        public DateTime Dob { get; internal set; }
        public Guid SchoolId { get; internal set; }
    }
}