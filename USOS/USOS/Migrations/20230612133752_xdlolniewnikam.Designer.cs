﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using USOS.Entities;

#nullable disable

namespace USOS.Migrations
{
    [DbContext(typeof(UsosDbContext))]
    [Migration("20230612133752_xdlolniewnikam")]
    partial class xdlolniewnikam
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("USOS.Entities.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("USOS.Entities.Lecturer", b =>
                {
                    b.Property<int>("LecturerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LecturerID"));

                    b.Property<string>("AcademicTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("LecturerID");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("USOS.Entities.LecturerSubject", b =>
                {
                    b.Property<int>("LecturerID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("LecturerID", "SubjectID");

                    b.HasIndex("SubjectID");

                    b.ToTable("LecturerSubjects");
                });

            modelBuilder.Entity("USOS.Entities.MajorSubject", b =>
                {
                    b.Property<int>("MajorSubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MajorSubjectID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDesc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MajorSubjectID");

                    b.ToTable("MajorSubjects");
                });

            modelBuilder.Entity("USOS.Entities.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int>("MajorSubjectID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("StudentID");

                    b.HasIndex("MajorSubjectID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("USOS.Entities.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("ShortDesc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("USOS.Entities.SubjectMajorSubject", b =>
                {
                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int>("MajorSubjectID")
                        .HasColumnType("int");

                    b.HasKey("SubjectID", "MajorSubjectID");

                    b.HasIndex("MajorSubjectID");

                    b.ToTable("SubjectMajorSubjects");
                });

            modelBuilder.Entity("USOS.Entities.LecturerSubject", b =>
                {
                    b.HasOne("USOS.Entities.Lecturer", "Lecturer")
                        .WithMany("LecturerSubject")
                        .HasForeignKey("LecturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("USOS.Entities.Subject", "Subject")
                        .WithMany("LecturerSubject")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("USOS.Entities.Student", b =>
                {
                    b.HasOne("USOS.Entities.MajorSubject", "majorSubject")
                        .WithMany("Students")
                        .HasForeignKey("MajorSubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("majorSubject");
                });

            modelBuilder.Entity("USOS.Entities.SubjectMajorSubject", b =>
                {
                    b.HasOne("USOS.Entities.MajorSubject", "MajorSubject")
                        .WithMany("SubjectMajorSubject")
                        .HasForeignKey("MajorSubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("USOS.Entities.Subject", "Subject")
                        .WithMany("SubjectMajorSubject")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MajorSubject");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("USOS.Entities.Lecturer", b =>
                {
                    b.Navigation("LecturerSubject");
                });

            modelBuilder.Entity("USOS.Entities.MajorSubject", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("SubjectMajorSubject");
                });

            modelBuilder.Entity("USOS.Entities.Subject", b =>
                {
                    b.Navigation("LecturerSubject");

                    b.Navigation("SubjectMajorSubject");
                });
#pragma warning restore 612, 618
        }
    }
}
