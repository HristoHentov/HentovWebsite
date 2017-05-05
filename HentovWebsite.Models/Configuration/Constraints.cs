namespace HentovWebsite.Models.Configuration
{
    public static class Constraints
    {
        /// <summary>
        /// Tag Models Constraints
        /// </summary>
        public const int TagNameMaxLen = 15;
        public const int TagNameMinLen = 3;

        /// <summary>
        /// Comment Models Constraints
        /// </summary>
        public const int CommentContentMaxLen = 200;
        public const int CommentContentMinLen = 3;

        /// <summary>
        /// Tutorial Models Contraints
        /// </summary>
        public const string YouTubeRegex = "(?:https?:\\/\\/)?(?:www\\.)?youtu\\.?be(?:\\.com)?\\/?.*(?:watch|embed)?(?:.*v=|v\\/|\\/)([\\w\\-_]+)\\&?";
       
        /// <summary>
        /// Shared Constraints
        /// </summary>
        public const int TitleMaxLen = 30;
        public const int TitleMinLen = 4;

        public const int PostContentMaxLen = 1600;
        public const int PostContentMinLen = 10;

        public const int DescriptMaxLen = 1600;
        public const int DescriptMinLen = 10;
    }
}
