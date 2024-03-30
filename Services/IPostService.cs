using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public interface IPostService
    {
        public Task<List<Post>> GetPostsAsync();
        public Task<Post?> GetPostByIdAsync(Guid postId);
        public Task<bool> CreatePostAsync(Post postToCreate);
        public Task<bool> UpdatePostAsync(Post postToUpdate);
        public Task<bool> DeletePost(Guid postId);
    }
}
