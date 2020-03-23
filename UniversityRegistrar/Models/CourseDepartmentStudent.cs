namespace UniversityRegistrar.Models
{
  public class CourseDepartmentStudent
    {       
        public int CourseDepartmentStudentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}