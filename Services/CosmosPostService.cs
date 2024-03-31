using Cosmonaut;
using Microsoft.EntityFrameworkCore;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public class CosmosPostService : IPostService
    {
        private readonly ICosmosStore<CosmosPostDto> _cosmosStore;

        public CosmosPostService(ICosmosStore<CosmosPostDto> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<bool> CreatePostAsync(Post postToCreate)
        {
            var cosmosPost = new CosmosPostDto
            {
                Id = Guid.NewGuid().ToString(),
                Title = postToCreate.Title,
            };

            var res = await _cosmosStore.AddAsync(cosmosPost);
            postToCreate.Id = Guid.Parse(res.Entity.Id);
            return res.IsSuccess;
        }

        public async Task<bool> DeletePost(Guid postId)
        {
            var res = await _cosmosStore.RemoveByIdAsync(postId.ToString(), postId.ToString());
            return res.IsSuccess;
        }

        public async Task<Post?> GetPostByIdAsync(Guid postId)
        {
            var post = await _cosmosStore.FindAsync(postId.ToString(), postId.ToString());
            
            if(post == null)
                return null;

            return new Post { Id = Guid.Parse(post.Id), Title = post.Title };
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            var posts = _cosmosStore.Query().ToList();
            return posts.Select(x => new Post { Id = Guid.Parse(x.Id), Title = x.Title }).ToList();
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            var cosmosPost = new CosmosPostDto
            {
                Id = postToUpdate.Id.ToString(),
                Title = postToUpdate.Title,
            };

            var res = await _cosmosStore.UpdateAsync(cosmosPost);
            return res.IsSuccess;
        }
    }
}
