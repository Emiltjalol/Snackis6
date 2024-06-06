using Snackis6.Areas.Identity.Data;

namespace Snackis6.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }

        public string userId { get; set; }
        public Snackis6User? User { get; set; }

        public int postId { get; set; }
        public Post? Post { get; set; }

        public int categoryId { get; set; }
        public Category? Category { get; set; }

        public int subCategoryId { get; set; }
        public Subcategory? SubCategory { get; set; }
        
    }
}
