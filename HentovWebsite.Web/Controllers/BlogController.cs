using System;
using System.Web.Mvc;
using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.View.Blog;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;

namespace HentovWebsite.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService service;
        public BlogController(IBlogService blogService)
        {
            this.service = blogService;
        }
        
        public ActionResult Index()
        {
            var posts = service.GetBlogPosts();
            return View(posts);
        }
        [Authorize(Roles = "Admin, Moderator, WebsiteUser")]
        public ActionResult LikePost(int postId, string userId, bool authorized)
        {
            if (authorized)
            {
                this.service.LikePost(postId, userId, authorized);
                var likes = this.service.GetPostLikes(postId).ToString();
                return Content(likes);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult DislikePost(int postId, string userId, bool authorized)
        {
            if (authorized)
            {
                this.service.Dislike(postId, userId, authorized);
                var likes = this.service.GetPostLikes(postId).ToString();
                return Content(likes);
            }
            return RedirectToAction("Login", "Account");
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
               throw new InvalidOperationException(Consts.DeletePostError);
            }
        }
    }
}