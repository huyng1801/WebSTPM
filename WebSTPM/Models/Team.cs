using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSTPM.Models
{
    public class Team
    {
        public int TeamID { get; set; }

        public string TeamMember { get; set; }

        public string ProjectName { get; set; }
        public string ClassName { get; set; }
        public string InstructorName { get; set; } 

       
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public AwardType? Award { get; set; }

        public bool IsApproved { get; set; } = false;
        public int ContestId { get; set; }

        public Contest Contest { get; set; }
    }

    public enum AwardType
    {
        Nhat,
        Nhi,
        Ba,
        KhuyenKhich
    }
}
