namespace demoEFapp.DTOs
{
    public class StudentReadDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public bool IsActive { get; set; }
        public int StudentAge { get; set; }
        public string? PhotoName { get; set; }
    }
}