using GameObjects;

namespace Interfaces
{
    public interface ILocation
    {

        public static int locationCount;

        public Location this[int index] { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Landscape { get; set; }
        public string Status { get; set; }

        public int Danger { get; set; }
        public int Population { get; set; }


        public void Destroyed();
        public void Sieged();
        public void Cursed();
        public void Improved();

    }

}