﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSTPM.Models;

#nullable disable

namespace WebSTPM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebSTPM.Models.AdminUser", b =>
                {
                    b.Property<int>("AdminUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminUserId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Role")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AdminUserId");

                    b.ToTable("AdminUsers");

                    b.HasData(
                        new
                        {
                            AdminUserId = 1,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(5892),
                            Password = "admin123",
                            Role = true,
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(5893),
                            Username = "admin"
                        },
                        new
                        {
                            AdminUserId = 2,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(5896),
                            Password = "employee123",
                            Role = false,
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(5896),
                            Username = "instructor"
                        });
                });

            modelBuilder.Entity("WebSTPM.Models.Contest", b =>
                {
                    b.Property<int>("ContestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContestId"));

                    b.Property<string>("ContestName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Introduce")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("ContestId");

                    b.ToTable("Contests");

                    b.HasData(
                        new
                        {
                            ContestId = 1,
                            ContestName = "Hội thi Sáng tạo phần mềm 2024",
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 345, DateTimeKind.Local).AddTicks(9150),
                            Description = "Cuộc thi dành cho sinh viên yêu thích lập trình",
                            EndDate = new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Introduce = "Giới thiệu về Hội thi Sáng tạo Phần mềm 2024.",
                            StartDate = new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 345, DateTimeKind.Local).AddTicks(9150)
                        });
                });

            modelBuilder.Entity("WebSTPM.Models.NewsEvent", b =>
                {
                    b.Property<int>("NewsEventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsEventID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("Views")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("NewsEventID");

                    b.ToTable("NewsEvents");
                });

            modelBuilder.Entity("WebSTPM.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"));

                    b.Property<int?>("Award")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ContestId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsApproved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TeamMember")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("TeamID");

                    b.HasIndex("ContestId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            ClassName = "ĐHCNTT21A",
                            ContestId = 1,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2049),
                            Description = "Website bán sách",
                            InstructorName = "Cô Linh",
                            IsApproved = true,
                            ProjectName = "Website bán sách",
                            TeamMember = "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ",
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2049)
                        },
                        new
                        {
                            TeamID = 2,
                            ClassName = "ĐHCNTT21A",
                            ContestId = 1,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2052),
                            Description = "Website bán rượu vang",
                            InstructorName = "Cô Linh",
                            IsApproved = true,
                            ProjectName = "Website bán rượu vang",
                            TeamMember = "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ",
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2052)
                        },
                        new
                        {
                            TeamID = 3,
                            ClassName = "ĐHCNTT22A",
                            ContestId = 1,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2055),
                            Description = "Website quản lý hồ sơ viên chức và kế khai giảng dạy",
                            InstructorName = "Thầy Quốc Anh",
                            IsApproved = true,
                            ProjectName = "Website quản lý hồ sơ viên chức và kế khai giảng dạy",
                            TeamMember = "Nguyễn Tuấn Thanh, Đào Thanh Hào",
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2055)
                        },
                        new
                        {
                            TeamID = 4,
                            ClassName = "ĐHCNTT21A",
                            ContestId = 1,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2058),
                            Description = "Phần mềm mobile Cookguide",
                            InstructorName = "Thầy Quốc Anh",
                            IsApproved = true,
                            ProjectName = "Phần mềm mobile Cookguide",
                            TeamMember = "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ",
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2059)
                        },
                        new
                        {
                            TeamID = 5,
                            ClassName = "ĐHCNTT21B",
                            ContestId = 1,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2061),
                            Description = "Website cho hội thi sáng tạo phần mềm",
                            InstructorName = "Cô Uyên Minh",
                            IsApproved = true,
                            ProjectName = "Website cho hội thi sáng tạo phần mềm",
                            TeamMember = "Nguyễn Tấn Huy",
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2061)
                        },
                        new
                        {
                            TeamID = 6,
                            ClassName = "ĐHCNTT21B",
                            ContestId = 1,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2064),
                            Description = "Xây dựng phần mềm quản lý shop giày dép",
                            InstructorName = "Cô Hương",
                            IsApproved = true,
                            ProjectName = "Xây dựng phần mềm quản lý shop giày dép",
                            TeamMember = "Trần Duy Đăng",
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2064)
                        },
                        new
                        {
                            TeamID = 7,
                            ClassName = "ĐHCNTT22B",
                            ContestId = 1,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2067),
                            Description = "Phần mềm quản lý tiến độ học tập của sinh viên",
                            InstructorName = "Cô Thư",
                            IsApproved = true,
                            ProjectName = "Phần mềm quản lý tiến độ học tập của sinh viên",
                            TeamMember = "Nguyễn Minh Thức, Lê Thị Kim Yến, Ngô Trung Thái, Huỳnh Thị Thu Thảo, Đào Huỳnh Hưng",
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2067)
                        },
                        new
                        {
                            TeamID = 8,
                            ClassName = "ĐHCNTT20B",
                            ContestId = 1,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2070),
                            Description = "Xây dựng ứng dụng quản lý trang thiết bị bệnh viện tâm thần cao lãnh",
                            InstructorName = "Cô Linh",
                            IsApproved = true,
                            ProjectName = "Xây dựng ứng dụng quản lý trang thiết bị bệnh viện tâm thần cao lãnh",
                            TeamMember = "Nguyễn Minh Tiến, Phạm Trường Trinh, Bùi Văn Đăng Khoa, Đinh Quang Khang",
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2070)
                        },
                        new
                        {
                            TeamID = 9,
                            ClassName = "ĐHCNTT21A",
                            ContestId = 1,
                            CreatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2073),
                            Description = "Website đánh giá kết quả rèn luyện sinh viên trường Đại học Đồng Tháp",
                            InstructorName = "Cô Hương",
                            IsApproved = true,
                            ProjectName = "Website đánh giá kết quả rèn luyện sinh viên trường Đại học Đồng Tháp",
                            TeamMember = "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ",
                            UpdatedAt = new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2073)
                        });
                });

            modelBuilder.Entity("WebSTPM.Models.Team", b =>
                {
                    b.HasOne("WebSTPM.Models.Contest", "Contest")
                        .WithMany("Teams")
                        .HasForeignKey("ContestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contest");
                });

            modelBuilder.Entity("WebSTPM.Models.Contest", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
