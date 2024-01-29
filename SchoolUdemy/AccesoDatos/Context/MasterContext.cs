using System;
using System.Collections.Generic;
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Context;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Nota> Notas { get; set; }

    public virtual DbSet<TblCargo> TblCargos { get; set; }

    public virtual DbSet<TblCompetencium> TblCompetencia { get; set; }

    public virtual DbSet<TblDepartamento> TblDepartamentos { get; set; }

    public virtual DbSet<TblEmpleado> TblEmpleados { get; set; }

    public virtual DbSet<TblEvaluacion> TblEvaluacions { get; set; }

    public virtual DbSet<TblEvaluacionDetalle> TblEvaluacionDetalles { get; set; }

    public virtual DbSet<TblEvaluador> TblEvaluadors { get; set; }

    public virtual DbSet<TblPeriodo> TblPeriodos { get; set; }

    public virtual DbSet<TblSubCompetencium> TblSubCompetencia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CARLOS_ESC; Trust Server Certificate=true; User id=udemy; Password=123456789; MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.Idnota);

            entity.ToTable("notas");

            entity.Property(e => e.Idnota).HasColumnName("idnota");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .HasColumnName("titulo");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
        });

        modelBuilder.Entity<TblCargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo)
                .HasName("PK_tblCargo_IdCargo")
                .IsClustered(false);

            entity.ToTable("tblCargo");

            entity.HasIndex(e => e.Cargo, "UQ__tblCargo__68A1C0DFD480F1EC").IsUnique();

            entity.Property(e => e.IdCargo).ValueGeneratedOnAdd();
            entity.Property(e => e.Cargo)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCompetencium>(entity =>
        {
            entity.HasKey(e => e.IdCompetencia)
                .HasName("PK_tblCompetencia_IdCompetencia")
                .IsClustered(false);

            entity.ToTable("tblCompetencia");

            entity.HasIndex(e => e.Competencia, "UQ__tblCompe__3A7C20534C861BA7").IsUnique();

            entity.Property(e => e.IdCompetencia).ValueGeneratedOnAdd();
            entity.Property(e => e.Competencia)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblDepartamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento)
                .HasName("PK_tblDepartamento_IdDepartamento")
                .IsClustered(false);

            entity.ToTable("tblDepartamento");

            entity.HasIndex(e => e.Departamento, "UQ__tblDepar__71BEBBD74268F8BC").IsUnique();

            entity.Property(e => e.IdDepartamento).ValueGeneratedOnAdd();
            entity.Property(e => e.Departamento)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado)
                .HasName("PK_tblEmpleado_IdEmpleado")
                .IsClustered(false);

            entity.ToTable("tblEmpleado");

            entity.HasIndex(e => e.Nseguro, "UQ__tblEmple__2EEA011B2FB1F1AE").IsUnique();

            entity.Property(e => e.Empleado)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Nseguro)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.TblEmpleados)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEmpleado_IdCargo");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.TblEmpleados)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEmpleado_IdDepartamento");
        });

        modelBuilder.Entity<TblEvaluacion>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacion)
                .HasName("PK_tblEvaluacion_IdEvaluacion")
                .IsClustered(false);

            entity.ToTable("tblEvaluacion");

            entity.Property(e => e.Fortalezas)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Oportunidades)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Recomendaciones)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.TblEvaluacions)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEvaluacion_IdEmpleado");

            entity.HasOne(d => d.IdEvaluadorNavigation).WithMany(p => p.TblEvaluacions)
                .HasForeignKey(d => d.IdEvaluador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEvaluacion_IdEvaluador");

            entity.HasOne(d => d.IdPeriodoNavigation).WithMany(p => p.TblEvaluacions)
                .HasForeignKey(d => d.IdPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEvaluacion_IdPeriodo");
        });

        modelBuilder.Entity<TblEvaluacionDetalle>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacionD)
                .HasName("PK_tblEvaluacion_Detalle_IdEvaluacionD")
                .IsClustered(false);

            entity.ToTable("tblEvaluacion_Detalle");

            entity.HasOne(d => d.IdEvaluacionNavigation).WithMany(p => p.TblEvaluacionDetalles)
                .HasForeignKey(d => d.IdEvaluacion)
                .HasConstraintName("FK_tblEvaluacion_Detalle_IdEvaluacion");

            entity.HasOne(d => d.IdSubCompetenciaNavigation).WithMany(p => p.TblEvaluacionDetalles)
                .HasForeignKey(d => d.IdSubCompetencia)
                .HasConstraintName("FK_tblEvaluacion_Detalle_IdSubCompetencia");
        });

        modelBuilder.Entity<TblEvaluador>(entity =>
        {
            entity.HasKey(e => e.IdEvaluador)
                .HasName("PK_tblEvaluador_IdEvaluador")
                .IsClustered(false);

            entity.ToTable("tblEvaluador");

            entity.HasIndex(e => e.Evaluador, "UQ__tblEvalu__3B27D20FD59812F5").IsUnique();

            entity.Property(e => e.IdEvaluador).ValueGeneratedOnAdd();
            entity.Property(e => e.Evaluador)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblPeriodo>(entity =>
        {
            entity.HasKey(e => e.IdPeriodo)
                .HasName("PK_tblPeriodo_IdPeriodo")
                .IsClustered(false);

            entity.ToTable("tblPeriodo");

            entity.HasIndex(e => e.Periodo, "UQ__tblPerio__7CFB65B3CA5A7608").IsUnique();

            entity.Property(e => e.IdPeriodo).ValueGeneratedOnAdd();
            entity.Property(e => e.Periodo)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSubCompetencium>(entity =>
        {
            entity.HasKey(e => e.IdSubCompetencia)
                .HasName("PK_tblSubCompetencia_IdSubCompetencia")
                .IsClustered(false);

            entity.ToTable("tblSubCompetencia");

            entity.Property(e => e.IdSubCompetencia).ValueGeneratedOnAdd();
            entity.Property(e => e.SubCompetencia)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCompetenciaNavigation).WithMany(p => p.TblSubCompetencia)
                .HasForeignKey(d => d.IdCompetencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblSubCompetencia_IdCompetencia");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.EsAdmin).HasColumnName("es_admin");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
