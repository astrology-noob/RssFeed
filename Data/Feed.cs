using System.Xml.Linq;

namespace RssFeeder.Data
{
    public sealed class Feed
    {
        public Guid Guid;
        public string Name = string.Empty;
        public string RssSource = string.Empty;
        public int UpdateSpan;
        public HashSet<Item> Items = new();

        public Feed(string name, string rssSource, int updateSpan)
        {
            Guid = Guid.NewGuid();
            Name = name;
            RssSource = rssSource;
            UpdateSpan = updateSpan; 
        }

        public async Task UpdateItems()
        {
            using (var httpClient = new HttpClient())
            {
                using (var result = await httpClient.GetAsync(RssSource))
                {
                    string stringRss = await result.Content.ReadAsStringAsync();
                    XDocument rss = XDocument.Parse(stringRss);
                    Items.UnionWith(rss.Root.Descendants()
                            .First(i => i.Name.LocalName == "channel")
                            .Elements()
                            .Where(i => i.Name.LocalName == "item")
                            .Select(item => new Item(
                                            item.Elements().First(i => i.Name.LocalName == "title").Value,
                                            item.Elements().First(i => i.Name.LocalName == "link").Value,
                                            item.Elements().First(i => i.Name.LocalName == "description").Value,
                                            DateTime.Parse(item.Elements().First(i => i.Name.LocalName == "pubDate").Value)
                                        )).Take(20).ToHashSet());
                };
            }
        }
    }
}
