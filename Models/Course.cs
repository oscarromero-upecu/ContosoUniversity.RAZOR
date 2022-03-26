using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        //El atributo DatabaseGenerated permite que la aplicación especifique la clave principal en lugar de hacer que la base de datos la genere.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        //ICollection<> quiere decir que la entidad Course puede tomar cualquier atributo de Enrollment
        public ICollection<Enrollment> Enrollments { get;set; }
    }
}