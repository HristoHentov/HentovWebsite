﻿using System;
using System.Linq;
using AutoMapper;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.View.Blog;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;

namespace HentovWebsite.Services.Services
{
    public class BlogService : IBlogService
    {
        protected IUnitOfWork Context { get; }

        public BlogService(IUnitOfWork uow)
        {
            this.Context = uow;
        }
        public void AddPost(AddPostBindingModel post, string name)
        {
            var postToAdd = Mapper.Map<AddPostBindingModel, PostEntityModel>(post);
            postToAdd.DatePosted = DateTime.Now;
            postToAdd.AuthorName = name;
            this.Context.Posts.Add(postToAdd);
            this.Context.SaveChanges();
        }

        public PostCollectionViewModel GetBlogPosts()
        {
            var postsResult = new PostCollectionViewModel();
            var posts = this.Context.Posts.Entities.OrderByDescending(p => p.DatePosted).ToList();

            foreach (var post in posts)
            {
                postsResult.Posts.Add(Mapper.Map<PostEntityModel, PostViewModel>(post));
            }

            return postsResult;
        }

        public PostViewModel GetPostById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException(Consts.InvlidIdError);
            }
            var post = this.Context.Posts.FirstOrDefault(p => p.Id == id);
            return Mapper.Map<PostEntityModel, PostViewModel>(post);
        }

        public void UpdatePost(EditPostBindingModel model)
        {
            if (model.Id < 0)
                throw new ArgumentException(Consts.InvlidIdError);

            var postToEdit = this.Context.Posts.FirstOrDefault(m => m.Id == model.Id);
            postToEdit.Title = model.Title;
            postToEdit.Content = model.Content;
            postToEdit.DateEdited = DateTime.Now;
            this.Context.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            this.Context.Posts.Remove(postId);
            this.Context.SaveChanges();
        }

        public PostViewModel GetViewModel(EditPostBindingModel model)
        {
            return Mapper.Map<EditPostBindingModel, PostViewModel>(model);
        }

        public PostViewModel GetViewModel(AddPostBindingModel model)
        {
            return Mapper.Map<AddPostBindingModel, PostViewModel>(model);

        }

        public void LikePost(int postId, string userId, bool authorized)
        {
            if (authorized)
            {
                var post = this.Context.Posts.Find(postId);
                var user = this.Context.WebsiteUsers.FirstOrDefault(u => u.IdentityUser.Id == userId);

                bool hasPosts = post.UsersWhoLiked.Contains(user);
                if (!hasPosts)
                {
                    post.UsersWhoLiked.Add(user);
                    user.LikedPosts.Add(post);
                    this.Context.SaveChanges();
                }

            }
        }

        public int GetPostLikes(int id)
        {
            return this.Context.Posts.Find(id).UsersWhoLiked.Count;
        }

        public void Dislike(int postId, string userId, bool authorized)
        {
            if (authorized)
            {
                var post = this.Context.Posts.Find(postId);
                var user = this.Context.WebsiteUsers.FirstOrDefault(u => u.IdentityUser.Id == userId);

                bool userHasLiked = post.UsersWhoLiked.Contains(user);
                if (userHasLiked)
                {
                    post.UsersWhoLiked.Remove(user);
                    user.LikedPosts.Remove(post);
                }

                this.Context.SaveChanges();
            }
        }
    }
}
