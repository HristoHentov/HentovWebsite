namespace HentovWebsite.Models.View.Tutorials
{
    public class TutorialViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public long Length { get; set; }
    }
}
