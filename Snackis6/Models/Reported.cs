using Snackis6.Areas.Identity.Data;

namespace Snackis6.Models
{
    public class Reported
    {
        public int Id { get; set; }
        public string Reason { get; set; }

        public DateTime TimeStamp { get; set; }
       
        public string ReporterId { get; set; }
        public Snackis6User? Reporter { get; set; }
       
        public string ReportedUserId { get; set; }
        public Snackis6User? ReportedUser { get; set; }

    
        //public int PostId { get; set; }
        //public Post? Post { get; set; }

        public int CommentId { get; set; }
        public Comment? Comment { get; set; }
    }
}
