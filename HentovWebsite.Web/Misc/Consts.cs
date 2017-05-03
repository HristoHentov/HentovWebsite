namespace HentovWebsite.Web.Misc
{
    public static class Consts
    {
        public static string VideoThumbnailFormat = "https://img.youtube.com/vi/{0}/1.jpg";

        public static string VideoRegex = "(?:https?:\\/\\/)?(?:www\\.)?youtu\\.?be(?:\\.com)?\\/?.*(?:watch|embed)?(?:.*v=|v\\/|\\/)([\\w\\-_]+)\\&?";
    }
}