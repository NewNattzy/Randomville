using System;
using GameObjects;


namespace GameManagment
{

    public static class PlayerControl
    {

        private delegate void Keystrok();
        private static Dictionary<ConsoleKey, Keystrok> controlKeys = new Dictionary<ConsoleKey, Keystrok>();

        private static bool interrupOperation = false;
        private static ConsoleKeyInfo pressedKey;

        private static int x = 5;
        private static int y = 5;


        public static void SetControlKey()
        {

            controlKeys.Add(ConsoleKey.UpArrow, new Keystrok(UpArrowPress));
            controlKeys.Add(ConsoleKey.DownArrow, new Keystrok(DownArrowPress));
            controlKeys.Add(ConsoleKey.LeftArrow, new Keystrok(LeftArrowPress));
            controlKeys.Add(ConsoleKey.RightArrow, new Keystrok(RightArrowPress));
            controlKeys.Add(ConsoleKey.Enter, new Keystrok(EnterPress));
            controlKeys.Add(ConsoleKey.I, new Keystrok(KeyInventoryPress));
            controlKeys.Add(ConsoleKey.M, new Keystrok(KeyMapPress));

        }


        public static async void WaitingForPlayerInputAsync()
        {
            
            while (true)
            {
                await Task.Run(() => PlayerInput());
            }

        }


        private static void PlayerInput()
        {

            pressedKey = Console.ReadKey();

            foreach(ConsoleKey key in controlKeys.Keys)
            {
                if (pressedKey.Key == key)
                {
                    controlKeys[key]();
                }
            }

        }


        // TODO: Доработать
        public static void UpArrowPress()
        {
            WorldMap.ClearPlayer(x, y);
            y--;
            WorldMap.PlayerMove(x, y);
        }

        private static void DownArrowPress()
        {
            WorldMap.ClearPlayer(x, y);
            y++;
            WorldMap.PlayerMove(x, y);
        }

        private static void LeftArrowPress()
        {
            WorldMap.ClearPlayer(x, y);
            x--;
            WorldMap.PlayerMove(x, y);
        }

        private static void RightArrowPress()
        {
            WorldMap.ClearPlayer(x, y);
            x++;
            WorldMap.PlayerMove(x, y);
        }


        private static void EnterPress()
        {
            for (int i = 0; i < FillingWorldMap.cities.Count; i++)
            {
                if (FillingWorldMap.cities[i].XCord == x && FillingWorldMap.cities[i].YCord == y)
                {
                    CleaningGUI();
                    FillingWorldMap.cities[i].ShowParameters();
                }
            }
        }

        private static void KeyInventoryPress()
        {
            CleaningGUI();
            Console.WriteLine("ИНВЕНТАРЬ");
        }

        private static void KeyMapPress()
        {
            CleaningGUI();
            DisplayWorldMap();
        }



        // TODO: Перенести/доработать
        private static void CleaningGUI()
        {

            interrupOperation = true;
            Thread.Sleep(200);
            Console.Clear();

        }

        private static void DisplayWorldMap()
        {

            interrupOperation = false;

            while (interrupOperation != true)
            {
                WorldMap.ShowMap();
            }

        }

    }

}