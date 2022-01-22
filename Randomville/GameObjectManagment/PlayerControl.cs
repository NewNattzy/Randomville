using System;
using GameObjects;


namespace GameManagment
{

    public static class PlayerControl
    {

        private static Dictionary<ConsoleKey, Action> controlKeys = new Dictionary<ConsoleKey, Action>();

        private static bool interrupOperation = false;
        private static ConsoleKeyInfo pressedKey;

        private static int x;
        private static int y;


        public static void SetControlKey()
        {

            controlKeys.Add(ConsoleKey.UpArrow, UpArrowPress);
            controlKeys.Add(ConsoleKey.DownArrow, DownArrowPress);
            controlKeys.Add(ConsoleKey.LeftArrow, LeftArrowPress);
            controlKeys.Add(ConsoleKey.RightArrow, RightArrowPress);
            controlKeys.Add(ConsoleKey.Enter, EnterPress);
            controlKeys.Add(ConsoleKey.I, KeyInventoryPress);
            controlKeys.Add(ConsoleKey.M, KeyMapPress);

        }

        public static void SetPlayerStartPosition(Player player)
        {
            x = player.cord.X;
            y = player.cord.Y;
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

            if (controlKeys.ContainsKey(pressedKey.Key))
            {
                controlKeys[pressedKey.Key]();
            }

        }


        #region ArrowKey
        public static void UpArrowPress()
        {
            WorldMap.RemovePlayerFromOldPoint(x, y);
            WorldMap.PlayerMove(x, --y);
        }

        private static void DownArrowPress()
        {
            WorldMap.RemovePlayerFromOldPoint(x, y);
            WorldMap.PlayerMove(x, ++y);
        }

        private static void LeftArrowPress()
        {
            WorldMap.RemovePlayerFromOldPoint(x, y);
            WorldMap.PlayerMove(--x, y);
        }

        private static void RightArrowPress()
        {
            WorldMap.RemovePlayerFromOldPoint(x, y);
            WorldMap.PlayerMove(++x, y);
        }
        #endregion

        #region OtherKey
        private static void EnterPress()
        {
            for (int i = 0; i < FillingWorldMap.cities.Count; i++)
            {
                if (FillingWorldMap.cities[i].cord.X == x && FillingWorldMap.cities[i].cord.Y == y)
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
        #endregion


        private static void CleaningGUI()
        {

            interrupOperation = true;
            Thread.Sleep(200);
            Console.Clear();

        }


        // Немного нелогично держать здесь
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
