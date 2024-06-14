using System.ComponentModel.DataAnnotations;

namespace WebSTPM.Models
{
    public class Contest
    {
        public int ContestId { get; set; }

        public string ContestName { get; set; }
        public string Introduce { get; set; } 
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public ICollection<Team> Teams { get; set; }

    }
}
