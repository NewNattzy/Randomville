namespace Items
{
    public class Item
    {
        // TODO: Использовать коллекции и LINQ для хранения предметов в рюкзаке и их добавлении/поиске/удалении

        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }
        public bool Consumable { get; set; }
        public string Description { get; set; }

        public Item()
        {
            // 
        }

        public virtual ICollection<Item> Items { get; set; }

    }

}