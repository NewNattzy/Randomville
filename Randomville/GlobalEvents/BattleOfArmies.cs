using System;
using GameObjects;


namespace GlobalEvents
{

    public class BattleOfArmies
    {

        private static Dictionary<string, int> parametrsFirstArmy = new Dictionary<string, int>() { { "Health", 0 }, { "Mana", 0 }, { "Damage", 0 } };

        private static Dictionary<string, int> parametrsSecondArmy = new Dictionary<string, int>() { { "Health", 0 }, { "Mana", 0 }, { "Damage", 0 } };

        private const double MANA_DAMAGE_PERCENT = 0.055;


        public static Army GetLoserArmyThatBattle(List<Army> armies)
        {

            CheckListArmiesForNull(armies);
            CalculateParametersArmies(armies);
            return GetLosingArmy(armies);

        }


        private static void CheckListArmiesForNull(List<Army> armies)
        {
            if (armies == null)
                throw new ArgumentNullException(nameof(armies));
        }


        private static void CalculateParametersArmies(List<Army> armies)
        {

            for (int unit = 0; unit < armies[0].UnitCount; unit++)
            {
                parametrsFirstArmy["Health"] += armies[0][unit].Health;
                parametrsFirstArmy["Mana"] += armies[0][unit].Mana;
                parametrsFirstArmy["Damage"] += armies[0][unit].Damage;
            }
            parametrsFirstArmy["Damage"] += (int)(parametrsFirstArmy["Mana"] * MANA_DAMAGE_PERCENT);

            for (int unit = 0; unit < armies[1].UnitCount; unit++)
            {
                parametrsSecondArmy["Health"] += armies[1][unit].Health;
                parametrsSecondArmy["Mana"] += armies[1][unit].Mana;
                parametrsSecondArmy["Damage"] += armies[1][unit].Damage;
            }
            parametrsSecondArmy["Damage"] += (int)(parametrsSecondArmy["Mana"] * MANA_DAMAGE_PERCENT);

        }


        private static Army GetLosingArmy(List<Army> armies)
        {

            CalculateDamage();

            if (parametrsFirstArmy["Health"] < parametrsSecondArmy["Health"])
                return armies[0];
            else
                return armies[1];

        }


        private static void CalculateDamage()
        {

            while (parametrsFirstArmy["Health"] > 0 || parametrsSecondArmy["Health"] > 0)
            {

                parametrsFirstArmy["Health"] -= parametrsSecondArmy["Damage"];
                parametrsSecondArmy["Health"] -= parametrsFirstArmy["Damage"];

            }

        }


    }

}