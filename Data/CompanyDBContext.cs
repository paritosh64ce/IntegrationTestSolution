using Company.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace Company.Data
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext() : base() { }

        public CompanyDBContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Department

            modelBuilder.Entity<Department>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_U_Department") { IsUnique = true })
                    );

            #endregion

            #region Employee
            modelBuilder.Entity<Employee>()
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_U_Email") { IsUnique = true })
                    );

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
