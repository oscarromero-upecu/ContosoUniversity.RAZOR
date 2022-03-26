#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        /*Crea una propiedad DbSet<TEntity> para cada conjunto de entidades. En la terminología de EF Core:
        Un conjunto de entidades normalmente se corresponde a una tabla de base de datos.
        Una entidad se corresponde con una fila de la tabla.*/
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments{ get; set; }
        public DbSet<Course> Courses { get; set; }

        /*Llama a OnModelCreating. OnModelCreating:
        se llama cuando SchoolContext se ha inicializado, pero antes de que el modelo se haya bloqueado y utilizado para inicializar el contexto.
        Es necesario porque,la entidad Student tendrá referencias a las demás entidades.*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
