using System;
using System.Web.Mvc;
using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.View.Blog;
using HentovWebsite.Services.Services.Contracts;

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
        [Authorize(Roles = "Admin")]
        public ActionResult AddPost(AddPostBindingModel post)
        {
            if (ModelState.IsValid)
            {
                this.service.AddPost(post, User.Identity.Name);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Manage");
        }

        [HttpGet]
        public ActionResult Post(int id)
        {
            var post = this.service.GetPostById(id);
            return View(post);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(PostViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EditPostBindingModel model)
        {
            if (ModelState.IsValid)
            {
                this.service.UpdatePost(model);
                return RedirectToAction("Index");
            }
            var vm = this.service.GetViewModel(model);
            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(PostViewModel post)
        {
            return View(post);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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