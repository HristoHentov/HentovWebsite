using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.View.Blog;

namespace HentovWebsite.Web.Services.Contracts
{
    public interface IBlogService : IService
    {
        void AddPost(AddPostBindingModel post, string name);
        PostCollectionViewModel GetBlogPosts();
        PostViewModel GetPostById(int id);
        void UpdatePost(EditPostBindingModel model);
        void DeletePost(int postId);
        PostViewModel GetViewModel(EditPostBindingModel model);
    }
}
