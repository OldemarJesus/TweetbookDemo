using Microsoft.EntityFrameworkCore;
using Tweetbook.Data;
using Tweetbook.Domain;
using static Tweetbook.Contracts.v1.ApiRoutes;

namespace Tweetbook.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        async public Task<List<Post>> GetPostsAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        async public Task<Post?> GetPostByIdAsync(Guid postId)
        {
            return await _dataContext.Posts.FirstOrDefaultAsync(i => i.Id == postId);
        }

        async public Task<bool> CreatePostAsync(Post postToCreate)
        {
            await _dataContext.Posts.AddAsync(postToCreate);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        async public Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            _dataContext.Posts.Update(postToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        async public Task<bool> DeletePost(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);

            if(post == null)
            {
                return false;
            }

            _dataContext.Posts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
