using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication10bbb.GhostsAndPacman
{
    public class Ghost
    {
        private GameMap _gameMap = new GameMap();

        public bool IsMoving = false; 
        public bool IsPaused = false; 
        public bool MovingToHome = false; // рухається до будинку
        public bool PersecutionOrRunaway = false; // знаходиться в режимі переслідування чи розбігання
        public bool TimerType = false;
        public bool IsFrightened = false; // режим страху (можливість бути з'їденим пакменом)

        public int position_x = 11; // початкова позиція 
        public int position_y = 13; 

        public int run_point_x; // позиція розбігання 
        public int run_point_y; 

        public int finish_point_x; // цільва точка (залежить від логіки)
        public int finish_point_y;

        public int move_X = 0; // напрямок руху
        public int move_Y = -1;

        public int last_move_X; // останній напрямок руху (для паузи)
        public int last_move_Y;

        public int initial_score_limit;

        public Timer PersecutionOrRunawayTimer; // таймер який режиму руху             

        public Stopwatch PersecutionOrRunawayWatch = new Stopwatch(); // секундомір режиму руху (для паузи)
        public Stopwatch IsFrightenedWatch = new Stopwatch(); // секундомір режиму страху (для паузи)

        public Ghost()
        {

        }
                 
        public void StartMoving()
        {
            IsMoving = true;
            PersecutionOrRunawayTimer = new Timer(Update_finish_point, null, 0, 0);
            PersecutionOrRunawayWatch.Start();
        }


        int time = 7000;  
        // зміна режиму розбігання із режимом переслідування
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
                try
                {
                    PersecutionOrRunawayTimer.Change(time, 0);
                }
                catch { }
                PersecutionOrRunawayWatch.Restart();
                time = 20000;
            }

        }

        // зупинка таймера розбігання/переслідування
        public void StopPersecutionOrRunaway()
        {
            PersecutionOrRunawayTimer.Dispose();
            PersecutionOrRunawayWatch.Stop();
        }

        // продовження таймера в режимі розбігання\переслідування
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
          
        public Timer FrightenedTimer;

        // перехід у режим страху і розворот у протилежну сторону
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

        // визначення рандомного напрямку(у режимі страху)
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

        // зупинка тамера режиму страху (для паузи)
        public void StopFrightened()
        {
            FrightenedTimer.Dispose();
            IsFrightenedWatch.Stop();
        }

        // продовження таймера режиму страху (для паузи)
        public void ContinuousFrightened()
        {
            FrightenedTimer = new Timer(FrightenedChange, null, 10000 - Convert.ToInt32(IsFrightenedWatch.ElapsedMilliseconds), 0);
            PersecutionOrRunawayWatch.Start();
        }

        // відміна режиму страху і зупинка його таймера
        public void FrightenedChange(object state)
        {
            IsFrightened = false;
            FrightenedTimer.Dispose();
            IsFrightenedWatch.Reset();
        }
    }
}
