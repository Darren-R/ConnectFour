using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Game
{
    public class SaveOrLoad
    {
        private const string GAME_FILE = "ConnectFourSave.bin";
        public static void saveGame()
        {
            FileStream fs = new FileStream(GAME_FILE, FileMode.Append);
            BinaryFormatter formatter = new BinaryFormatter();

            Hashtable addresses = new Hashtable();
            addresses.Add("Jeff", "123 Main Street, Redmond, WA 98052");
            formatter.Serialize(fs, addresses);
            fs.Close();
        }
        public static void loadGame()
        {
            FileStream fs = new FileStream(GAME_FILE, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            Hashtable addresses = new Hashtable();
            addresses = (Hashtable) formatter.Deserialize(fs);
            fs.Close();
        }
    }
}