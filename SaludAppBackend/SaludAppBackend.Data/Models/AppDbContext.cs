using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SaludAppBackend.Data.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAreasMedica> TbAreasMedicas { get; set; }

    public virtual DbSet<TbBarrio> TbBarrios { get; set; }

    public virtual DbSet<TbCentrosMedico> TbCentrosMedicos { get; set; }

    public virtual DbSet<TbDepartamento> TbDepartamentos { get; set; }

    public virtual DbSet<TbDireccione> TbDirecciones { get; set; }

    public virtual DbSet<TbEspecialidade> TbEspecialidades { get; set; }

    public virtual DbSet<TbGenero> TbGeneros { get; set; }

    public virtual DbSet<TbMedico> TbMedicos { get; set; }

    public virtual DbSet<TbMunicipio> TbMunicipios { get; set; }

    public virtual DbSet<TbOcupacione> TbOcupaciones { get; set; }

    public virtual DbSet<TbPaciente> TbPacientes { get; set; }

    public virtual DbSet<TbPasswd> TbPasswds { get; set; }

    public virtual DbSet<TbProvTelefonico> TbProvTelefonicos { get; set; }

    public virtual DbSet<TbReligione> TbReligiones { get; set; }

    public virtual DbSet<TbTelefono> TbTelefonos { get; set; }

    public virtual DbSet<TbTipoUsuario> TbTipoUsuarios { get; set; }

    public virtual DbSet<TbTurnosMedico> TbTurnosMedicos { get; set; }

    public virtual DbSet<TbUniversidade> TbUniversidades { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_spanish_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TbAreasMedica>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PRIMARY");

            entity.ToTable("tb_areas_medicas");

            entity.Property(e => e.IdArea).HasColumnName("Id_area");
            entity.Property(e => e.Area).HasMaxLength(50);
        });

        modelBuilder.Entity<TbBarrio>(entity =>
        {
            entity.HasKey(e => e.IdBarrio).HasName("PRIMARY");

            entity.ToTable("tb_barrios");

            entity.Property(e => e.IdBarrio).HasColumnName("Id_barrio");
            entity.Property(e => e.Barrio).HasMaxLength(50);
        });

        modelBuilder.Entity<TbCentrosMedico>(entity =>
        {
            entity.HasKey(e => e.IdCentro).HasName("PRIMARY");

            entity.ToTable("tb_centros_medicos");

            entity.HasIndex(e => e.Departamento, "Departamento");

            entity.HasIndex(e => e.Municipio, "Municipio");

            entity.Property(e => e.IdCentro).HasColumnName("Id_centro");
            entity.Property(e => e.Centro).HasMaxLength(50);

            entity.HasOne(d => d.DepartamentoNavigation).WithMany(p => p.TbCentrosMedicos)
                .HasForeignKey(d => d.Departamento)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_centros_medicos_ibfk_1");

            entity.HasOne(d => d.MunicipioNavigation).WithMany(p => p.TbCentrosMedicos)
                .HasForeignKey(d => d.Municipio)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_centros_medicos_ibfk_2");
        });

        modelBuilder.Entity<TbDepartamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PRIMARY");

            entity.ToTable("tb_departamentos");

            entity.Property(e => e.IdDepartamento).HasColumnName("Id_departamento");
            entity.Property(e => e.Departamento).HasMaxLength(50);
        });

        modelBuilder.Entity<TbDireccione>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PRIMARY");

            entity.ToTable("tb_direcciones");

            entity.HasIndex(e => e.Barrio, "Barrio");

            entity.HasIndex(e => e.Departamento, "Departamento");

            entity.HasIndex(e => e.IdUsuario, "Id_usuario");

            entity.HasIndex(e => e.Municipio, "Municipio");

            entity.Property(e => e.IdDireccion).HasColumnName("Id_direccion");
            entity.Property(e => e.Direccion).HasColumnType("text");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

            entity.HasOne(d => d.BarrioNavigation).WithMany(p => p.TbDirecciones)
                .HasForeignKey(d => d.Barrio)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_direcciones_ibfk_4");

            entity.HasOne(d => d.DepartamentoNavigation).WithMany(p => p.TbDirecciones)
                .HasForeignKey(d => d.Departamento)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_direcciones_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TbDirecciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_direcciones_ibfk_1");

            entity.HasOne(d => d.MunicipioNavigation).WithMany(p => p.TbDirecciones)
                .HasForeignKey(d => d.Municipio)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_direcciones_ibfk_3");
        });

        modelBuilder.Entity<TbEspecialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PRIMARY");

            entity.ToTable("tb_especialidades");

            entity.Property(e => e.IdEspecialidad).HasColumnName("Id_especialidad");
            entity.Property(e => e.Especialidad).HasMaxLength(50);
        });

        modelBuilder.Entity<TbGenero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PRIMARY");

            entity.ToTable("tb_generos");

            entity.Property(e => e.IdGenero).HasColumnName("Id_genero");
            entity.Property(e => e.Genero).HasMaxLength(50);
        });

        modelBuilder.Entity<TbMedico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PRIMARY");

            entity.ToTable("tb_medicos");

            entity.HasIndex(e => e.AreaActual, "Area_actual");

            entity.HasIndex(e => e.CentroActual, "Centro_actual");

            entity.HasIndex(e => e.CodSanitario, "Cod_sanitario").IsUnique();

            entity.HasIndex(e => e.EgresadoDe, "Egresado_de");

            entity.HasIndex(e => e.Especialidad, "Especialidad");

            entity.HasIndex(e => e.IdUsuario, "Id_usuario");

            entity.HasIndex(e => e.TurnoActual, "Turno_actual");

            entity.Property(e => e.IdMedico).HasColumnName("Id_medico");
            entity.Property(e => e.AreaActual).HasColumnName("Area_actual");
            entity.Property(e => e.CentroActual).HasColumnName("Centro_actual");
            entity.Property(e => e.CodSanitario)
                .HasMaxLength(50)
                .HasColumnName("Cod_sanitario");
            entity.Property(e => e.EgresadoDe).HasColumnName("Egresado_de");
            entity.Property(e => e.EgresadoEl).HasColumnName("Egresado_el");
            entity.Property(e => e.ExperienciaAnyos).HasColumnName("Experiencia_anyos");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.TurnoActual).HasColumnName("Turno_actual");

            entity.HasOne(d => d.AreaActualNavigation).WithMany(p => p.TbMedicos)
                .HasForeignKey(d => d.AreaActual)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_medicos_ibfk_4");

            entity.HasOne(d => d.CentroActualNavigation).WithMany(p => p.TbMedicos)
                .HasForeignKey(d => d.CentroActual)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_medicos_ibfk_5");

            entity.HasOne(d => d.EgresadoDeNavigation).WithMany(p => p.TbMedicos)
                .HasForeignKey(d => d.EgresadoDe)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_medicos_ibfk_3");

            entity.HasOne(d => d.EspecialidadNavigation).WithMany(p => p.TbMedicos)
                .HasForeignKey(d => d.Especialidad)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_medicos_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TbMedicos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_medicos_ibfk_1");

            entity.HasOne(d => d.TurnoActualNavigation).WithMany(p => p.TbMedicos)
                .HasForeignKey(d => d.TurnoActual)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_medicos_ibfk_6");
        });

        modelBuilder.Entity<TbMunicipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PRIMARY");

            entity.ToTable("tb_municipios");

            entity.Property(e => e.IdMunicipio).HasColumnName("Id_municipio");
            entity.Property(e => e.Municipio).HasMaxLength(50);
        });

        modelBuilder.Entity<TbOcupacione>(entity =>
        {
            entity.HasKey(e => e.IdOcupacion).HasName("PRIMARY");

            entity.ToTable("tb_ocupaciones");

            entity.Property(e => e.IdOcupacion).HasColumnName("Id_ocupacion");
            entity.Property(e => e.Ocupacion).HasMaxLength(100);
        });

        modelBuilder.Entity<TbPaciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PRIMARY");

            entity.ToTable("tb_pacientes");

            entity.HasIndex(e => e.IdUsuario, "Id_usuario").IsUnique();

            entity.HasIndex(e => e.NumeroInss, "Numero_inss").IsUnique();

            entity.HasIndex(e => e.Ocupacion, "Ocupacion");

            entity.HasIndex(e => e.Religion, "Religion");

            entity.Property(e => e.IdPaciente).HasColumnName("Id_paciente");
            entity.Property(e => e.CantidadHermanos).HasColumnName("Cantidad_hermanos");
            entity.Property(e => e.Escolaridad).HasColumnType("enum('NO TIENE','PRIMARIA','SECUNDARIA','UNIVERSIDAD')");
            entity.Property(e => e.EstadoCivil)
                .HasColumnType("enum('SOLTER@','CASAD@','DIVORCIAD@','VIUD@','UNION LIBRE')")
                .HasColumnName("Estado_civil");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.NumeroInss)
                .HasMaxLength(9)
                .IsFixedLength()
                .HasColumnName("Numero_inss");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.TbPaciente)
                .HasForeignKey<TbPaciente>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_pacientes_ibfk_1");

            entity.HasOne(d => d.OcupacionNavigation).WithMany(p => p.TbPacientes)
                .HasForeignKey(d => d.Ocupacion)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_pacientes_ibfk_2");

            entity.HasOne(d => d.ReligionNavigation).WithMany(p => p.TbPacientes)
                .HasForeignKey(d => d.Religion)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_pacientes_ibfk_3");
        });

        modelBuilder.Entity<TbPasswd>(entity =>
        {
            entity.HasKey(e => e.IdPasswd).HasName("PRIMARY");

            entity.ToTable("tb_passwd");

            entity.HasIndex(e => e.IdUsuario, "Id_usuario").IsUnique();

            entity.Property(e => e.IdPasswd).HasColumnName("Id_passwd");
            entity.Property(e => e.HashPasswd)
                .HasColumnType("text")
                .HasColumnName("hash_passwd");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.TbPasswd)
                .HasForeignKey<TbPasswd>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_passwd_ibfk_1");
        });

        modelBuilder.Entity<TbProvTelefonico>(entity =>
        {
            entity.HasKey(e => e.IdProvTel).HasName("PRIMARY");

            entity.ToTable("tb_prov_telefonicos");

            entity.Property(e => e.IdProvTel).HasColumnName("Id_prov_tel");
            entity.Property(e => e.Proveedor).HasMaxLength(50);
        });

        modelBuilder.Entity<TbReligione>(entity =>
        {
            entity.HasKey(e => e.IdReligion).HasName("PRIMARY");

            entity.ToTable("tb_religiones");

            entity.Property(e => e.IdReligion).HasColumnName("Id_religion");
            entity.Property(e => e.Religion).HasMaxLength(50);
        });

        modelBuilder.Entity<TbTelefono>(entity =>
        {
            entity.HasKey(e => e.IdTelefono).HasName("PRIMARY");

            entity.ToTable("tb_telefonos");

            entity.HasIndex(e => e.Compania, "Compania");

            entity.HasIndex(e => e.IdUsuario, "Id_usuario");

            entity.HasIndex(e => e.Telefono, "Telefono").IsUnique();

            entity.Property(e => e.IdTelefono).HasColumnName("Id_telefono");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

            entity.HasOne(d => d.CompaniaNavigation).WithMany(p => p.TbTelefonos)
                .HasForeignKey(d => d.Compania)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_telefonos_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TbTelefonos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_telefonos_ibfk_1");
        });

        modelBuilder.Entity<TbTipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PRIMARY");

            entity.ToTable("tb_tipo_usuarios");

            entity.Property(e => e.IdTipoUsuario).HasColumnName("Id_tipo_usuario");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(50)
                .HasColumnName("Tipo_usuario");
        });

        modelBuilder.Entity<TbTurnosMedico>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PRIMARY");

            entity.ToTable("tb_turnos_medicos");

            entity.Property(e => e.IdTurno).HasColumnName("Id_turno");
            entity.Property(e => e.Turno).HasMaxLength(50);
        });

        modelBuilder.Entity<TbUniversidade>(entity =>
        {
            entity.HasKey(e => e.IdUniversidad).HasName("PRIMARY");

            entity.ToTable("tb_universidades");

            entity.Property(e => e.IdUniversidad).HasColumnName("Id_universidad");
            entity.Property(e => e.Universidad).HasMaxLength(50);
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("tb_usuarios");

            entity.HasIndex(e => e.Cedula, "Cedula").IsUnique();

            entity.HasIndex(e => e.Genero, "Genero");

            entity.HasIndex(e => e.TipoUsuario, "Tipo_usuario");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Cedula)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.FechaActualizacion).HasColumnName("Fecha_actualizacion");
            entity.Property(e => e.FechaCreacion).HasColumnName("Fecha_creacion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_nacimiento");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .HasColumnName("Primer_apellido");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(50)
                .HasColumnName("Primer_nombre");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .HasColumnName("Segundo_apellido");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(50)
                .HasColumnName("Segundo_nombre");
            entity.Property(e => e.TipoUsuario).HasColumnName("Tipo_usuario");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.GeneroNavigation).WithMany(p => p.TbUsuarios)
                .HasForeignKey(d => d.Genero)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_usuarios_ibfk_1");

            entity.HasOne(d => d.TipoUsuarioNavigation).WithMany(p => p.TbUsuarios)
                .HasForeignKey(d => d.TipoUsuario)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_usuarios_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
