using Microsoft.EntityFrameworkCore;
using System;

namespace WebSTPM.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<NewsEvent> NewsEvents { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contest>(entity =>
            {
                entity.HasKey(e => e.ContestId);
                entity.Property(e => e.ContestId).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.ContestName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Introduce).HasColumnType("ntext");
                entity.Property(e => e.Description).HasColumnType("ntext");
                entity.Property(e => e.StartDate).IsRequired().HasColumnType("date");
                entity.Property(e => e.EndDate).IsRequired().HasColumnType("date");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("GETDATE()");

                entity.HasData(
                       new Contest
                       {
                           ContestId = 1,
                           ContestName = "Hội thi Sáng tạo phần mềm 2024",
                           Description = "Cuộc thi dành cho sinh viên yêu thích lập trình",
                           Introduce = "Giới thiệu về Hội thi Sáng tạo Phần mềm 2024.",
                           StartDate = new DateTime(2024, 6, 17),
                           EndDate = new DateTime(2024, 6, 17),
                           CreatedAt = DateTime.Now,
                           UpdatedAt = DateTime.Now
                       }
                  
                   );
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamID);
                entity.Property(e => e.TeamID).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.TeamMember).IsRequired().HasMaxLength(200);
                entity.Property(e => e.ProjectName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasColumnType("ntext");
                entity.Property(e => e.InstructorName).HasMaxLength(100);
                entity.Property(e => e.ClassName).HasMaxLength(100);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.IsApproved).IsRequired().HasDefaultValue(false);

                entity.HasOne(e => e.Contest)
                      .WithMany(c => c.Teams)
                      .HasForeignKey(e => e.ContestId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Seeding data
                entity.HasData(
                    new Team
                    {
                        TeamID = 1,
                        TeamMember = "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ",
                        ProjectName = "Website bán sách",
                        Description = "Website bán sách",
                        InstructorName = "Cô Linh",
                        ClassName = "ĐHCNTT21A",
                        ContestId = 1,
                        IsApproved = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Team
                    {
                        TeamID = 2,
                        TeamMember = "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ",
                        ProjectName = "Website bán rượu vang",
                        Description = "Website bán rượu vang",
                        InstructorName = "Cô Linh",
                        ClassName = "ĐHCNTT21A",
                        ContestId = 1,
                        IsApproved = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Team
                    {
                        TeamID = 3,
                        TeamMember = "Nguyễn Tuấn Thanh, Đào Thanh Hào",
                        ProjectName = "Website quản lý hồ sơ viên chức và kế khai giảng dạy",
                        Description = "Website quản lý hồ sơ viên chức và kế khai giảng dạy",
                        InstructorName = "Thầy Quốc Anh",
                        ClassName = "ĐHCNTT22A",
                        ContestId = 1,
                        IsApproved = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Team
                    {
                        TeamID = 4,
                        TeamMember = "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ",
                        ProjectName = "Phần mềm mobile Cookguide",
                        Description = "Phần mềm mobile Cookguide",
                        InstructorName = "Thầy Quốc Anh",
                        ClassName = "ĐHCNTT21A",
                        ContestId = 1,
                        IsApproved = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Team
                    {
                        TeamID = 5,
                        TeamMember = "Nguyễn Tấn Huy",
                        ProjectName = "Website cho hội thi sáng tạo phần mềm",
                        Description = "Website cho hội thi sáng tạo phần mềm",
                        InstructorName = "Cô Uyên Minh",
                        ClassName = "ĐHCNTT21B",
                        ContestId = 1,
                        IsApproved = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Team
                    {
                        TeamID = 6,
                        TeamMember = "Trần Duy Đăng",
                        ProjectName = "Xây dựng phần mềm quản lý shop giày dép",
                        Description = "Xây dựng phần mềm quản lý shop giày dép",
                        InstructorName = "Cô Hương",
                        ClassName = "ĐHCNTT21B",
                        ContestId = 1,
                        IsApproved = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Team
                    {
                        TeamID = 7,
                        TeamMember = "Nguyễn Minh Thức, Lê Thị Kim Yến, Ngô Trung Thái, Huỳnh Thị Thu Thảo, Đào Huỳnh Hưng",
                        ProjectName = "Phần mềm quản lý tiến độ học tập của sinh viên",
                        Description = "Phần mềm quản lý tiến độ học tập của sinh viên",
                        InstructorName = "Cô Thư",
                        ClassName = "ĐHCNTT22B",
                        ContestId = 1,
                        IsApproved = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Team
                    {
                        TeamID = 8,
                        TeamMember = "Nguyễn Minh Tiến, Phạm Trường Trinh, Bùi Văn Đăng Khoa, Đinh Quang Khang",
                        ProjectName = "Xây dựng ứng dụng quản lý trang thiết bị bệnh viện tâm thần cao lãnh",
                        Description = "Xây dựng ứng dụng quản lý trang thiết bị bệnh viện tâm thần cao lãnh",
                        InstructorName = "Cô Linh",
                        ClassName = "ĐHCNTT20B",
                        ContestId = 1,
                        IsApproved = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Team
                    {
                        TeamID = 9,
                        TeamMember = "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ",
                        ProjectName = "Website đánh giá kết quả rèn luyện sinh viên trường Đại học Đồng Tháp",
                        Description = "Website đánh giá kết quả rèn luyện sinh viên trường Đại học Đồng Tháp",
                        InstructorName = "Cô Hương",
                        ClassName = "ĐHCNTT21A",
                        ContestId = 1,
                        IsApproved = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                );
            });


            modelBuilder.Entity<NewsEvent>(entity =>
            {
                entity.HasKey(e => e.NewsEventID);
                entity.Property(e => e.NewsEventID).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Content).HasColumnType("ntext");
                entity.Property(e => e.ImageUrl).HasMaxLength(200);
                entity.Property(e => e.Views).HasDefaultValue(0);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("GETDATE()");

              
          
            });

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasKey(e => e.AdminUserId);
                entity.Property(e => e.AdminUserId).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Role).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("GETDATE()");

                entity.HasData(
                    new AdminUser
                    {
                        AdminUserId = 1,
                        Username = "admin",
                        Password = "admin123", 
                        Role = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new AdminUser
                    {
                        AdminUserId = 2,
                        Username = "instructor",
                        Password = "employee123", 
                        Role = false, 
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                );
            });
        }
    }
}
