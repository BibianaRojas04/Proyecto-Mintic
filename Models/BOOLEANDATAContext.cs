using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BOOLEANDATA.Models
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
        public virtual DbSet<PersonaAdministrativo> PersonaAdministrativos { get; set; } = null!;
        public virtual DbSet<RegistroMatricula> RegistroMatriculas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("server= CAMILO\\SQLEXPRESS; database= BOOLEANDATA; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acudiente>(entity =>
            {
                entity.HasKey(e => e.IdAcudiente)
                    .HasName("PK__Acudient__53B9D5DCE95197C8");

                entity.ToTable("Acudiente");

                entity.Property(e => e.IdAcudiente).HasColumnName("Id_Acudiente");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionCasa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Direccion_casa");

                entity.Property(e => e.DireccionTrabajo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Direccion_trabajo");

                entity.Property(e => e.Dni)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nacimiento");

                entity.Property(e => e.Genero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NombreApellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_apellidos");

                entity.Property(e => e.Ocupacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoCasa)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoOpcional)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_documento");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__Estudian__A85859D2ED3E33C2");

                entity.ToTable("Estudiante");

                entity.Property(e => e.IdEstudiante).HasColumnName("Id_Estudiante");

                entity.Property(e => e.ClavePassword)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Clave_password");

                entity.Property(e => e.DireccionCasa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Direccion_casa");

                entity.Property(e => e.Dni)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nacimiento");

                entity.Property(e => e.Genero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NombreApellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_apellidos");

                entity.Property(e => e.TelefonoCasa)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoOpcional)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_documento");
            });

            modelBuilder.Entity<PersonaAdministrativo>(entity =>
            {
                entity.HasKey(e => e.IdPersonalAdministrativo)
                    .HasName("PK__Persona___7E282F8BB96E5E5A");

                entity.ToTable("Persona_Administrativo");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contacto)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContraseñaAdmin).HasColumnName("Contraseña_Admin");

                entity.Property(e => e.DireccionCasa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Direccion_casa");

                entity.Property(e => e.Dni)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eps)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Ingreso");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nacimiento");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Salida");

                entity.Property(e => e.Genero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NombreApellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_apellidos");

                entity.Property(e => e.SalarioPersonalAdmin).HasColumnName("Salario_Personal_Admin");

                entity.Property(e => e.TelefonoCasa)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoContacto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Telefono_Contacto");

                entity.Property(e => e.TelefonoOpcional)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_documento");
            });

            modelBuilder.Entity<RegistroMatricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricual)
                    .HasName("PK__Registro__403338168F691A81");

                entity.ToTable("Registro_Matricula");

                entity.Property(e => e.IdMatricual).HasColumnName("Id_Matricual");

                entity.Property(e => e.Curso)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaMatricula)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Matricula");

                entity.Property(e => e.IdAcudiente1).HasColumnName("Id_Acudiente_1");

                entity.Property(e => e.IdEstudiante1).HasColumnName("Id_Estudiante_1");

                entity.Property(e => e.IdPersonaAdmi1).HasColumnName("Id_Persona_Admi_1");

                entity.Property(e => e.ValorMatricula).HasColumnName("Valor_Matricula");

                entity.HasOne(d => d.IdAcudiente1Navigation)
                    .WithMany(p => p.RegistroMatriculas)
                    .HasForeignKey(d => d.IdAcudiente1)
                    .HasConstraintName("fk_Matricula_Acudiente");

                entity.HasOne(d => d.IdEstudiante1Navigation)
                    .WithMany(p => p.RegistroMatriculas)
                    .HasForeignKey(d => d.IdEstudiante1)
                    .HasConstraintName("fk_Matricula_Estudiante");

                entity.HasOne(d => d.IdPersonaAdmi1Navigation)
                    .WithMany(p => p.RegistroMatriculas)
                    .HasForeignKey(d => d.IdPersonaAdmi1)
                    .HasConstraintName("fk_Matricula_Persona_Administrativo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
