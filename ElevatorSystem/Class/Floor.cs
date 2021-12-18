using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorSystem
{
    class Floor
    {
        private int numberFloor;
        private int positionX;
        private int positionY;
        
        public Floor(int numberFloor, int positionX, int positionY)
        {
            this.numberFloor = numberFloor;
            this.positionX = positionX;
            this.positionY = positionY;
           
        }
         
        public int PositionX
        {
            get {
                return positionX;
            }
        }

        public int PositionY
        {
            get
            {
                return positionY;
            }
        }
    }
}
