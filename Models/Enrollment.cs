using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A,B,C,D,F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        //El signo de interrogación ? después de la declaración de tipo Grade significa que no se conoce una calificación o que todavía no se ha asignado
        public Grade? Grade { get; set; } 

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
