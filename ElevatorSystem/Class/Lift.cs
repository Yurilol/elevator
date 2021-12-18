using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorSystem
{
    class Lift 
    {
        private static Lift lift;
        private static object syncRoot = new Object();

        private List<int> floorsStart;
        private List<int> floorsEnd;
        private int[] floorCoordinate;

        private LiftInformation liftInfo;
        private int countButtons;

        private int positionX;
        private int positionY;
        private int positionX_old;
        private int positionY_old;

        private int weight;
        private int weightSum;
        private int currentFloor;
        private int changeMoves;
        private bool moveUp;
        private int idleTrips;
        private int count;
        private bool enable;
        private int speed;
        private int target;
        private int transported;
        private DateTime date;

        protected Lift(int countButtons, int positionX, int positionY, int[] floorCoord) {

            this.positionX = positionX;
            this.positionY = positionY;
            positionX_old = positionX;
            positionY_old = positionY;
            this.countButtons = countButtons;
            weight = 0;
            target = 0;
            currentFloor = -1;

            date = DateTime.Now;

            moveUp = true;
            count = -1;
            weightSum = 0;

            enable = true;

            speed = 1;
            floorsStart = new List<int>();
            floorsEnd = new List<int>();
            floorCoordinate = floorCoord;
            changeMoves = 0;
            idleTrips = 0;
            transported = 0;
            
            this.countButtons = countButtons;
            liftInfo = new LiftInformation(countButtons);
            

        }

        public static Lift getInstance(int countButtons, int positionX, int positionY, int[] coordinate)
        {
            if (lift == null)
            {
                lock (syncRoot)
                {
                    if (lift == null)
                        lift = new Lift(countButtons, positionX, positionY, coordinate);
                }
            }
            return lift;
        }

        public void showInfo() 
        {
            liftInfo.ShowDialog();
        }

        public static Lift newInstance()
        {
            lift = null;
            return lift;
        }

        public void callTheElevator(int floorStart, int floorEnd)
        {
            floorsStart.Add(floorStart);
            floorsEnd.Add(floorEnd);
            if (floorsStart.Count == 1)
            {
                target = floorsStart[0];
                moveUp = true;
                changeMoves++;
                idleTrips++;
            }
            liftInfo.painMove(true);
        }

        public void moveTheElevator(int floor)
        {
            count++;
            floorsStart.Remove(floor);
            if (target == floor)
            {
                target = floorsEnd[0];
                changeMoves++;
            }
            else if (floorsStart.Count != 0)
            {
                target = floorsStart[0];
                idleTrips++;
            }
            liftInfo.painButton(target);
            liftInfo.addWeight(weight);
        }

        public void exitTheElevator(int floor)
        {
            count--;
            floorsEnd.Remove(floor);
            if (count > -1 && target == floor)
            {
                target = floorsEnd[0];
                liftInfo.painButton(target);
            }
            else if (count > -1 && target != floor)
            {
                liftInfo.painButton(target);
            }
            else if (floorsStart.Count != 0)
            {
                target = floorsStart[0];
                changeMoves++;
                idleTrips++;
                liftInfo.painButton(target);
            }
            else 
            {
                liftInfo.painMove(false);
                liftInfo.painButtonFalse();
            }
            liftInfo.addWeight(weight);
            transported++;
        }

        public bool moveNext() {
            if (moveUp)
            {
                move(target);
                date = DateTime.Now;
                enable = true;
            }
            else 
            {
                if (DateTime.Now.Second - date.Second >= 2) 
                {
                    moveUp = true;
                }
                enable = false;
            }
            return enable;
        }

        private void move(int num)
        {
            for (int i = 0; i < floorCoordinate.Length; i++) 
            {
                if (positionY == floorCoordinate[i]) 
                {
                    currentFloor = i;
                }
            }
            if (positionY > floorCoordinate[num])
            {
                positionY_old = positionY;
                positionY -= speed;
            }
            else if (positionY < floorCoordinate[num])
            {
                positionY_old = positionY;
                positionY += speed;
            }
            
        }

        public int PositionX
        {
            get
            {
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

        public int OldX
        {
            get
            {
                return positionX_old;
            }
        }

        public int NewY
        {
            get
            {
                return floorCoordinate[floorsEnd[0]] + 15;
            }
        }

        public int OldY
        {
            get
            {
                return positionY_old;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight += value;
            }
        }

        public int sumWeight
        {
            get
            {
                return weightSum;
            }
            set
            {
                weightSum += value;
            }
        }

        public int Transported
        {
            get
            {
                return transported;
            }
        }

        public int MoveChange
        {
            get
            {
                return changeMoves;
            }
        }

        public bool MoveUp
        {
            set
            {
                moveUp = value;
            }
        }

        public int IdleTrips
        {
            get
            {
                return idleTrips;
            }
        }

        public int CurrentFloor
        {
            get
            {
                return currentFloor;
            }
            set 
            {
                currentFloor = value;
            }
        }

       

    }
}
