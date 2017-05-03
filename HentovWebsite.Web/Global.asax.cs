using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using HentovWebsite.Models.Binding.Blog;
using HentovWebsite.Models.Binding.Tutorials;
using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.Entity.Tutorials;
using HentovWebsite.Models.View.Blog;
using HentovWebsite.Models.View.Tutorials;
using HentovWebsite.Web.Misc;

namespace HentovWebsite.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeMappings();
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
                    .ForMember(dest => dest.CommentsCount, o => o.MapFrom(x => x.Comments.Count));

                cfg.CreateMap<TutorialEntityModel, TutorialViewModel>();
            });
        }
    }
}
