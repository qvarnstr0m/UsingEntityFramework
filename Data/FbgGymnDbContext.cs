using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UsingEntityFramework.Models;

namespace UsingEntityFramework.Data;

public partial class FbgGymnDbContext : DbContext
{
    public FbgGymnDbContext()
    {
    }

    public FbgGymnDbContext(DbContextOptions<FbgGymnDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CoursesStudent> CoursesStudents { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffDepartment> StaffDepartments { get; set; }

    public virtual DbSet<Staffrole> Staffroles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<VwCourseGradesStatistic> VwCourseGradesStatistics { get; set; }

    public virtual DbSet<VwLastMonthGrade> VwLastMonthGrades { get; set; }

    public virtual DbSet<VwStaffDatum> VwStaffData { get; set; }

    public virtual DbSet<VwStaffRoleMonthlySalary> VwStaffRoleMonthlySalaries { get; set; }

    public virtual DbSet<VwStudentsClass> VwStudentsClasses { get; set; }

    public virtual DbSet<VwTotalMonthlySalary> VwTotalMonthlySalaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = THINKPAD; Initial Catalog=FalkenbergsGymnasieskola;Integrated Security = True; TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adress>(entity =>
        {
            entity.HasKey(e => e.AdressId).HasName("PK__Adresses__C37631FB2D157ACB");

            entity.Property(e => e.AdressId).HasColumnName("Adress_id");
            entity.Property(e => e.AdressCity)
                .HasMaxLength(50)
                .HasColumnName("Adress_city");
            entity.Property(e => e.AdressPostalcode).HasColumnName("Adress_postalcode");
            entity.Property(e => e.AdressStreet)
                .HasMaxLength(50)
                .HasColumnName("Adress_street");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__B096396F0488F563");

            entity.Property(e => e.ClassId).HasColumnName("Class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .HasColumnName("Class_name");
            entity.Property(e => e.ClassStartdate)
                .HasColumnType("date")
                .HasColumnName("Class_startdate");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__37E309C32E7A7AB3");

            entity.Property(e => e.CourseId).HasColumnName("Course_id");
            entity.Property(e => e.CourseEnddate)
                .HasColumnType("date")
                .HasColumnName("Course_enddate");
            entity.Property(e => e.CourseName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Course_name");
            entity.Property(e => e.CourseStartdate)
                .HasColumnType("date")
                .HasColumnName("Course_startdate");
            entity.Property(e => e.FkStaffId).HasColumnName("FK_Staff_id");

            entity.HasOne(d => d.FkStaff).WithMany(p => p.Courses)
                .HasForeignKey(d => d.FkStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Courses__FK_Staf__31EC6D26");
        });

        modelBuilder.Entity<CoursesStudent>(entity =>
        {
            entity.HasKey(e => e.CoursesStudentsId).HasName("PK__CoursesS__C246012F922DD03E");

            entity.HasIndex(e => new { e.FkCourseId, e.FkStudentId }, "UQ__CoursesS__7EDDF3402ED573E9").IsUnique();

            entity.Property(e => e.CoursesStudentsId).HasColumnName("CoursesStudents_id");
            entity.Property(e => e.FkCourseId).HasColumnName("FK_Course_id");
            entity.Property(e => e.FkStudentId).HasColumnName("FK_Student_id");

            entity.HasOne(d => d.FkCourse).WithMany(p => p.CoursesStudents)
                .HasForeignKey(d => d.FkCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CoursesSt__FK_Co__32E0915F");

            entity.HasOne(d => d.FkStudent).WithMany(p => p.CoursesStudents)
                .HasForeignKey(d => d.FkStudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CoursesSt__FK_St__35BCFE0A");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__151571C9AD0FD8EF");

            entity.Property(e => e.DepartmentId).HasColumnName("Department_id");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .HasColumnName("Department_name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__D44275EB31B6E9C3");

            entity.HasIndex(e => new { e.FkStudentId, e.FkCourseId }, "UQ__Grades__D36212A27BB50C49").IsUnique();

            entity.Property(e => e.GradeId).HasColumnName("Grade_id");
            entity.Property(e => e.FkCourseId).HasColumnName("FK_Course_id");
            entity.Property(e => e.FkStaffId).HasColumnName("FK_Staff_id");
            entity.Property(e => e.FkStudentId).HasColumnName("FK_Student_id");
            entity.Property(e => e.GradeDate)
                .HasColumnType("date")
                .HasColumnName("Grade_date");
            entity.Property(e => e.GradeGrade)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Grade_grade");

            entity.HasOne(d => d.FkCourse).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FkCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__FK_Cours__06CD04F7");

            entity.HasOne(d => d.FkStaff).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FkStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__FK_Staff__76969D2E");

            entity.HasOne(d => d.FkStudent).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FkStudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__FK_Stude__75A278F5");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__32D2E85BA9B5418D");

            entity.HasIndex(e => e.StaffPersonalnumber, "UQ__Staff__E0851F6AD64ADC81").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("Staff_id");
            entity.Property(e => e.FkAdressId).HasColumnName("FK_Adress_id");
            entity.Property(e => e.FkStaffroleId).HasColumnName("FK_Staffrole_id");
            entity.Property(e => e.StaffCellphone)
                .HasMaxLength(50)
                .HasColumnName("Staff_cellphone");
            entity.Property(e => e.StaffEmail)
                .HasMaxLength(50)
                .HasColumnName("Staff_email");
            entity.Property(e => e.StaffEnddate)
                .HasColumnType("date")
                .HasColumnName("Staff_enddate");
            entity.Property(e => e.StaffFirstname)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Staff_firstname");
            entity.Property(e => e.StaffLastname)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Staff_lastname");
            entity.Property(e => e.StaffMonthlySalary)
                .HasColumnType("money")
                .HasColumnName("Staff_monthly_salary");
            entity.Property(e => e.StaffPersonalnumber)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Staff_personalnumber");
            entity.Property(e => e.StaffStartdate)
                .HasColumnType("date")
                .HasColumnName("Staff_startdate");

            entity.HasOne(d => d.FkAdress).WithMany(p => p.Staff)
                .HasForeignKey(d => d.FkAdressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Staff__FK_Adress__3E52440B");

            entity.HasOne(d => d.FkStaffrole).WithMany(p => p.Staff)
                .HasForeignKey(d => d.FkStaffroleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Staff__FK_Staffr__3D5E1FD2");
        });

        modelBuilder.Entity<StaffDepartment>(entity =>
        {
            entity.HasKey(e => e.StaffDepartmentsId).HasName("PK__StaffDep__67D125E1424AE092");

            entity.HasIndex(e => new { e.FkStaffId, e.FkDepartmentId }, "UQ__StaffDep__E433F3830A60A37A").IsUnique();

            entity.Property(e => e.StaffDepartmentsId).HasColumnName("StaffDepartments_id");
            entity.Property(e => e.FkDepartmentId).HasColumnName("FK_Department_id");
            entity.Property(e => e.FkStaffId).HasColumnName("FK_Staff_id");

            entity.HasOne(d => d.FkDepartment).WithMany(p => p.StaffDepartments)
                .HasForeignKey(d => d.FkDepartmentId)
                .HasConstraintName("FK__StaffDepa__FK_De__1F98B2C1");

            entity.HasOne(d => d.FkStaff).WithMany(p => p.StaffDepartments)
                .HasForeignKey(d => d.FkStaffId)
                .HasConstraintName("FK__StaffDepa__FK_St__1DB06A4F");
        });

        modelBuilder.Entity<Staffrole>(entity =>
        {
            entity.HasKey(e => e.StaffroleId).HasName("PK__Staffrol__71E19F03F33A47BB");

            entity.Property(e => e.StaffroleId).HasColumnName("Staffrole_id");
            entity.Property(e => e.StaffroleName)
                .HasMaxLength(50)
                .HasColumnName("Staffrole_name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__F04C9B60D283F645");

            entity.HasIndex(e => e.StudentPersonalnumber, "UQ__Students__F075CA3350A9D16B").IsUnique();

            entity.Property(e => e.StudentId).HasColumnName("Student_id");
            entity.Property(e => e.FkAdressId).HasColumnName("FK_Adress_id");
            entity.Property(e => e.FkClassId).HasColumnName("FK_Class_id");
            entity.Property(e => e.StudentCellphone)
                .HasMaxLength(50)
                .HasColumnName("Student_cellphone");
            entity.Property(e => e.StudentEmail)
                .HasMaxLength(50)
                .HasColumnName("Student_email");
            entity.Property(e => e.StudentFirstname)
                .HasMaxLength(50)
                .HasColumnName("Student_firstname");
            entity.Property(e => e.StudentLastname)
                .HasMaxLength(50)
                .HasColumnName("Student_lastname");
            entity.Property(e => e.StudentPersonalnumber)
                .HasMaxLength(50)
                .HasColumnName("Student_personalnumber");

            entity.HasOne(d => d.FkAdress).WithMany(p => p.Students)
                .HasForeignKey(d => d.FkAdressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__FK_Adr__398D8EEE");

            entity.HasOne(d => d.FkClass).WithMany(p => p.Students)
                .HasForeignKey(d => d.FkClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__FK_Cla__36B12243");
        });

        modelBuilder.Entity<VwCourseGradesStatistic>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CourseGradesStatistics");

            entity.Property(e => e.BästaBetyg)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Bästa betyg");
            entity.Property(e => e.CourseId).HasColumnName("Course_id");
            entity.Property(e => e.CourseName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Course_name");
            entity.Property(e => e.Medelbetyg)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.SämstaBetyg)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Sämsta betyg");
        });

        modelBuilder.Entity<VwLastMonthGrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_LastMonthGrades");

            entity.Property(e => e.Betyg)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Betygsättare)
                .IsRequired()
                .HasMaxLength(101);
            entity.Property(e => e.Kurs)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Namn).HasMaxLength(101);
        });

        modelBuilder.Entity<VwStaffDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StaffData");

            entity.Property(e => e.Namn)
                .IsRequired()
                .HasMaxLength(101);
            entity.Property(e => e.Roll).HasMaxLength(50);
            entity.Property(e => e.ÅrPåSkolan).HasColumnName("År på skolan");
        });

        modelBuilder.Entity<VwStaffRoleMonthlySalary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StaffRoleMonthlySalary");

            entity.Property(e => e.Avdelning).HasMaxLength(50);
            entity.Property(e => e.GenomsnittligLön)
                .HasColumnType("money")
                .HasColumnName("Genomsnittlig lön");
        });

        modelBuilder.Entity<VwStudentsClass>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StudentsClasses");

            entity.Property(e => e.Klass).HasMaxLength(50);
            entity.Property(e => e.Namn).HasMaxLength(101);
        });

        modelBuilder.Entity<VwTotalMonthlySalary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_TotalMonthlySalary");

            entity.Property(e => e.Avdelning).HasMaxLength(50);
            entity.Property(e => e.TotalaLöneutbetalningar)
                .HasColumnType("money")
                .HasColumnName("Totala löneutbetalningar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
