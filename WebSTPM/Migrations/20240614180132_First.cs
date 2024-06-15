using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebSTPM.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    AdminUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.AdminUserId);
                });

            migrationBuilder.CreateTable(
                name: "Contests",
                columns: table => new
                {
                    ContestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContestName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Introduce = table.Column<string>(type: "ntext", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contests", x => x.ContestId);
                });

            migrationBuilder.CreateTable(
                name: "NewsEvents",
                columns: table => new
                {
                    NewsEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsEvents", x => x.NewsEventID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamMember = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstructorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Award = table.Column<int>(type: "int", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ContestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "ContestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdminUsers",
                columns: new[] { "AdminUserId", "CreatedAt", "Password", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(5892), "admin123", true, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(5893), "admin" },
                    { 2, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(5896), "employee123", false, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(5896), "instructor" }
                });

            migrationBuilder.InsertData(
                table: "Contests",
                columns: new[] { "ContestId", "ContestName", "CreatedAt", "Description", "EndDate", "Introduce", "StartDate", "UpdatedAt" },
                values: new object[] { 1, "Hội thi Sáng tạo phần mềm 2024", new DateTime(2024, 6, 15, 1, 1, 32, 345, DateTimeKind.Local).AddTicks(9150), "Cuộc thi dành cho sinh viên yêu thích lập trình", new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về Hội thi Sáng tạo Phần mềm 2024.", new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 15, 1, 1, 32, 345, DateTimeKind.Local).AddTicks(9150) });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "Award", "ClassName", "ContestId", "CreatedAt", "Description", "InstructorName", "IsApproved", "ProjectName", "TeamMember", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "ĐHCNTT21A", 1, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2049), "Website bán sách", "Cô Linh", true, "Website bán sách", "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ", new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2049) },
                    { 2, null, "ĐHCNTT21A", 1, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2052), "Website bán rượu vang", "Cô Linh", true, "Website bán rượu vang", "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ", new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2052) },
                    { 3, null, "ĐHCNTT22A", 1, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2055), "Website quản lý hồ sơ viên chức và kế khai giảng dạy", "Thầy Quốc Anh", true, "Website quản lý hồ sơ viên chức và kế khai giảng dạy", "Nguyễn Tuấn Thanh, Đào Thanh Hào", new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2055) },
                    { 4, null, "ĐHCNTT21A", 1, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2058), "Phần mềm mobile Cookguide", "Thầy Quốc Anh", true, "Phần mềm mobile Cookguide", "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ", new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2059) },
                    { 5, null, "ĐHCNTT21B", 1, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2061), "Website cho hội thi sáng tạo phần mềm", "Cô Uyên Minh", true, "Website cho hội thi sáng tạo phần mềm", "Nguyễn Tấn Huy", new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2061) },
                    { 6, null, "ĐHCNTT21B", 1, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2064), "Xây dựng phần mềm quản lý shop giày dép", "Cô Hương", true, "Xây dựng phần mềm quản lý shop giày dép", "Trần Duy Đăng", new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2064) },
                    { 7, null, "ĐHCNTT22B", 1, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2067), "Phần mềm quản lý tiến độ học tập của sinh viên", "Cô Thư", true, "Phần mềm quản lý tiến độ học tập của sinh viên", "Nguyễn Minh Thức, Lê Thị Kim Yến, Ngô Trung Thái, Huỳnh Thị Thu Thảo, Đào Huỳnh Hưng", new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2067) },
                    { 8, null, "ĐHCNTT20B", 1, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2070), "Xây dựng ứng dụng quản lý trang thiết bị bệnh viện tâm thần cao lãnh", "Cô Linh", true, "Xây dựng ứng dụng quản lý trang thiết bị bệnh viện tâm thần cao lãnh", "Nguyễn Minh Tiến, Phạm Trường Trinh, Bùi Văn Đăng Khoa, Đinh Quang Khang", new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2070) },
                    { 9, null, "ĐHCNTT21A", 1, new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2073), "Website đánh giá kết quả rèn luyện sinh viên trường Đại học Đồng Tháp", "Cô Hương", true, "Website đánh giá kết quả rèn luyện sinh viên trường Đại học Đồng Tháp", "Trần Đăng Khoa, Nguyễn Hữu Vĩnh, Nguyễn Thành Danh, Lê Hoàng Thiện Mỹ", new DateTime(2024, 6, 15, 1, 1, 32, 346, DateTimeKind.Local).AddTicks(2073) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ContestId",
                table: "Teams",
                column: "ContestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "NewsEvents");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Contests");
        }
    }
}
