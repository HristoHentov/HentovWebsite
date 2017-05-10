using System;
using System.Web.Mvc;
using System.Web.UI;
using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.View.Blog;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;

namespace HentovWebsite.Web.Controllers
{
    [RoutePrefix("Blog")]
    public class BlogController : Controller
    {
        private readonly IBlogService service;
        public BlogController(IBlogService blogService)
        {
            this.service = blogService;
        }

        [HttpGet]
        [Route("Index")]
        [OutputCache(Duration = 30, Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var posts = service.GetBlogPosts();
            return View(posts);
        }

        [Route("LikePost")]
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

        [Route("DislikePost")]
        [Authorize(Roles = "Admin, Moderator, WebsiteUser")]
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
        [Route("AddPost")]
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
        [Route("Post")]
        [OutputCache(Duration = 30, Location = OutputCacheLocation.Client)]
        public ActionResult Post(int id)
        {
            var post = this.service.GetPostById(id);
            return View(post);
        }

        [HttpGet]
        [Route("Edit")]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(PostViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        [Route("Edit")]
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
        [Route("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(PostViewModel post)
        {
            return View(post);
        }

        [HttpPost]
        [Route("Delete")]
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