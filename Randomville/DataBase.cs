using Items;
using System.Data.Entity;

namespace Storage
{
    public class DataBase : DbContext
    {

        public DataBase()
            : base()
        {

        }

        public DbSet<Item> ItemsTable { get; set; }









    }

}