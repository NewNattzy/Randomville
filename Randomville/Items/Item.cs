using System;
using System.Data.Entity;


namespace Items
{
    public class Items : DbContext
    {
        // TODO: Использовать коллекции и LINQ для хранения предметов в рюкзаке и их добавлении/поиске/удалении

        protected Items()
            : base("DBConnectionString")
        {
            // 
        }



    }

}