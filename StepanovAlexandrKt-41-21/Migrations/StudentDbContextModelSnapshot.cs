﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StepanovAlexandrKt_41_21.Database;

#nullable disable

namespace StepanovAlexandrKt_41_21.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StepanovAlexandrKt_41_21.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("group_id")
                        .HasComment("Идентификатор записи группы");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_group_name")
                        .HasComment("Название группы");

                    b.HasKey("GroupId")
                        .HasName("pk_cd_group_group_id");

                    b.ToTable("cd_group", (string)null);
                });

            modelBuilder.Entity("StepanovAlexandrKt_41_21.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("student_id")
                        .HasComment("Идентификатор записи студента");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_firstname")
                        .HasComment("Имя студента");

                    b.Property<int>("GroupId")
                        .HasColumnType("int4")
                        .HasColumnName("f_group_id")
                        .HasComment("Идентификатор группы");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_lastname")
                        .HasComment("Фамилия студента");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_middlename")
                        .HasComment("Отчество студента");

                    b.HasKey("StudentId")
                        .HasName("pk_cd_student_student_id");

                    b.HasIndex(new[] { "GroupId" }, "idx_cd_student_fk_f_group_id");

                    b.ToTable("cd_student", (string)null);
                });

            modelBuilder.Entity("StepanovAlexandrKt_41_21.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subject_id")
                        .HasComment("Идентификатор записи предмета");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_subject_name")
                        .HasComment("Название предмета");

                    b.HasKey("SubjectId")
                        .HasName("pk_cd_subject_subject_id");

                    b.ToTable("cd_subject", (string)null);
                });

            modelBuilder.Entity("StepanovAlexandrKt_41_21.Models.Student", b =>
                {
                    b.HasOne("StepanovAlexandrKt_41_21.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_group_id");

                    b.Navigation("Group");
                });
#pragma warning restore 612, 618
        }
    }
}
