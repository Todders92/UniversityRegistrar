
using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Course
    {
        public Course()
        {
            this.Students = new HashSet<CourseDepartmentStudent>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public virtual ICollection<CourseDepartmentStudent> Students { get; set; }
    }
}