using System.ComponentModel.DataAnnotations.Schema;
using HentovWebsite.Models.Enums;

namespace HentovWebsite.Models.Entity.Portfolio
{
    [Table(name:"Projects")]
    public class ProjectEntityModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProjectLink { get; set; }

        public string Thumbnail { get; set; }

        public ProjectTypes ProjectType { get; set; }
    }
}
