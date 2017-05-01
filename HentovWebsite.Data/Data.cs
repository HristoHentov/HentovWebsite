namespace HentovWebsite.Data
{
    public class Data
    {
        private static HentovWebsiteContext context;

        public static HentovWebsiteContext Context => context ?? (context = new HentovWebsiteContext());
    }
}
