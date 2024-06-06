using Microsoft.AspNetCore.Identity;
using Snackis6.Areas.Identity.Data;

namespace Snackis6.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime PostedTime { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }

        public Subcategory? subCategory { get; set; }
        public int SubCategoryId { get; set; }


        public string UserId { get; set; }
        public Snackis6User? User { get; set; }


    }
}
