using System;


namespace Items
{

    public class Item
    {

        public int ID { get; set; }
        public int Cost { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        
        public bool Consumable { get; set; }



        public Item(int id, string name, string type, int cost, bool consumable, string description)
        {

            ID = id;
            Name = name;
            Type = type;
            Cost = cost;
            Consumable = consumable;
            Description = description;

        }

    }

}