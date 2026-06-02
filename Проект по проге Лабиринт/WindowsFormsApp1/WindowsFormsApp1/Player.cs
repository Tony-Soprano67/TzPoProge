using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Player(int X,int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
