using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication10bbb.GhostsAndPacman
{
    public class Clyde
    {
        private GameMap _gameMap = new GameMap();

        public bool IsMoving = false;
        public bool MovingToHome = false;
        public bool PersecutionOrRunaway = true;
        public bool TimerType = false;

        public int position_x = 11;
        public int position_y = 13;

        public int run_point_x = 29;
        public int run_point_y = 1;

        public int finish_point_x;
        public int finish_point_y;
        public int move_X = 0;
        public int move_Y = -1;
        public int last_move_X;
        public int last_move_Y;

        private Timer timer;

        public Clyde()
        {

        }

        public void StartMoving()
        {
            IsMoving = true;
            timer = new Timer(Update_finish_point, null, 7000, 0);
        }

        private void Update_finish_point(object state)
        {
            if (PersecutionOrRunaway)
            {
                PersecutionOrRunaway = false;
                timer.Change(20000, 0);
            }
            else
            {
                PersecutionOrRunaway = true;
                timer.Change(7000, 0);
            }

        }

        public bool IsFrightened = false;
        Timer FrightenedTimer;

        

        public void Frightened()
        {

            if (move_X == 1)
            {
                move_X = -1;
            }
            else if (move_X == -1)
            {
                move_X = 1;
            }
            else if (move_Y == 1)
            {
                move_Y = -1;
            }
            else if (move_Y == -1)
            {
                move_Y = 1;
            }

            IsFrightened = true;
            FrightenedTimer = new Timer(FrightenedChange, null, 10000, 0);
        }

        public void RandomMove()
        {
            Dictionary<char, int> ts = new Dictionary<char, int>();

            if ((_gameMap.map[position_x + 1, position_y] != 'w') && (move_X != -1))
            {
                ts.Add('x', 1);
            }
            if ((_gameMap.map[position_x - 1, position_y] != 'w') && (move_X != 1))
            {
                ts.Add('X', -1);
            }
            if ((_gameMap.map[position_x, position_y + 1] != 'w') && (move_Y != -1))
            {
                ts.Add('y', 1);
            }
            if ((_gameMap.map[position_x, position_y - 1] != 'w') && (move_Y != 1))
            {
                ts.Add('Y', -1);
            }

            Random random = new Random();
            var t = random.Next(ts.Count);

            var item = ts.ElementAt(t);

            if ((item.Key == 'x') || (item.Key == 'X'))
            {
                move_X = item.Value;
                move_Y = 0;
            }
            else
            {
                move_Y = item.Value;
                move_X = 0;
            }
        }

        public void FrightenedChange(object state)
        {
            IsFrightened = false;
            FrightenedTimer.Dispose();
        }
    }
}
