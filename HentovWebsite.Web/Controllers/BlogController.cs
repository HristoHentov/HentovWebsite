using System.Web.Mvc;
using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Web.Services;
using HentovWebsite.Web.Services.Contracts;

namespace HentovWebsite.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService service;
        public BlogController(IBlogService blogService)
        {
            this.service = blogService;
        }
        // GET: Blog
        public ActionResult Index()
        {
            var posts = service.GetBlogPosts();
            return View(posts);
        }

        [HttpPost]
        public ActionResult AddPost(AddPostBindingModel post)
        {
            this.service.AddPost(post, User.Identity.Name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Post(int id)
        {
            var post = this.service.GetPostById(id);
            return View(post);
        }
    }
}