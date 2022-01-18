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

            Thread myThread = new Thread(new ThreadStart(ActivationMainSystems));
            myThread.Start();

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


        private static void ActivationMainSystems()
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