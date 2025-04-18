﻿// <auto-generated />
using KonstantinovMihailKt_31_22.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KonstantinovMihailKt_31_22.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20250418094514_temp")]
    partial class temp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KonstantinovMihailKt_31_22.Models.Cafedra", b =>
                {
                    b.Property<int>("CafedraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cafedra_id")
                        .HasComment("Id Кафедры");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CafedraId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int")
                        .HasColumnName("c_admin_id")
                        .HasComment("Идентификатор администратора(заведующего) кафедры");

                    b.Property<string>("CafedraName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("cafedra_name")
                        .HasComment("Название кафедры");

                    b.Property<byte[]>("dataosnovania")
                        .IsRequired()
                        .HasColumnType("timestamp")
                        .HasColumnName("date_Osnovania")
                        .HasComment("Дата основания");

                    b.HasKey("CafedraId")
                        .HasName("pk_cd_cafedra_cafedra_id");

                    b.HasIndex("AdminId")
                        .IsUnique();

                    b.HasIndex(new[] { "CafedraId" }, "idx_cd_cafedra_fk_admin_id_prepod_id");

                    b.ToTable("cd_cafedra", (string)null);
                });

            modelBuilder.Entity("KonstantinovMihailKt_31_22.Models.Degrees", b =>
                {
                    b.Property<int>("DegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Degree_id")
                        .HasComment("Id Степени");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DegreeId"));

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("Degree_name")
                        .HasComment("Название степени");

                    b.HasKey("DegreeId")
                        .HasName("pk_cd_degree_degree_id");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("KonstantinovMihailKt_31_22.Models.Disciplines", b =>
                {
                    b.Property<int>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Disciplines_id")
                        .HasComment("Id дисциплины");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisciplineId"));

                    b.Property<string>("DisciplineName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("Disciplines_name")
                        .HasComment("Название дисциплины");

                    b.HasKey("DisciplineId")
                        .HasName("pk_cd_discipline_disciplines_id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("KonstantinovMihailKt_31_22.Models.Nagruzka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("para_id")
                        .HasComment("Идентификатор занятия");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int")
                        .HasColumnName("c_discipline_id")
                        .HasComment("Идентификатор предмета");

                    b.Property<int>("PrepodId")
                        .HasColumnType("int")
                        .HasColumnName("c_prepod_id")
                        .HasComment("Идентификатор преподавателя");

                    b.Property<int>("totalHours")
                        .HasColumnType("int")
                        .HasColumnName("c_nagruzka_hours")
                        .HasComment("Нагрузка в часах");

                    b.HasKey("Id")
                        .HasName("pk_cd_Nagruzka_Id");

                    b.HasIndex(new[] { "PrepodId" }, "idx_cd_Nagruzka_fk_prepod_id");

                    b.HasIndex(new[] { "DisciplineId" }, "idx_cd_Nagruzka_fk_subject_id");

                    b.ToTable("cd_Nagruzka", (string)null);
                });

            modelBuilder.Entity("KonstantinovMihailKt_31_22.Models.Positions", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_position")
                        .HasComment("Айдишник должности");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionId"));

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("positionName")
                        .HasComment("Название должности");

                    b.HasKey("PositionId")
                        .HasName("pk_Positions_posinion_id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("KonstantinovMihailKt_31_22.Models.Prepods", b =>
                {
                    b.Property<int>("IdPrepod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_prepod")
                        .HasComment("Айдишник преподавателей");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrepod"));

                    b.Property<int>("CafedraId")
                        .HasColumnType("int")
                        .HasColumnName("prepod_cafedraId")
                        .HasComment("Кафедра преподавателя");

                    b.Property<int>("DegreeId")
                        .HasColumnType("int")
                        .HasColumnName("prepod_digreeId")
                        .HasComment("Степень преподавателя");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("prepod_firstname")
                        .HasComment("Имя преподавателя");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("prepod_lastname")
                        .HasComment("Отчество преподавателя");

                    b.Property<string>("MidName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("prepod_midname")
                        .HasComment("Фамилия преподавателя");

                    b.Property<int>("PositionId")
                        .HasColumnType("int")
                        .HasColumnName("prepod_positionId")
                        .HasComment("Должность преподавателя");

                    b.HasKey("IdPrepod")
                        .HasName("pk_Prepods_prepods_id");

                    b.HasIndex(new[] { "CafedraId" }, "idx_Prepods_fk_cafedra_id");

                    b.HasIndex(new[] { "DegreeId" }, "idx_Prepods_fk_degree_id");

                    b.HasIndex(new[] { "PositionId" }, "idx_Prepods_fk_position_id");

                    b.ToTable("Prepods", (string)null);
                });

            modelBuilder.Entity("KonstantinovMihailKt_31_22.Models.Cafedra", b =>
                {
                    b.HasOne("KonstantinovMihailKt_31_22.Models.Prepods", "Admin")
                        .WithOne()
                        .HasForeignKey("KonstantinovMihailKt_31_22.Models.Cafedra", "AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_admin_id_prepod_id");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("KonstantinovMihailKt_31_22.Models.Nagruzka", b =>
                {
                    b.HasOne("KonstantinovMihailKt_31_22.Models.Disciplines", "Disciplines")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_discipline_id");

                    b.HasOne("KonstantinovMihailKt_31_22.Models.Prepods", "Prepod")
                        .WithMany()
                        .HasForeignKey("PrepodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_prepod_id");

                    b.Navigation("Disciplines");

                    b.Navigation("Prepod");
                });

            modelBuilder.Entity("KonstantinovMihailKt_31_22.Models.Prepods", b =>
                {
                    b.HasOne("KonstantinovMihailKt_31_22.Models.Cafedra", "Cafedra")
                        .WithMany()
                        .HasForeignKey("CafedraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_cafedra_id");

                    b.HasOne("KonstantinovMihailKt_31_22.Models.Degrees", "Degrees")
                        .WithMany()
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_degree_id");

                    b.HasOne("KonstantinovMihailKt_31_22.Models.Positions", "Positions")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_position_id");

                    b.Navigation("Cafedra");

                    b.Navigation("Degrees");

                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
