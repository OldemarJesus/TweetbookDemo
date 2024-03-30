using System.ComponentModel.DataAnnotations;

namespace Tweetbook.Domain
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
