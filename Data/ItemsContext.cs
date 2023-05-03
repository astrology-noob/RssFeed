namespace RssFeeder.Data
{
    public class ItemsContext
    {
        public List<Item> Items { get; set; }

        public async Task AddItemsAsync(List<Item> items)
        {
            await Task.Run(() => Items.AddRange(items));
        }

        public async Task AddItemsAsync(Item item)
        {
            await Task.Run(() => Items.Add(item));
        }
    }
}
