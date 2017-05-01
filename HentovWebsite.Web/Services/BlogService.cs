﻿using System;
using System.Linq;
using AutoMapper;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.View.Blog;
using HentovWebsite.Web.Services.Contracts;

namespace HentovWebsite.Web.Services
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
    }
}