using Snackis6.Areas.Identity.Data;

namespace Snackis6.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public Snackis6User? Sender { get; set; }
        public string RecipientId { get; set; }
        public Snackis6User? Recipient { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
