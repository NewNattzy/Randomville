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

            // TODO: BinaryFormatter устарел, нужно менять на xml или json
            EnemyArmy army = EnemyManagment.CreateEnemyArmy("Нежить", 40);

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
