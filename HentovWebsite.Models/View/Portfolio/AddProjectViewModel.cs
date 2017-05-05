using System.Security.AccessControl;

namespace HentovWebsite.Models.View.Portfolio
{
    public class AddProjectViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProjectLink { get; set; }

        public string Thumbnail { get; set; }

        public string Type { get; set; }
    }
}
