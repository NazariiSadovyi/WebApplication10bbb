using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication10bbb.GhostsAndPacman
{
    public class Inky
    {
        private GameMap _gameMap = new GameMap();

        public bool IsMoving = false;
        public bool MovingToHome = false;
        public bool IsPaused = false;
        public bool PersecutionOrRunaway = true;
        public bool TimerType = false;
        public int position_x = 11;
        public int position_y = 13;

        public int run_point_x = 29;
        public int run_point_y = 26;

        public int pacman_position_plus_two_x;
        public int pacman_position_plus_two_y;

        public int finish_point_x;
        public int finish_point_y;
        public int move_X = 0;
        public int move_Y = -1;
        public int last_move_X;
        public int last_move_Y;

        private Timer PersecutionOrRunawayTimer;

        public DateTime dateTime_current = new DateTime();
        public DateTime dateTime_new = new DateTime();

        public Stopwatch PersecutionOrRunawayWatch = new Stopwatch();
        public Stopwatch IsFrightenedWatch = new Stopwatch();

        public Inky()
        {

        }

        public void StartMoving()
        {
            IsMoving = true;
            PersecutionOrRunawayTimer = new Timer(Update_finish_point, null, 0, 0);
            PersecutionOrRunawayWatch.Start();
        }


        int time = 7000;
        int current_timer;

        private void Update_finish_point(object state)
        {
            if (PersecutionOrRunaway)
            {
                PersecutionOrRunaway = false;
                PersecutionOrRunawayTimer.Change(time, 0);
                PersecutionOrRunawayWatch.Restart();
                time = 7000;
            }
            else
            {
                PersecutionOrRunaway = true;
                PersecutionOrRunawayTimer.Change(time, 0);
                PersecutionOrRunawayWatch.Restart();
                time = 20000;
            }

        }

        public void StopPersecutionOrRunaway()
        {
            PersecutionOrRunawayTimer.Dispose();
            PersecutionOrRunawayWatch.Stop();

        }

        public void ContinuousMoving()
        {
            if (PersecutionOrRunaway)
            {
                PersecutionOrRunawayTimer = new Timer(Update_finish_point, null, 7000 - Convert.ToInt32(PersecutionOrRunawayWatch.ElapsedMilliseconds), 0);
            }
            else
            {
                PersecutionOrRunawayTimer = new Timer(Update_finish_point, null, 20000 - Convert.ToInt32(PersecutionOrRunawayWatch.ElapsedMilliseconds), 0);
            }

            PersecutionOrRunawayWatch.Start();

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
            IsFrightenedWatch.Restart();
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

        public void StopFrightened()
        {
            FrightenedTimer.Dispose();
            IsFrightenedWatch.Stop();

        }

        public void ContinuousFrightened()
        {
            FrightenedTimer = new Timer(FrightenedChange, null, 10000 - Convert.ToInt32(IsFrightenedWatch.ElapsedMilliseconds), 0);
            PersecutionOrRunawayWatch.Start();
        }

        public void FrightenedChange(object state)
        {
            IsFrightened = false;
            FrightenedTimer.Dispose();
            IsFrightenedWatch.Reset();
        }
    }
}
