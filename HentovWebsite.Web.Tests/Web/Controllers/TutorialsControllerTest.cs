using System;
using System.Collections.Generic;
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
using TestStack.FluentMVCTesting;

namespace HentovWebsite.Web.Tests.Web.Controllers
{
    [TestClass]
    public class TutorialsControllerTest
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITutorialsService service;
        private readonly TutorialsController controller;

        public TutorialsControllerTest()
        {
            this.unitOfWork = new FakeUnitOfWork();
            this.service = new TutorialService(unitOfWork);
            this.controller = new TutorialsController(service);
            InitializeMappings();
        }
        [TestInitialize]
        public void Setup()
        {
            this.unitOfWork.Tutorials.Add(new TutorialEntityModel()
            {
                Id = 1,
                Title = "DesignFx",
                Description = "A random tutorial deisnged for testing.",
                Length = 10,
                VideoUrl = "http://youtube.com/watch/v=a8KJxacc",
                Thumbnail = "/img/thumb5.png"
            });

            this.unitOfWork.Tutorials.Add(new TutorialEntityModel()
            {
                Id = 2,
                Title = "Stars",
                Description = "A random tutorial deisnged for testing.",
                Length = 12,
                VideoUrl = "http://youtube.com/watch/v=djfF24cs",
                Thumbnail = "/img/thumb3.png"
            });
        }


        [TestMethod]
        public void Index_ShouldReturnDefaultView()
        {
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Tutorial_ShouldReturnCorrectTutorialView()
        {
            controller
                .WithCallTo(c => c.Tutorial(2))
                .ShouldRenderDefaultView()
                .WithModel<TutorialViewModel>();
        }


        [TestMethod]
        public void Tutorial_ShouldThrowError()
        {
            controller
                .WithCallTo(c => c.Tutorial(4))
                .ShouldRenderDefaultView();
        }


        [TestMethod]
        public void Edit_ShouldReturnDefaultView()
        {
            controller
                .WithCallTo(c => c.Edit(new TutorialViewModel()))
                .ShouldRenderDefaultView()
                .WithModel<TutorialViewModel>();
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
