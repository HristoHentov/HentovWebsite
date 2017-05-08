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
    public class PortfolioControllerTest
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPortfolioService service;
        private readonly PortfolioController controller;

        public PortfolioControllerTest()
        {
            this.unitOfWork = new FakeUnitOfWork();
            this.service = new PortfolioService(unitOfWork);
            this.controller = new PortfolioController(service);
            InitializeMappings();
        }

        public void Setup()
        {
            this.unitOfWork.Projects.Add(new ProjectEntityModel
            {
                Id = 1,
                Name = "Project 1",
                Description = "This is the description for project 1.",
                ProjectLink = "https://amazon.uk",
                ProjectType = ProjectTypes.Design,
                Thumbnail = "/img/thumb1.png"
            });

            this.unitOfWork.Projects.Add(new ProjectEntityModel
            {
                Id = 2,
                Name = "Project 2",
                Description = "This is the description for project 2.",
                ProjectLink = "https://google.com",
                ProjectType = ProjectTypes.Development,
                Thumbnail = "/img/thumb2.png"
            });

            this.unitOfWork.Projects.Add(new ProjectEntityModel
            {
                Id = 3,
                Name = "Project 3",
                Description = "This is the description for project 3.",
                ProjectLink = "https://youtube.com",
                ProjectType = ProjectTypes.Design,
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
        public void Development_ShouldReturnDefaultView()
        {
            controller
                .WithCallTo(c => c.Development())
                .ShouldRenderDefaultView()
                .WithModel<List<ProjectViewModel>>();
        }

        [TestMethod]
        public void Design_ShouldReturnDefaultView()
        {
            controller
                .WithCallTo(c => c.Design())
                .ShouldRenderDefaultView()
                .WithModel<List<ProjectViewModel>>();
        }

        [TestMethod]
        public void Edit_ShouldReturnDefaultView()
        {
            controller
                .WithCallTo(c => c.Edit(new ProjectViewModel()))
                .ShouldRenderDefaultView()
                .WithModel<ProjectViewModel>();
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
