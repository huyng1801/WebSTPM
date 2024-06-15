using System.ComponentModel.DataAnnotations;

namespace WebSTPM.ViewModels
{
    public class ContestViewModel
    {
        public int ContestId { get; set; }

        [Required]
        [Display(Name = "Tên cuộc thi")]
        public string ContestName { get; set; }

        [Display(Name = "Giới thiệu")]
        public string Introduce { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Ngày bắt đầu")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Ngày kết thúc")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
