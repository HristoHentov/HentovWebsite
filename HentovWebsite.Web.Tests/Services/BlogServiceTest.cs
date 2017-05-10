using System;
using AutoMapper;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.Binding.Portfolio;
using HentovWebsite.Models.Binding.Tutorials;
using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.Entity.Portfolio;
using HentovWebsite.Models.Entity.Tutorials;
using HentovWebsite.Models.Enums;
using HentovWebsite.Models.View.Blog;
using HentovWebsite.Models.View.Portfolio;
using HentovWebsite.Models.View.Tutorials;
using HentovWebsite.Services.Services;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HentovWebsite.Web.Tests.Services
{
    [TestClass]
    public class BlogServiceTest
    {

        private readonly IUnitOfWork uow;
        private readonly IBlogService service;

        public BlogServiceTest()
        {
            this.uow = new FakeUnitOfWork();
            this.service = new BlogService(uow);
            InitializeMappings();
        }

        [TestInitialize]
        public void Setup()
        {
            this.uow.Posts.Add(new PostEntityModel()
            {
                Id = 1,
                Title = "Nikolay's life",
                AuthorName = "Nikolay",
                Content = "Hello world this is nikolay"
            });
            this.uow.Posts.Add(new PostEntityModel()
            {
                Id = 2,
                Title = "Boris's life",
                AuthorName = "Boris",
                Content = "Hello world this is Boris"
            });
            this.uow.Posts.Add(new PostEntityModel()
            {
                Id = 3,
                Title = "Kondio's life",
                AuthorName = "Kondio",
                Content = "Hello world this is Kondio"
            });
        }


        [TestMethod]
        public void AddPost_CorrectlyAddsPostInDb()
        {
            this.service.AddPost(new AddPostBindingModel()
            {
                Title = "TestPost",
                Content = "TestContet",
            }, "Ivan");

            var result = this.uow.Posts.FirstOrDefault(x => x.Title == "TestPost");

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetBlogPosts_CorrectlyReturnsAllPosts()
        {
            var result = this.service.GetBlogPosts();
            Assert.AreEqual(result.Posts.Count, 3);
        }

        [TestMethod]
        public void GetBlogPost_ReturnsCorrectPost()
        {
            var result = this.service.GetPostById(2);
            Assert.AreEqual(result.Id, 2);
            Assert.AreEqual(result.AuthorName, "Boris");
            Assert.AreEqual(result.Title, "Boris's life");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBlogPost_ThrowsExceptionOnInvalidId()
        {
            var result = this.service.GetPostById(-2);
        }

        [TestMethod]
        public void UpdatePost_UpdatesCorrectPost()
        {
            this.service.UpdatePost(new EditPostBindingModel()
            {
                Id = 1,
                Content = "Edited",
                Title = "Edited Title"
            });

            var post = this.uow.Posts.FirstOrDefault(x => x.Id == 1);

            Assert.AreEqual(post.Content, "Edited");
            Assert.AreEqual(post.Title, "Edited Title");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdatePost_ThrowsExceptionOnInvalidId()
        {
            this.service.UpdatePost(new EditPostBindingModel()
            {
                Id = -2,
            });
        }

        private void InitializeMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AddPostBindingModel, PostEntityModel>();

                cfg.CreateMap<AddTutorialBindingModel, TutorialEntityModel>()
                    .ForMember(dest => dest.Thumbnail, opt => opt
                    .MapFrom(src => string.Format(Consts.VideoThumbnailFormat, src.VideoId)));

                cfg.CreateMap<PostEntityModel, PostViewModel>()
                    .ForMember(dest => dest.CommentsCount, o => o.MapFrom(x => x.Comments.Count))
                    .ForMember(dest => dest.Likes, o => o.MapFrom(m => m.UsersWhoLiked.Count));

                cfg.CreateMap<TutorialEntityModel, TutorialViewModel>();

                cfg.CreateMap<AddProjectBindingModel, ProjectEntityModel>()
                    .ForMember(dest => dest.ProjectType, x => x.NullSubstitute(ProjectTypes.Development));

                cfg.CreateMap<ProjectEntityModel, ProjectViewModel>();

                cfg.CreateMap<EditPostBindingModel, PostViewModel>();

                cfg.CreateMap<EditProjectBindingModel, ProjectViewModel>();

                cfg.CreateMap<EditTutorialBindingModel, TutorialViewModel>();
            });
        }
    }
}
