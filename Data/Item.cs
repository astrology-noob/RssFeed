namespace RssFeeder.Data
{
    public class Item
    {
        public string Title { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PubDate { get; set; }

        public Item (string title, string link, string description, DateTime pubDate)
        {
            Title = title;
            Link = link;
            Description = description;
            PubDate = pubDate;
        }
    }
}
