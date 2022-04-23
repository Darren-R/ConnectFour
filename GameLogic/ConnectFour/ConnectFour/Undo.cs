using System.Runtime.Serialization.Formatters.Binary;

namespace Game
{
    public static class Undo
    {
        public static Board DeepClone<Board>(this Board obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (Board)formatter.Deserialize(ms);
            }
        }
    }
}
