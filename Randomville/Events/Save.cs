using System;
using GameObjects;
using GameObjectManagment;
using System.Xml.Serialization;

namespace Events
{
    public static class Save
    {

        public static void MakeSave()
        {
            // TODO: BinaryFormatter устарел, нужно менять xml, json
            EnemyArmy army = EnemyManagment.CreateArmyEnemy("Нежить", 40);

            var xmlFormatter = new XmlSerializer(typeof(EnemyArmy));

            using (var file = new FileStream("Save.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, army);
            };

            using (var file = new FileStream("Save.xml", FileMode.OpenOrCreate))
            {
                object? newArmy = xmlFormatter.Deserialize(file);
                if (newArmy != null)
                    army = (EnemyArmy)newArmy;
            };
        }

    }
}
