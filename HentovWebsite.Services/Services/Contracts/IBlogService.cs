using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.View.Blog;

namespace HentovWebsite.Services.Services.Contracts
{
    public interface IBlogService : IService
    {
        void AddPost(AddPostBindingModel post, string name);

        PostCollectionViewModel GetBlogPosts();

        PostViewModel GetPostById(int id);

        void UpdatePost(EditPostBindingModel model);

        void DeletePost(int postId);

        PostViewModel GetViewModel(EditPostBindingModel model);
        PostViewModel GetViewModel(AddPostBindingModel model);

        void LikePost(int id, string userId, bool authorized);

        int GetPostLikes(int id);
        void Dislike(int postId, string userId, bool authorized);
    }
}
