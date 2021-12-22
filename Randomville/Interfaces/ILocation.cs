using GameObjects;

namespace Interfaces
{
    public interface ILocation
    {

        public static double calcPercent;

        public static int locationCount;

        public string Name { get; set; }
        public string Type { get; set; }
        public string Landscape { get; set; }
        public string Status { get; set; }

        public int Danger { get; set; }

        public void Destroy();
        public void Curse();
        public void Improve();

    }

}