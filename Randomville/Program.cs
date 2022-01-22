using System;
using GameConfig;
using GameObjects;
using GameObjectManagment;
using GameManagment;
using Resources;


namespace ConsoleGame
{

    internal class Program
    {

        public static void Main(string[] args)
        {

            if (args is null) throw new ArgumentNullException(nameof(args));

            GamePreparation();

            Player player = new Player("kek", 1, 1, 1, 1, 1, 1, "kek");
            PlayerControl.SetPlayerStartPosition(player);

            Task.Factory.StartNew(ActivatingSimulationOfLife);


            while (true)
            {
                PlayerControl.WaitingForPlayerInputAsync();
                Thread.Sleep(1000);
            }

 
        }


        private static void GamePreparation()
        {

            Config.SetValues();
            Graphics.SetPicture();
            WorldMap.CreateMap();
            PlayerControl.SetControlKey();

        }


        private static void ActivatingSimulationOfLife()
        {

            while (true)
            {
                FillingWorldMap.CreateObjects();
                FillingWorldMap.SimulationLife();
                Thread.Sleep(100);
            }

        }

    }

}