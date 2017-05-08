using System.Reflection.Emit;

namespace HentovWebsite.Utility
{
    public static class Consts
    {

        /// <summary>
        /// Regular expressions
        /// </summary>
        public const string     VideoRegex = "(?:https?:\\/\\/)?(?:www\\.)?youtu\\.?be(?:\\.com)?\\/?.*(?:watch|embed)?(?:.*v=|v\\/|\\/)([\\w\\-_]+)\\&?";

        public const string     UrlRegex = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";

        public const string     VideoThumbnailFormat = "https://img.youtube.com/vi/{0}/1.jpg";

        public const string     UrlValidationError = "The given value was not a valid url.";

        public const string     NullApplicationUserError = "The given Identity user is null.";

        public const string     DeletePostError = "Failed to delete post.";

        public const string     DeleteProjectError = "Failed to delete project.";

        public const string     DeleteTutorialError = "Failed to delete tutorial.";

        public const string     GmailSmtpHost = "smtp.gmail.com";

        public const int        GmailSmtpPort = 587;

        public const string     AdminMailCredential = "hentovwebsite@gmail.com";

        public const string     AdminPassowrdCredential = "294915294915";

        public const string     AdminMailRecepient = "xpx1991@abv.bg";

    }
}
