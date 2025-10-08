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

    public virtual DbSet<TbAntecedentesFamiliaresPatologico> TbAntecedentesFamiliaresPatologicos { get; set; }

    public virtual DbSet<TbAntecedentesPersonalesNoPatologico> TbAntecedentesPersonalesNoPatologicos { get; set; }

    public virtual DbSet<TbAntecedentesPersonalesPatologico> TbAntecedentesPersonalesPatologicos { get; set; }

    public virtual DbSet<TbArchivo> TbArchivos { get; set; }

    public virtual DbSet<TbArchivosCitasLab> TbArchivosCitasLabs { get; set; }

    public virtual DbSet<TbArchivosCitasMedica> TbArchivosCitasMedicas { get; set; }

    public virtual DbSet<TbAreasMedica> TbAreasMedicas { get; set; }

    public virtual DbSet<TbBarrio> TbBarrios { get; set; }

    public virtual DbSet<TbCentrosMedico> TbCentrosMedicos { get; set; }

    public virtual DbSet<TbCirugia> TbCirugias { get; set; }

    public virtual DbSet<TbCita> TbCitas { get; set; }

    public virtual DbSet<TbCitasLaboratorio> TbCitasLaboratorios { get; set; }

    public virtual DbSet<TbCitasMedica> TbCitasMedicas { get; set; }

    public virtual DbSet<TbDepartamento> TbDepartamentos { get; set; }

    public virtual DbSet<TbDireccione> TbDirecciones { get; set; }

    public virtual DbSet<TbDrogasLegale> TbDrogasLegales { get; set; }

    public virtual DbSet<TbEnfermedadesCronica> TbEnfermedadesCronicas { get; set; }

    public virtual DbSet<TbEnfermedadesHereditaria> TbEnfermedadesHereditarias { get; set; }

    public virtual DbSet<TbEnfermedadesInfectoContagiosa> TbEnfermedadesInfectoContagiosas { get; set; }

    public virtual DbSet<TbEsAlcoholico> TbEsAlcoholicos { get; set; }

    public virtual DbSet<TbEsFumador> TbEsFumadors { get; set; }

    public virtual DbSet<TbEscolaridad> TbEscolaridads { get; set; }

    public virtual DbSet<TbEspecialidade> TbEspecialidades { get; set; }

    public virtual DbSet<TbEstadoCivil> TbEstadoCivils { get; set; }

    public virtual DbSet<TbExamenesDisponiblesLab> TbExamenesDisponiblesLabs { get; set; }

    public virtual DbSet<TbFarmacosActuale> TbFarmacosActuales { get; set; }

    public virtual DbSet<TbGenero> TbGeneros { get; set; }

    public virtual DbSet<TbHistorialMedico> TbHistorialMedicos { get; set; }

    public virtual DbSet<TbHospitalizacione> TbHospitalizaciones { get; set; }

    public virtual DbSet<TbMedicamentosRecetado> TbMedicamentosRecetados { get; set; }

    public virtual DbSet<TbMedico> TbMedicos { get; set; }

    public virtual DbSet<TbMunicipio> TbMunicipios { get; set; }

    public virtual DbSet<TbOcupacione> TbOcupaciones { get; set; }

    public virtual DbSet<TbPaciente> TbPacientes { get; set; }

    public virtual DbSet<TbPasswd> TbPasswds { get; set; }

    public virtual DbSet<TbProvTelefonico> TbProvTelefonicos { get; set; }

    public virtual DbSet<TbReligione> TbReligiones { get; set; }

    public virtual DbSet<TbResumenCitaMedica> TbResumenCitaMedicas { get; set; }

    public virtual DbSet<TbStado> TbStados { get; set; }

    public virtual DbSet<TbTelefono> TbTelefonos { get; set; }

    public virtual DbSet<TbTipoActFisica> TbTipoActFisicas { get; set; }

    public virtual DbSet<TbTipoEstado> TbTipoEstados { get; set; }

    public virtual DbSet<TbTipoTabaco> TbTipoTabacos { get; set; }

    public virtual DbSet<TbTipoUsuario> TbTipoUsuarios { get; set; }

    public virtual DbSet<TbTiposCita> TbTiposCitas { get; set; }

    public virtual DbSet<TbTurnosMedico> TbTurnosMedicos { get; set; }

    public virtual DbSet<TbUniversidade> TbUniversidades { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<TbViasAdminitracion> TbViasAdminitracions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_spanish_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TbAntecedentesFamiliaresPatologico>(entity =>
        {
            entity.HasKey(e => e.IdAntecendenteFamp).HasName("PRIMARY");

            entity.ToTable("tb_antecedentes_familiares_patologicos");

            entity.Property(e => e.IdAntecendenteFamp).HasColumnName("Id_antecendente_famp");
            entity.Property(e => e.EnfHereditarias)
                .HasMaxLength(250)
                .HasColumnName("Enf_hereditarias");
            entity.Property(e => e.EnfInfectoContagiosas)
                .HasMaxLength(250)
                .HasColumnName("Enf_infecto_contagiosas");
        });

        modelBuilder.Entity<TbAntecedentesPersonalesNoPatologico>(entity =>
        {
            entity.HasKey(e => e.IdAntecedentePerNop).HasName("PRIMARY");

            entity.ToTable("tb_antecedentes_personales_no_patologicos");

            entity.Property(e => e.IdAntecedentePerNop).HasColumnName("Id_antecedente_per_nop");
            entity.Property(e => e.Alimentacion).HasMaxLength(250);
            entity.Property(e => e.HoraActFisica)
                .HasColumnType("time")
                .HasColumnName("Hora_act_fisica");
            entity.Property(e => e.HorasLaborales).HasColumnName("Horas_laborales");
            entity.Property(e => e.HorasSuenyo).HasColumnName("Horas_suenyo");
            entity.Property(e => e.InmunizacionCompleta).HasColumnName("Inmunizacion_completa");
            entity.Property(e => e.TipoActFisica)
                .HasMaxLength(250)
                .HasColumnName("Tipo_act_fisica");
        });

        modelBuilder.Entity<TbAntecedentesPersonalesPatologico>(entity =>
        {
            entity.HasKey(e => e.IdAntecendentePersonalP).HasName("PRIMARY");

            entity.ToTable("tb_antecedentes_personales_patologicos");

            entity.Property(e => e.IdAntecendentePersonalP).HasColumnName("Id_antecendente_personal_p");
            entity.Property(e => e.CirugiasPreviasRealizadas)
                .HasMaxLength(250)
                .HasColumnName("Cirugias_previas_realizadas");
            entity.Property(e => e.EnfCronicas)
                .HasMaxLength(250)
                .HasColumnName("Enf_cronicas");
            entity.Property(e => e.EnfInfectoContagiosas)
                .HasMaxLength(250)
                .HasColumnName("Enf_infecto_contagiosas");
        });

        modelBuilder.Entity<TbArchivo>(entity =>
        {
            entity.HasKey(e => e.ArchivoId).HasName("PRIMARY");

            entity.ToTable("tb_archivos");

            entity.Property(e => e.ArchivoId).HasColumnName("Archivo_id");
            entity.Property(e => e.Base64).HasColumnType("text");
            entity.Property(e => e.FechaSubida)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_subida");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(200)
                .HasColumnName("Nombre_archivo");
            entity.Property(e => e.TipoArchivo)
                .HasMaxLength(50)
                .HasColumnName("Tipo_archivo");
            entity.Property(e => e.TipoMime)
                .HasMaxLength(50)
                .HasColumnName("Tipo_mime");
        });

        modelBuilder.Entity<TbArchivosCitasLab>(entity =>
        {
            entity.HasKey(e => e.ArchivoCitasLabId).HasName("PRIMARY");

            entity.ToTable("tb_archivos_citas_lab");

            entity.HasIndex(e => e.ArchivoId, "Archivo_id");

            entity.HasIndex(e => e.CitaId, "Cita_id");

            entity.Property(e => e.ArchivoCitasLabId).HasColumnName("Archivo_citas_lab_id");
            entity.Property(e => e.ArchivoId).HasColumnName("Archivo_id");
            entity.Property(e => e.CitaId).HasColumnName("Cita_id");

            entity.HasOne(d => d.Archivo).WithMany(p => p.TbArchivosCitasLabs)
                .HasForeignKey(d => d.ArchivoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_archivos_citas_lab_ibfk_1");

            entity.HasOne(d => d.Cita).WithMany(p => p.TbArchivosCitasLabs)
                .HasForeignKey(d => d.CitaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_archivos_citas_lab_ibfk_2");
        });

        modelBuilder.Entity<TbArchivosCitasMedica>(entity =>
        {
            entity.HasKey(e => e.ArchivoCitasMedId).HasName("PRIMARY");

            entity.ToTable("tb_archivos_citas_medicas");

            entity.HasIndex(e => e.ArchivoId, "Archivo_id");

            entity.HasIndex(e => e.CitaId, "Cita_id");

            entity.Property(e => e.ArchivoCitasMedId).HasColumnName("Archivo_citas_med_id");
            entity.Property(e => e.ArchivoId).HasColumnName("Archivo_id");
            entity.Property(e => e.CitaId).HasColumnName("Cita_id");

            entity.HasOne(d => d.Archivo).WithMany(p => p.TbArchivosCitasMedicas)
                .HasForeignKey(d => d.ArchivoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_archivos_citas_medicas_ibfk_1");

            entity.HasOne(d => d.Cita).WithMany(p => p.TbArchivosCitasMedicas)
                .HasForeignKey(d => d.CitaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_archivos_citas_medicas_ibfk_2");
        });

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

            entity.HasIndex(e => e.MunicipioAlQuePertenece, "Municipio_al_que_pertenece");

            entity.Property(e => e.IdBarrio).HasColumnName("Id_barrio");
            entity.Property(e => e.Barrio).HasMaxLength(50);
            entity.Property(e => e.MunicipioAlQuePertenece).HasColumnName("Municipio_al_que_pertenece");

            entity.HasOne(d => d.MunicipioAlQuePerteneceNavigation).WithMany(p => p.TbBarrios)
                .HasForeignKey(d => d.MunicipioAlQuePertenece)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_barrios_ibfk_1");
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

        modelBuilder.Entity<TbCirugia>(entity =>
        {
            entity.HasKey(e => e.IdCirugias).HasName("PRIMARY");

            entity.ToTable("tb_cirugias");

            entity.Property(e => e.IdCirugias).HasColumnName("Id_cirugias");
            entity.Property(e => e.Cirugia).HasMaxLength(100);
        });

        modelBuilder.Entity<TbCita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PRIMARY");

            entity.ToTable("tb_citas");

            entity.HasIndex(e => e.Lugar, "Lugar");

            entity.HasIndex(e => e.PacienteId, "Paciente_id");

            entity.HasIndex(e => e.TipoCita, "Tipo_cita");

            entity.Property(e => e.IdCita).HasColumnName("Id_cita");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'pendiente'")
                .HasColumnType("enum('pendiente','aprobada','rechazada','reprogramada','cancelada')");
            entity.Property(e => e.FechaCita)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_cita");
            entity.Property(e => e.FechaSolicitud)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_solicitud");
            entity.Property(e => e.MotivoCita)
                .HasColumnType("text")
                .HasColumnName("Motivo_cita");
            entity.Property(e => e.MotivoRechazo)
                .HasColumnType("text")
                .HasColumnName("Motivo_rechazo");
            entity.Property(e => e.PacienteId).HasColumnName("Paciente_id");
            entity.Property(e => e.TipoCita).HasColumnName("Tipo_cita");

            entity.HasOne(d => d.LugarNavigation).WithMany(p => p.TbCita)
                .HasForeignKey(d => d.Lugar)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_citas_ibfk_3");

            entity.HasOne(d => d.Paciente).WithMany(p => p.TbCita)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_citas_ibfk_1");

            entity.HasOne(d => d.TipoCitaNavigation).WithMany(p => p.TbCita)
                .HasForeignKey(d => d.TipoCita)
                .HasConstraintName("tb_citas_ibfk_2");
        });

        modelBuilder.Entity<TbCitasLaboratorio>(entity =>
        {
            entity.HasKey(e => e.IdCitaLab).HasName("PRIMARY");

            entity.ToTable("tb_citas_laboratorio");

            entity.HasIndex(e => e.IdCita, "Id_cita");

            entity.Property(e => e.IdCitaLab).HasColumnName("Id_cita_lab");
            entity.Property(e => e.ExamenesRealizar)
                .HasMaxLength(250)
                .HasColumnName("Examenes_realizar");
            entity.Property(e => e.IdCita).HasColumnName("Id_cita");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.TbCitasLaboratorios)
                .HasForeignKey(d => d.IdCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_citas_laboratorio_ibfk_1");
        });

        modelBuilder.Entity<TbCitasMedica>(entity =>
        {
            entity.HasKey(e => e.IdCitaMedica).HasName("PRIMARY");

            entity.ToTable("tb_citas_medicas");

            entity.HasIndex(e => e.Especialidad, "Especialidad");

            entity.HasIndex(e => e.IdCita, "Id_cita");

            entity.HasIndex(e => e.MedicoId, "Medico_id");

            entity.Property(e => e.IdCitaMedica).HasColumnName("Id_cita_medica");
            entity.Property(e => e.IdCita).HasColumnName("Id_cita");
            entity.Property(e => e.MedicoId).HasColumnName("Medico_id");

            entity.HasOne(d => d.EspecialidadNavigation).WithMany(p => p.TbCitasMedicas)
                .HasForeignKey(d => d.Especialidad)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_citas_medicas_ibfk_3");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.TbCitasMedicas)
                .HasForeignKey(d => d.IdCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_citas_medicas_ibfk_1");

            entity.HasOne(d => d.Medico).WithMany(p => p.TbCitasMedicas)
                .HasForeignKey(d => d.MedicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_citas_medicas_ibfk_2");
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

        modelBuilder.Entity<TbDrogasLegale>(entity =>
        {
            entity.HasKey(e => e.IdDrogasLegales).HasName("PRIMARY");

            entity.ToTable("tb_drogas_legales");

            entity.Property(e => e.IdDrogasLegales).HasColumnName("Id_drogas_legales");
            entity.Property(e => e.CantidadUnidades).HasColumnName("Cantidad_unidades");
            entity.Property(e => e.DuracionAnyos).HasColumnName("Duracion_anyos");
            entity.Property(e => e.EdadAbandono).HasColumnName("Edad_abandono");
            entity.Property(e => e.EdadInicio).HasColumnName("Edad_inicio");
            entity.Property(e => e.Tipo).HasMaxLength(100);
        });

        modelBuilder.Entity<TbEnfermedadesCronica>(entity =>
        {
            entity.HasKey(e => e.IdEnfermedadCronica).HasName("PRIMARY");

            entity.ToTable("tb_enfermedades_cronicas");

            entity.Property(e => e.IdEnfermedadCronica).HasColumnName("Id_enfermedad_cronica");
            entity.Property(e => e.Enfermedad).HasMaxLength(100);
        });

        modelBuilder.Entity<TbEnfermedadesHereditaria>(entity =>
        {
            entity.HasKey(e => e.IdEnfermedad).HasName("PRIMARY");

            entity.ToTable("tb_enfermedades_hereditarias");

            entity.Property(e => e.IdEnfermedad).HasColumnName("Id_enfermedad");
            entity.Property(e => e.Enfermedad).HasMaxLength(100);
        });

        modelBuilder.Entity<TbEnfermedadesInfectoContagiosa>(entity =>
        {
            entity.HasKey(e => e.IdEnfermedad).HasName("PRIMARY");

            entity.ToTable("tb_enfermedades_infecto_contagiosas");

            entity.Property(e => e.IdEnfermedad).HasColumnName("Id_enfermedad");
            entity.Property(e => e.Enfermedad).HasMaxLength(100);
        });

        modelBuilder.Entity<TbEsAlcoholico>(entity =>
        {
            entity.HasKey(e => e.IdAlcoholico).HasName("PRIMARY");

            entity.ToTable("tb_es_alcoholico");

            entity.Property(e => e.IdAlcoholico).HasColumnName("Id_alcoholico");
            entity.Property(e => e.CantidadUnidades).HasColumnName("Cantidad_unidades");
            entity.Property(e => e.DuracionAnyos).HasColumnName("Duracion_anyos");
            entity.Property(e => e.EdadAbandono).HasColumnName("Edad_abandono");
            entity.Property(e => e.EdadInicio).HasColumnName("Edad_inicio");
            entity.Property(e => e.Tipo).HasMaxLength(100);
        });

        modelBuilder.Entity<TbEsFumador>(entity =>
        {
            entity.HasKey(e => e.IdFumador).HasName("PRIMARY");

            entity.ToTable("tb_es_fumador");

            entity.Property(e => e.IdFumador).HasColumnName("Id_fumador");
            entity.Property(e => e.CantidadUnidades).HasColumnName("Cantidad_unidades");
            entity.Property(e => e.DuracionAnyos).HasColumnName("Duracion_anyos");
            entity.Property(e => e.EdadAbandono).HasColumnName("Edad_abandono");
            entity.Property(e => e.EdadInicio).HasColumnName("Edad_inicio");
            entity.Property(e => e.Tipo).HasMaxLength(100);
        });

        modelBuilder.Entity<TbEscolaridad>(entity =>
        {
            entity.HasKey(e => e.IdEscolaridad).HasName("PRIMARY");

            entity.ToTable("tb_escolaridad");

            entity.Property(e => e.IdEscolaridad).HasColumnName("Id_escolaridad");
            entity.Property(e => e.Escolaridad).HasMaxLength(50);
        });

        modelBuilder.Entity<TbEspecialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PRIMARY");

            entity.ToTable("tb_especialidades");

            entity.Property(e => e.IdEspecialidad).HasColumnName("Id_especialidad");
            entity.Property(e => e.Especialidad).HasMaxLength(50);
        });

        modelBuilder.Entity<TbEstadoCivil>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCivil).HasName("PRIMARY");

            entity.ToTable("tb_estado_civil");

            entity.Property(e => e.IdEstadoCivil).HasColumnName("Id_estado_civil");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(50)
                .HasColumnName("Estado_civil");
        });

        modelBuilder.Entity<TbExamenesDisponiblesLab>(entity =>
        {
            entity.HasKey(e => e.IdExamen).HasName("PRIMARY");

            entity.ToTable("tb_examenes_disponibles_lab");

            entity.Property(e => e.IdExamen).HasColumnName("Id_examen");
            entity.Property(e => e.Examen).HasMaxLength(100);
        });

        modelBuilder.Entity<TbFarmacosActuale>(entity =>
        {
            entity.HasKey(e => e.IdFarmaco).HasName("PRIMARY");

            entity.ToTable("tb_farmacos_actuales");

            entity.HasIndex(e => e.PacienteId, "Paciente_id");

            entity.Property(e => e.IdFarmaco).HasColumnName("Id_farmaco");
            entity.Property(e => e.EstaEnUso)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("Esta_en_uso");
            entity.Property(e => e.NombreFarmaco)
                .HasMaxLength(50)
                .HasColumnName("Nombre_farmaco");
            entity.Property(e => e.PacienteId).HasColumnName("Paciente_id");
            entity.Property(e => e.PosologiaFarmaco)
                .HasMaxLength(100)
                .HasColumnName("Posologia_farmaco");

            entity.HasOne(d => d.Paciente).WithMany(p => p.TbFarmacosActuales)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_farmacos_actuales_ibfk_1");
        });

        modelBuilder.Entity<TbGenero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PRIMARY");

            entity.ToTable("tb_generos");

            entity.Property(e => e.IdGenero).HasColumnName("Id_genero");
            entity.Property(e => e.Genero).HasMaxLength(50);
        });

        modelBuilder.Entity<TbHistorialMedico>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PRIMARY");

            entity.ToTable("tb_historial_medico");

            entity.HasIndex(e => e.AntecedFamPatologicos, "Anteced_fam_patologicos");

            entity.HasIndex(e => e.AntecedPerNoPatologicos, "Anteced_per_no_patologicos");

            entity.HasIndex(e => e.DrogasLegales, "Drogas_legales");

            entity.HasIndex(e => e.EsAlcoholico, "Es_alcoholico");

            entity.HasIndex(e => e.EsFumador, "Es_fumador");

            entity.HasIndex(e => e.IdPaciente, "Id_paciente");

            entity.Property(e => e.IdHistorial).HasColumnName("Id_historial");
            entity.Property(e => e.AntecedFamPatologicos).HasColumnName("Anteced_fam_patologicos");
            entity.Property(e => e.AntecedPerNoPatologicos).HasColumnName("Anteced_per_no_patologicos");
            entity.Property(e => e.CantidadCitasHechas).HasColumnName("Cantidad_citas_hechas");
            entity.Property(e => e.DrogasLegales).HasColumnName("Drogas_legales");
            entity.Property(e => e.EsAlcoholico).HasColumnName("Es_alcoholico");
            entity.Property(e => e.EsFumador).HasColumnName("Es_fumador");
            entity.Property(e => e.IdDireccionHabitual).HasColumnName("Id_direccion_habitual");
            entity.Property(e => e.IdPaciente).HasColumnName("Id_paciente");
            entity.Property(e => e.OtrosHabitos)
                .HasMaxLength(250)
                .HasColumnName("Otros_habitos");

            entity.HasOne(d => d.AntecedFamPatologicosNavigation).WithMany(p => p.TbHistorialMedicos)
                .HasForeignKey(d => d.AntecedFamPatologicos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_historial_medico_ibfk_2");

            entity.HasOne(d => d.AntecedPerNoPatologicosNavigation).WithMany(p => p.TbHistorialMedicos)
                .HasForeignKey(d => d.AntecedPerNoPatologicos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_historial_medico_ibfk_3");

            entity.HasOne(d => d.DrogasLegalesNavigation).WithMany(p => p.TbHistorialMedicos)
                .HasForeignKey(d => d.DrogasLegales)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_historial_medico_ibfk_6");

            entity.HasOne(d => d.EsAlcoholicoNavigation).WithMany(p => p.TbHistorialMedicos)
                .HasForeignKey(d => d.EsAlcoholico)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_historial_medico_ibfk_5");

            entity.HasOne(d => d.EsFumadorNavigation).WithMany(p => p.TbHistorialMedicos)
                .HasForeignKey(d => d.EsFumador)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_historial_medico_ibfk_4");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TbHistorialMedicos)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_historial_medico_ibfk_1");
        });

        modelBuilder.Entity<TbHospitalizacione>(entity =>
        {
            entity.HasKey(e => e.IdHospitalizacion).HasName("PRIMARY");

            entity.ToTable("tb_hospitalizaciones");

            entity.HasIndex(e => e.PacienteId, "Paciente_id");

            entity.Property(e => e.IdHospitalizacion).HasColumnName("Id_hospitalizacion");
            entity.Property(e => e.Causa).HasColumnType("text");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.PacienteId).HasColumnName("Paciente_id");

            entity.HasOne(d => d.Paciente).WithMany(p => p.TbHospitalizaciones)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_hospitalizaciones_ibfk_1");
        });

        modelBuilder.Entity<TbMedicamentosRecetado>(entity =>
        {
            entity.HasKey(e => e.IdMedicamento).HasName("PRIMARY");

            entity.ToTable("tb_medicamentos_recetados");

            entity.HasIndex(e => e.IdResumenCita, "Id_resumen_cita");

            entity.HasIndex(e => e.ViaAdministracion, "Via_administracion");

            entity.Property(e => e.IdMedicamento).HasColumnName("Id_medicamento");
            entity.Property(e => e.Dosis).HasMaxLength(100);
            entity.Property(e => e.DuracionDias).HasColumnName("Duracion_dias");
            entity.Property(e => e.FrecuenciaHoras).HasColumnName("Frecuencia_horas");
            entity.Property(e => e.IdResumenCita).HasColumnName("Id_resumen_cita");
            entity.Property(e => e.Medicamento).HasMaxLength(200);
            entity.Property(e => e.ViaAdministracion).HasColumnName("Via_administracion");

            entity.HasOne(d => d.IdResumenCitaNavigation).WithMany(p => p.TbMedicamentosRecetados)
                .HasForeignKey(d => d.IdResumenCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_medicamentos_recetados_ibfk_1");

            entity.HasOne(d => d.ViaAdministracionNavigation).WithMany(p => p.TbMedicamentosRecetados)
                .HasForeignKey(d => d.ViaAdministracion)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_medicamentos_recetados_ibfk_2");
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

            entity.HasIndex(e => e.DepartamentoAlQuePertenece, "Departamento_al_que_pertenece");

            entity.Property(e => e.IdMunicipio).HasColumnName("Id_municipio");
            entity.Property(e => e.DepartamentoAlQuePertenece).HasColumnName("Departamento_al_que_pertenece");
            entity.Property(e => e.Municipio).HasMaxLength(50);

            entity.HasOne(d => d.DepartamentoAlQuePerteneceNavigation).WithMany(p => p.TbMunicipios)
                .HasForeignKey(d => d.DepartamentoAlQuePertenece)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_municipios_ibfk_1");
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

        modelBuilder.Entity<TbResumenCitaMedica>(entity =>
        {
            entity.HasKey(e => e.IdResumenCita).HasName("PRIMARY");

            entity.ToTable("tb_resumen_cita_medica");

            entity.HasIndex(e => e.IdCita, "Id_cita");

            entity.Property(e => e.IdResumenCita).HasColumnName("Id_resumen_cita");
            entity.Property(e => e.Diagnostico).HasColumnType("text");
            entity.Property(e => e.FrecuenciaCardiaca).HasColumnName("Frecuencia_cardiaca");
            entity.Property(e => e.FrecuenciaRespiratoria).HasColumnName("Frecuencia_respiratoria");
            entity.Property(e => e.IdCita).HasColumnName("Id_cita");
            entity.Property(e => e.PresionArterial)
                .HasMaxLength(50)
                .HasColumnName("Presion_arterial");
            entity.Property(e => e.TemperaturaCorporal).HasColumnName("Temperatura_corporal");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.TbResumenCitaMedicas)
                .HasForeignKey(d => d.IdCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_resumen_cita_medica_ibfk_1");
        });

        modelBuilder.Entity<TbStado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity.ToTable("tb_stados");

            entity.HasIndex(e => e.TipoEstado, "Tipo_estado");

            entity.Property(e => e.IdEstado).HasColumnName("Id_estado");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.TipoEstado).HasColumnName("Tipo_estado");

            entity.HasOne(d => d.TipoEstadoNavigation).WithMany(p => p.TbStados)
                .HasForeignKey(d => d.TipoEstado)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_stados_ibfk_1");
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

        modelBuilder.Entity<TbTipoActFisica>(entity =>
        {
            entity.HasKey(e => e.IdTipAct).HasName("PRIMARY");

            entity.ToTable("tb_tipo_act_fisica");

            entity.Property(e => e.IdTipAct).HasColumnName("Id_tip_act");
            entity.Property(e => e.Actividad).HasMaxLength(50);
        });

        modelBuilder.Entity<TbTipoEstado>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PRIMARY");

            entity.ToTable("tb_tipo_estado");

            entity.Property(e => e.IdTipo).HasColumnName("Id_tipo");
            entity.Property(e => e.Tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<TbTipoTabaco>(entity =>
        {
            entity.HasKey(e => e.IdTipoTabaco).HasName("PRIMARY");

            entity.ToTable("tb_tipo_tabaco");

            entity.Property(e => e.IdTipoTabaco).HasColumnName("Id_tipo_tabaco");
            entity.Property(e => e.Tipo).HasMaxLength(50);
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

        modelBuilder.Entity<TbTiposCita>(entity =>
        {
            entity.HasKey(e => e.IdTipoCita).HasName("PRIMARY");

            entity.ToTable("tb_tipos_citas");

            entity.Property(e => e.IdTipoCita).HasColumnName("Id_tipo_cita");
            entity.Property(e => e.Tipo).HasMaxLength(100);
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

            entity.HasIndex(e => e.Correo, "Correo").IsUnique();

            entity.HasIndex(e => e.Genero, "Genero");

            entity.HasIndex(e => e.TipoUsuario, "Tipo_usuario");

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

        modelBuilder.Entity<TbViasAdminitracion>(entity =>
        {
            entity.HasKey(e => e.IdViaAdm).HasName("PRIMARY");

            entity.ToTable("tb_vias_adminitracion");

            entity.Property(e => e.IdViaAdm).HasColumnName("Id_via_adm");
            entity.Property(e => e.ViaAdm)
                .HasMaxLength(100)
                .HasColumnName("Via_adm");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
