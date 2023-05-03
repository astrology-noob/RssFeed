namespace RssFeeder.Data
{
    public class FeedService
    {
        public HashSet<Feed> Feeds { get; set; } = new HashSet<Feed>();

        public FeedService()
        {
            Feeds.Add(
                new("Лента Ру", "https://lenta.ru/rss/articles", 10)
            );
            Feeds.Add(
                new("N + 1", "https://nplus1.ru/rss", 10)
            );
        }

        public Feed GetFeedByGuid(string guid)
        {
            return Feeds.First(f => f.Guid.ToString() == guid);
        }

        public void CreateFeed(string name, string rssSource, int updateTime)
        {
            Feeds.Add(new(name, rssSource, updateTime));
        }

        public void DeleteFeed()
        {
            //Feeds.Remove();
        }
    }
}
