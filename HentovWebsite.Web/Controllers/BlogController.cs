using System;
using System.Web.Mvc;
using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.View.Blog;
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

        [HttpGet]
        public ActionResult Edit(PostViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditPostBindingModel model)
        {
            try
            {
                this.service.UpdatePost(model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

            }
            return View(model); ///Automap this to PostViewModel
        }

        [HttpGet]
        public ActionResult Delete(PostViewModel post)
        {
            return View(post);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                this.service.DeletePost(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
               throw new InvalidOperationException("Failed to delete post");
            }


        }
    }
}