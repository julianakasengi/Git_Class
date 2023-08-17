﻿// <auto-generated />
using System;
using DBModules.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFDatabase.Migrations
{
    [DbContext(typeof(EFTestDbContext))]
    partial class EFTestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DBModules.SQL.Models.School", b =>
                {
                    b.Property<Guid>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("SchoolId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Stream", b =>
                {
                    b.Property<Guid>("StreamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("char(36)");

                    b.Property<string>("StreamName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StreamID");

                    b.HasIndex("SchoolId");

                    b.ToTable("Streams", (string)null);
                });

            modelBuilder.Entity("DBModules.SQL.Models.Student", b =>
                {
                    b.Property<Guid>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("char(36)");

                    b.HasKey("StudentID");

                    b.HasIndex("SchoolId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("DBModules.SQL.Models.StudentSubjectJoin", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("char(36)");

                    b.HasKey("SubjectId", "StudentID")
                        .HasName("Pk_Joined");

                    b.HasIndex("StudentID");

                    b.ToTable("StudentSubjectJoin");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("SubjectId");

                    b.HasIndex("SchoolId");

                    b.HasIndex("StudentID");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("DBModules.SQL.Models.Teacher", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TscNumber")
                        .HasColumnType("int");

                    b.HasKey("TeacherId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("DBModules.SQL.Models.Stream", b =>
                {
                    b.HasOne("DBModules.SQL.Models.School", "School")
                        .WithMany("Streams")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Student", b =>
                {
                    b.HasOne("DBModules.SQL.Models.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("DBModules.SQL.Models.StudentSubjectJoin", b =>
                {
                    b.HasOne("DBModules.SQL.Models.Student", "Student")
                        .WithMany("Subjects")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModules.SQL.Models.Subject", "Subject")
                        .WithMany("Students")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Subject", b =>
                {
                    b.HasOne("DBModules.SQL.Models.School", "School")
                        .WithMany("Subjects")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModules.SQL.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModules.SQL.Models.Teacher", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Teacher", b =>
                {
                    b.HasOne("DBModules.SQL.Models.School", "School")
                        .WithMany("Teachers")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("DBModules.SQL.Models.School", b =>
                {
                    b.Navigation("Streams");

                    b.Navigation("Students");

                    b.Navigation("Subjects");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Student", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Subject", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("DBModules.SQL.Models.Teacher", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}