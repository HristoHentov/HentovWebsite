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
using HentovWebsite.Web.Controllers;
using HentovWebsite.Web.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace HentovWebsite.Web.Tests.Web.Controllers
{
    [TestClass]
    public class BlogControllerTest
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IBlogService service;
        private readonly BlogController controller;
        
        public BlogControllerTest()
        {
            this.unitOfWork = new FakeUnitOfWork();
            this.service = new BlogService(unitOfWork);
            this.controller = new BlogController(service);
            InitializeMappings();
        }

        [TestInitialize]
        public void Setup()
        {
            this.unitOfWork.Posts.Add(new PostEntityModel()
            {
                Id = 1,
                Content = "Random Stuff",
                AuthorName = "Gosho",
                Title = "50 Shades of Gosho"
            });
            this.unitOfWork.Posts.Add(new PostEntityModel()
            {
                Id = 2,
                Content = "Random Stuff",
                AuthorName = "Pesho",
                Title = "Chorba or grehovete na Pesho"
            });
            this.unitOfWork.Posts.Add(new PostEntityModel()
            {
                Id = 3,
                Content = "Random Stuff",
                AuthorName = "Haralampi",
                Title = "Rise of the Haralampi"
            });
        }

        [TestMethod]
        public void IndexView_ShouldReturnDefaultView()
        {
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<PostCollectionViewModel>();
        }

        [TestMethod]
        public void LikePost_ShouldRequireUserToBeLoggedIn()
        {
            controller
                .WithCallTo(c => c.LikePost(1, "1", false))
                .ShouldRedirectTo<AccountController>(x => x.Login(""));

        }

        [TestMethod]
        public void DislikePost_ShouldRequireUserToBeLoggedIn()
        {
            controller
                .WithCallTo(c => c.DislikePost(1, "1", false))
                .ShouldRedirectTo<AccountController>(x => x.Login(""));

        }

        [TestMethod]
        public void Post_ShouldReturnCorrectPost()
        {
            controller
                .WithCallTo(c => c.Post(2))
                .ShouldRenderDefaultView().WithModel<PostViewModel>();

        }

        [TestMethod]
        public void Edit_ShouldReturnCorrectPost()
        {
            controller
                .WithCallTo(c => c.Edit(new PostViewModel()))
                .ShouldRenderDefaultView()
                .WithModel<PostViewModel>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Delete_ShouldThrowExceptionOnInvalidId()
        {
            controller
                .WithCallTo(c => c.Delete(-1));

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
