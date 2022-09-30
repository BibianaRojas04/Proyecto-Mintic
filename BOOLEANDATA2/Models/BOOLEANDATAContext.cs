using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BOOLEANDATA2.Models
{
    public partial class BOOLEANDATAContext : DbContext
    {
        public BOOLEANDATAContext()
        {
        }

        public BOOLEANDATAContext(DbContextOptions<BOOLEANDATAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acudiente> Acudientes { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<PersonalAdmin> PersonalAdmins { get; set; } = null!;
        public virtual DbSet<RegistroMatricula> RegistroMatriculas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               // optionsBuilder.UseSqlServer("Data Source=DESKTOP-2PCMBJQ; Initial Catalog=BOOLEANDATA; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acudiente>(entity =>
            {
                entity.HasKey(e => e.IdAcudiente)
                    .HasName("PK__Acudient__53B9D5DC229B51A4");

                entity.ToTable("Acudiente");

                entity.Property(e => e.IdAcudiente).HasColumnName("Id_Acudiente");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nacimiento");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ocupacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Parentesco)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Documento");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__Estudian__A85859D2B0B33946");

                entity.ToTable("Estudiante");

                entity.Property(e => e.IdEstudiante).HasColumnName("Id_Estudiante");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Curso)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nacimiento");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_documento");
            });

            modelBuilder.Entity<PersonalAdmin>(entity =>
            {
                entity.HasKey(e => e.IdPerAdm)
                    .HasName("PK__Personal__42170D52096A1E10");

                entity.ToTable("Personal_admin");

                entity.Property(e => e.IdPerAdm).HasColumnName("Id_per_adm");

                entity.Property(e => e.Clave)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<RegistroMatricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricula)
                    .HasName("PK__Registro__40336132AF169F94");

                entity.ToTable("Registro_Matricula");

                entity.Property(e => e.IdMatricula).HasColumnName("Id_Matricula");

                entity.Property(e => e.Curso)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaMatricula)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Matricula");

                entity.Property(e => e.IdAcudiente1).HasColumnName("Id_Acudiente_1");

                entity.Property(e => e.IdEstudiante1).HasColumnName("Id_Estudiante_1");

                entity.Property(e => e.IdPersonaAdmi1).HasColumnName("Id_Persona_Admi_1");

                entity.Property(e => e.ValorMatricula).HasColumnName("Valor_Matricula");

                entity.HasOne(d => d.IdAcudiente1Navigation)
                    .WithMany(p => p.RegistroMatriculas)
                    .HasForeignKey(d => d.IdAcudiente1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Acudiente_RegistroMatricula");

                entity.HasOne(d => d.IdEstudiante1Navigation)
                    .WithMany(p => p.RegistroMatriculas)
                    .HasForeignKey(d => d.IdEstudiante1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Estudiantes_RegistroMatricula");

                entity.HasOne(d => d.IdPersonaAdmi1Navigation)
                    .WithMany(p => p.RegistroMatriculas)
                    .HasForeignKey(d => d.IdPersonaAdmi1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Admin_RegistroMatricula");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
