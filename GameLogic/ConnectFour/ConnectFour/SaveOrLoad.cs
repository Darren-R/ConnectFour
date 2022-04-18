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
        public void saveGame(object data)
        {
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if(File.Exists(GAME_FILE)) File.Delete(GAME_FILE);

            fileStream = File.Create(GAME_FILE);
            bf.Serialize(fileStream, data);
            fileStream.Close();
        }
        public static object loadGame()
        {
            object obj = null;
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(GAME_FILE))
            {
                fileStream = File.OpenRead(GAME_FILE);
                obj = bf.Deserialize(fileStream);
                fileStream.Close();
            }
            return obj;
        }
    }
}