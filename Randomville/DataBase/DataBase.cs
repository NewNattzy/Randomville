using GameObjects;
using System.Data.Entity;


namespace Storage
{
    public class DataBase : DbContext
    {

        public DataBase()
            : base("DefaultConnection")
        {

        }

        // public DbSet<Enemy> Enemies { get; set; }

    }

}
