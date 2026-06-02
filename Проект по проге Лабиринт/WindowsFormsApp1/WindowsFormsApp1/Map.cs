using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Map
    {
        public Player player;
        public int coin = 0;
        public int key = 0;
        public char[,] map;
        public Map(char[,]map) 
        {
            this.map = map;
        }
    }
}
