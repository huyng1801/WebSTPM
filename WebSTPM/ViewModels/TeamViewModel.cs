using System.ComponentModel.DataAnnotations;

namespace WebSTPM.ViewModels
{
    public class TeamViewModel
    {
        public int TeamID { get; set; }

        [Required]
        [Display(Name = "Thành viên đội")]
        public string TeamMember { get; set; }

        [Required]
        [Display(Name = "Tên dự án")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Tên lớp")]
        public string ClassName { get; set; }

        [Required]
        [Display(Name = "Tên giảng viên hướng dẫn")]
        public string InstructorName { get; set; }

        [Required]
        [Display(Name = "Mô tả dự án")]
        public string Description { get; set; }

        public int ContestId { get; set; }
    }
}
