using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.WebAPI.Models;


#nullable disable

namespace EmployeeManagement.Infra.Repositories
{
    public partial class LearnNowContext : DbContext
    {
        public LearnNowContext()
        {
        }

        public LearnNowContext(DbContextOptions<LearnNowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grade> Grades { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");


                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.GradeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("gradeName");

                entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedOn");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
