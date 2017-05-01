using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.View.Blog;

namespace HentovWebsite.Web.Services.Contracts
{
    public interface IBlogService : IService
    {
        void AddPost(AddPostBindingModel post, string name);
        PostCollectionViewModel GetBlogPosts();
    }
}
