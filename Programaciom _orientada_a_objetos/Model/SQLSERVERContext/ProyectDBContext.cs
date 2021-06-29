using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Model.SQLSERVERContext
{
    public partial class ProyectDBContext : DbContext
    {
        public ProyectDBContext()
        {
        }

        public ProyectDBContext(DbContextOptions<ProyectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Arrival> Arrivals { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<CronicDesease> CronicDeseases { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<LoginTime> LoginTimes { get; set; }
        public virtual DbSet<PriorityGroup> PriorityGroups { get; set; }
        public virtual DbSet<TypeEmployee> TypeEmployees { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ProyectDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("Administrator");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.PasswordAdmin)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("passwordAdmin");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateAndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("dateAndTime");

                entity.Property(e => e.IdVaccination).HasColumnName("idVaccination");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Place)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("place");

                entity.HasOne(d => d.IdVaccinationNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdVaccination)
                    .HasConstraintName("FK__Appointme__idVac__5441852A");
            });

            modelBuilder.Entity<Arrival>(entity =>
            {
                entity.ToTable("Arrival");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdCabin).HasColumnName("idCabin");

                entity.Property(e => e.IdCitizen).HasColumnName("idCitizen");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.Arrivals)
                    .HasForeignKey(d => d.IdCabin)
                    .HasConstraintName("FK__Arrival__idCabin__4F7CD00D");

                entity.HasOne(d => d.IdCitizenNavigation)
                    .WithMany(p => p.Arrivals)
                    .HasForeignKey(d => d.IdCitizen)
                    .HasConstraintName("FK__Arrival__idCitiz__5070F446");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.ToTable("Cabin");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AddressCabin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("addressCabin");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("manager");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.Dui)
                    .HasName("PK__Citizen__D876F1BE27F3783F");

                entity.ToTable("Citizen");

                entity.Property(e => e.Dui)
                    .ValueGeneratedNever()
                    .HasColumnName("dui");

                entity.Property(e => e.AddressCitizen)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("addressCitizen");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdAppointment).HasColumnName("idAppointment");

                entity.Property(e => e.IdInstitution).HasColumnName("idInstitution");

                entity.Property(e => e.IdPriorityGroup).HasColumnName("idPriorityGroup");

                entity.Property(e => e.NameCitizen)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nameCitizen");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.IdAppointmentNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdAppointment)
                    .HasConstraintName("FK__Citizen__idAppoi__534D60F1");

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdInstitution)
                    .HasConstraintName("FK__Citizen__idInsti__52593CB8");

                entity.HasOne(d => d.IdPriorityGroupNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdPriorityGroup)
                    .HasConstraintName("FK__Citizen__idPrior__5165187F");
            });

            modelBuilder.Entity<CronicDesease>(entity =>
            {
                entity.ToTable("CronicDesease");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CronicDesease1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cronicDesease");

                entity.Property(e => e.IdCitizen).HasColumnName("idCitizen");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AddressEmployee)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("addressEmployee");

                entity.Property(e => e.IdAdministrator).HasColumnName("idAdministrator");

                entity.Property(e => e.IdTypeEmployee).HasColumnName("idTypeEmployee");

                entity.Property(e => e.InstitutionalEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("institutionalEmail");

                entity.Property(e => e.NameEmployee)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nameEmployee");

                entity.HasOne(d => d.IdAdministratorNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdAdministrator)
                    .HasConstraintName("FK__Employee__idAdmi__4CA06362");

                entity.HasOne(d => d.IdTypeEmployeeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdTypeEmployee)
                    .HasConstraintName("FK__Employee__idType__4BAC3F29");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("Institution");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Institution1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("institution");
            });

            modelBuilder.Entity<LoginTime>(entity =>
            {
                entity.ToTable("LoginTime");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateTimeLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("dateTimeLogin");

                entity.Property(e => e.IdAdministrator).HasColumnName("idAdministrator");

                entity.Property(e => e.IdCabin).HasColumnName("idCabin");

                entity.HasOne(d => d.IdAdministratorNavigation)
                    .WithMany(p => p.LoginTimes)
                    .HasForeignKey(d => d.IdAdministrator)
                    .HasConstraintName("FK__LoginTime__idAdm__4D94879B");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.LoginTimes)
                    .HasForeignKey(d => d.IdCabin)
                    .HasConstraintName("FK__LoginTime__idCab__4E88ABD4");
            });

            modelBuilder.Entity<PriorityGroup>(entity =>
            {
                entity.ToTable("PriorityGroup");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.PriorityGroup1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("priorityGroup");
            });

            modelBuilder.Entity<TypeEmployee>(entity =>
            {
                entity.ToTable("TypeEmployee");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.TypeEmployee1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("typeEmployee");
            });

            modelBuilder.Entity<Vaccination>(entity =>
            {
                entity.ToTable("Vaccination");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ArrivalTime)
                    .HasColumnType("datetime")
                    .HasColumnName("arrivalTime");

                entity.Property(e => e.SecondaryEffect)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("secondaryEffect");

                entity.Property(e => e.TimeEffect).HasColumnName("timeEffect");

                entity.Property(e => e.VaccinationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("vaccinationTime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
