using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Piece
    {
        private String Id;
        public String getId()
        {
            return Id;
        }
        public void setId(String id)
        {
            Id = id;
        }
    }
}