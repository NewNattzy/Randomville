using System;
using GameConfig;
using GameObjects;
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

            Player player = new Player("Аргус", 100, 100, 100, 10, 1000, 1000, "Воин");
            PlayerControl.SetPlayerStartPosition(player);

            Task.Factory.StartNew(ActivatingSimulationOfLife);

            ShowMainMenu();

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

        private static void ShowMainMenu()
        {
            Console.WriteLine("Добро пожаловать в Randomville!");
            Console.WriteLine("Открыть карту, клавиша - M");
            Console.WriteLine("Открыть инвентарь, клавиша - I");
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