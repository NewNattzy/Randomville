using GameConfig;

namespace GameObjects
{
    public class WorldMap
    {

        private int x;
        private int y;
        private int[,] map = new int[Config.MaxMapSize / 10, Config.MaxMapSize / 10];

        public WorldMap()
        {

        }

    }

}
