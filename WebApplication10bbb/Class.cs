using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication10bbb.GhostsAndPacman;
using WebApplication10bbb.MapGraph;

namespace WebApplication10bbb
{
    public class Class
    {
        public List<string> clients = new List<string>();
        
        public string UserName;

        private GameMap _gameMap = new GameMap();

        private Pacman _pacman = new Pacman();
      
        private GhostBlinky blinky;
        
        private GhostPinky pinky;
      
        private GhostClyde clyde;
 
        private GhostInky inky;

        public Timer PacmanTimer, ClydeTimer, PinkyTimer, BlinkyTimer, InkyTimer;

        private bool pause = false;

        private Init init = new Init();

        public string ConnectionID { get; set; }

        private IHubContext<GameHub> hub { get; set; }

        public Class(string connectionID, IHubContext<GameHub> hub)
        {
            clients.Add(connectionID);
            this.hub = hub;
        }

        public Task Move(int move)
        {
            if (pause == false)
            {
                if (move == 6)
                {
                    if (_gameMap.map[_pacman.position_x, _pacman.position_y + 1] != 'w')
                    {
                        _pacman.move_Y = 1;
                        _pacman.move_X = 0;
                    }
                }
                else if (move == 4)
                {
                    if (_gameMap.map[_pacman.position_x, _pacman.position_y - 1] != 'w')
                    {
                        _pacman.move_Y = -1;
                        _pacman.move_X = 0;
                    }
                }

                else if (move == 8)
                {
                    if (_gameMap.map[_pacman.position_x - 1, _pacman.position_y] != 'w')
                    {
                        _pacman.move_Y = 0;
                        _pacman.move_X = -1;
                    }
                }
                else if (move == 2)
                {
                    if (_gameMap.map[_pacman.position_x + 1, _pacman.position_y] != 'w')
                    {
                        _pacman.move_Y = 0;
                        _pacman.move_X = 1;
                    }
                }

            }
            return Task.CompletedTask;
        }

        internal Task StartGame()
        {
            blinky = new GhostBlinky();            
            pinky = new GhostPinky();
            clyde = new GhostClyde();
            inky = new GhostInky();


            PacmanTimer = new Timer(UpdatePacman, null, 0, 100);
            InkyTimer = new Timer(UpdateInky, null, 0, 120);
            ClydeTimer = new Timer(UpdateCloudy, null, 0, 120);
            PinkyTimer = new Timer(UpdatePinky, null, 0, 120);
            BlinkyTimer = new Timer(UpdateBlinky, null, 0, 120);

            return Task.CompletedTask;
        }

        private int score;
        private int ghost_start_score;
        private int bonus_score = 100;
        private int sum_bonus_score = 0;

        private void StopGhostMoving(Ghost ghost)
        {
            if (ghost.IsMoving == true)
            {
                ghost.IsMoving = false;
                ghost.IsPaused = true;
                if (ghost.IsFrightened)
                {
                    ghost.StopFrightened();
                }
                else
                {
                    ghost.StopPersecutionOrRunaway();
                }
            }
        }

        private void ContinGhostMoving(Ghost ghost)
        {
            if (ghost.IsPaused == true)
            {
                ghost.IsMoving = true;
                ghost.IsPaused = false;
                if (ghost.IsFrightened)
                {
                    ghost.ContinuousFrightened();
                }
                else
                {
                    ghost.ContinuousMoving();
                }
            }
        }

        internal Task PauseGame()
        {
            if (pause == false)
            {
                _pacman.last_move_X = _pacman.move_X;
                _pacman.last_move_Y = _pacman.move_Y;

                _pacman.move_X = 0;
                _pacman.move_Y = 0;
                  
                StopGhostMoving(blinky);

                StopGhostMoving(pinky);

                StopGhostMoving(clyde);

                StopGhostMoving(inky);

                pause = true;
            }
            else
            {
                pause = false;
                _pacman.move_X = _pacman.last_move_X;
                _pacman.move_Y = _pacman.last_move_Y;
                           
                ContinGhostMoving(blinky);
                         
                ContinGhostMoving(pinky);

                ContinGhostMoving(clyde);

                ContinGhostMoving(inky);

            }

            return Task.CompletedTask;
        }

        List<string> ited_coin = new List<string>();

        private void CheckPacmanTouchGhost(Ghost ghost)
        {
            if ((_pacman.position_x == ghost.position_x) && (_pacman.position_y == ghost.position_y))
            {
                if (ghost.IsFrightened == true)
                {
                    ghost.FrightenedChange(new object());
                    ghost.MovingToHome = true;
                    bonus_score = bonus_score * 2;
                    sum_bonus_score += bonus_score;
                    hub.Clients.Clients(clients).SendAsync("Eated_ghost", ghost.position_x, ghost.position_y, bonus_score);
                }
                else if ((ghost.IsFrightened == false) && (ghost.MovingToHome == false))
                {
                    _pacman.position_x = 1;
                    _pacman.position_y = 1;
                    _pacman.move_X = 0;
                    _pacman.move_Y = 1;
                }

            }
        }

        private void MakeGhostFrightened(Ghost ghost, Timer timer)
        {
            if (ghost.IsMoving)
            {
                if (ghost.IsFrightened)
                {
                    ghost.FrightenedChange(new object());
                    ghost.Frightened();

                }
                else
                {
                    ghost.Frightened();
                    timer.Change(120, 300);
                }
            }
        }

        private void UpdatePacman(object state)
        {
            if (pause == false)
            {
                if (_gameMap.CoinMap[_pacman.position_x , _pacman.position_y ] == 'c')
                {
                    _gameMap.CoinMap[_pacman.position_x, _pacman.position_y] = ' ';
                    score++;
                    ghost_start_score++;
                    if (ghost_start_score == 1)
                    {
                        blinky.StartMoving();
                    }
                    if ((ghost_start_score == 10) && (pinky.IsMoving == false))
                    {
                        pinky.StartMoving();
                    }
                    if ((ghost_start_score == 20) && (clyde.IsMoving == false))
                    {
                        clyde.StartMoving();
                    }
                    if ((ghost_start_score == 30) && (inky.IsMoving == false))
                    {
                        inky.StartMoving();
                    }
                    if (score == 284)
                    {
                        hub.Clients.Clients(clients).SendAsync("EndGame");
                    }

                    string som = (_pacman.position_x + 100).ToString() + "o" + (_pacman.position_y + 100).ToString();
                    ited_coin.Add((_pacman.position_x + 100).ToString() + "o" + (_pacman.position_y + 100).ToString());
                    
                }
                else if (_gameMap.CoinMap[_pacman.position_x, _pacman.position_y] == 'k')
                {
                    //score = score + 10;
                    bonus_score = 100;
                    
                    MakeGhostFrightened(blinky, BlinkyTimer);
                    
                    MakeGhostFrightened(pinky, PinkyTimer);

                    MakeGhostFrightened(clyde, ClydeTimer);

                    MakeGhostFrightened(inky, InkyTimer);

                    _gameMap.CoinMap[_pacman.position_x, _pacman.position_y] = ' ';
                }


                //pacman logic
                if (_gameMap.map[_pacman.position_x + _pacman.move_X, _pacman.position_y + _pacman.move_Y] != 'w')
                {
                    _pacman.position_x += _pacman.move_X;
                    _pacman.position_y += _pacman.move_Y;
                }

                // перевірка чи пакмен не натрапив на блінкі            
                CheckPacmanTouchGhost(blinky);

                // перевірка чи пакмен не натрапив на пінкі             
                CheckPacmanTouchGhost(pinky);

                // перевірка чи пакмен не натрапив на клуді
                CheckPacmanTouchGhost(clyde);

                // перевірка чи пакмен не натрапив на інкі
                CheckPacmanTouchGhost(inky);
                                

                hub.Clients.Clients(clients).SendAsync("ChangePacmanPosition", _pacman.position_x, _pacman.position_y, score * 10 + sum_bonus_score);

            }

        }

        public void UpdateInky(object state)
        {
            //inky_logic
            if (inky.IsMoving)
            {
                if (inky.MovingToHome)
                {
                    inky.IsFrightened = false;

                    InkyTimer.Change(50, 50);
                    var qwerty = new Init().Inite(11, 14, inky.position_x, inky.position_y);

                    inky.move_X = qwerty.Item1;
                    inky.move_Y = qwerty.Item2;

                    if ((inky.position_x == 11) && (inky.position_y == 14))
                    {
                        inky.MovingToHome = false;
                        InkyTimer.Change(120, 120);
                    }

                }
                else if (!inky.IsFrightened)
                {
                    if (inky.PersecutionOrRunaway)
                    {
                        inky.finish_point_x = inky.run_point_x;
                        inky.finish_point_y = inky.run_point_y;

                    }
                    else if (!inky.PersecutionOrRunaway)
                    {
                        int x = 0;
                        int y = 0;

                        if (_gameMap.map[_pacman.position_x + _pacman.move_X,_pacman.position_y + _pacman.move_Y] != 'w')
                        {
                            inky.pacman_position_plus_two_x = _pacman.position_x + _pacman.move_X;
                            inky.pacman_position_plus_two_y = _pacman.position_y + _pacman.move_Y;
                        }
                        try
                        {
                            if (_gameMap.map[_pacman.position_x + _pacman.move_X + _pacman.move_X, _pacman.position_y + _pacman.move_Y + _pacman.move_Y] != 'w')
                            {
                                inky.pacman_position_plus_two_x = _pacman.position_x + _pacman.move_X + _pacman.move_X;
                                inky.pacman_position_plus_two_y = _pacman.position_y + _pacman.move_Y + _pacman.move_Y;
                            }
                        }
                        catch
                        {
                            if (_gameMap.map[_pacman.position_x + _pacman.move_X, _pacman.position_y + _pacman.move_Y] != 'w')
                            {
                                inky.pacman_position_plus_two_x = _pacman.position_x + _pacman.move_X;
                                inky.pacman_position_plus_two_y = _pacman.position_y + _pacman.move_Y;
                            }
                            else
                            {
                                inky.pacman_position_plus_two_x = _pacman.position_x;
                                inky.pacman_position_plus_two_y = _pacman.position_y;
                            }
                        }

                        if (inky.pacman_position_plus_two_x <= blinky.position_x)
                        {
                            x = blinky.position_x - inky.pacman_position_plus_two_x;

                            if (inky.pacman_position_plus_two_y <= blinky.position_y)
                            {
                                y = blinky.position_y - inky.pacman_position_plus_two_y;

                                if (x == y)
                                {
                                    inky.finish_point_x = inky.pacman_position_plus_two_x;

                                    inky.finish_point_y = inky.pacman_position_plus_two_y;
                                }
                                else if (x > y)
                                {
                                    int step = 0;
                                    while (step != x + 1)
                                    {
                                        double kof = (((step) * 100) / x);
                                        double newy = kof / 100 * y;

                                        try
                                        {
                                            if (_gameMap.map[(inky.pacman_position_plus_two_x - step), Convert.ToInt32(inky.pacman_position_plus_two_y - newy)] != 'w')
                                            {
                                                inky.finish_point_x = inky.pacman_position_plus_two_x - step;

                                                inky.finish_point_y = Convert.ToInt32(inky.pacman_position_plus_two_y - newy);
                                            }
                                        }
                                        catch
                                        {
                                            step = x;
                                        }
                                        step++;
                                    }
                                }
                                else if (x < y)
                                {
                                    int step = 0;
                                    while (step != y + 1)
                                    {
                                        double kof = (((step) * 100) / y);
                                        double newx = kof / 100 * x;

                                        try
                                        {
                                            if (_gameMap.map[Convert.ToInt32(inky.pacman_position_plus_two_x - newx), inky.pacman_position_plus_two_y - step] != 'w')
                                            {
                                                inky.finish_point_x = Convert.ToInt32(inky.pacman_position_plus_two_x - newx);

                                                inky.finish_point_y = inky.pacman_position_plus_two_y - step;
                                            }
                                        }
                                        catch
                                        {
                                            step = y;
                                        }
                                        step++;
                                    }

                                }

                            }
                            else if (inky.pacman_position_plus_two_y > blinky.position_y)
                            {
                                y = inky.pacman_position_plus_two_y - blinky.position_y;

                                if (x >= y)
                                {
                                    int step = 0;
                                    while (step != x + 1)
                                    {
                                        double kof = (((step) * 100) / x);
                                        double newy = kof / 100 * y;

                                        try
                                        {
                                            if (_gameMap.map[(inky.pacman_position_plus_two_x - step), Convert.ToInt32(inky.pacman_position_plus_two_y + newy)] != 'w')
                                            {
                                                inky.finish_point_x = inky.pacman_position_plus_two_x - step;

                                                inky.finish_point_y = Convert.ToInt32(inky.pacman_position_plus_two_y + newy);
                                            }
                                        }
                                        catch
                                        {
                                            step = x;
                                        }
                                        step++;
                                    }
                                }
                                else if (x < y)
                                {
                                    int step = 0;
                                    while (step != y + 1)
                                    {
                                        double kof = (((step) * 100) / y);
                                        double newx = kof / 100 * x;

                                        try
                                        {
                                            if (_gameMap.map[Convert.ToInt32(inky.pacman_position_plus_two_x - newx), inky.pacman_position_plus_two_y + step] != 'w')
                                            {
                                                inky.finish_point_x = Convert.ToInt32(inky.pacman_position_plus_two_x - newx);

                                                inky.finish_point_y = inky.pacman_position_plus_two_y + step;
                                            }
                                        }
                                        catch
                                        {
                                            step = y;
                                        }
                                        step++;
                                    }
                                }
                            }
                        }
                        else if (inky.pacman_position_plus_two_x > blinky.position_x)
                        {
                            x = inky.pacman_position_plus_two_x - blinky.position_x;

                            if (inky.pacman_position_plus_two_y <= blinky.position_y)
                            {
                                y = blinky.position_y - inky.pacman_position_plus_two_y;

                                if (x >= y)
                                {
                                    int step = 0;
                                    while (step != x + 1)
                                    {
                                        double kof = (((step) * 100) / x);
                                        double newy = kof / 100 * y;

                                        try
                                        {
                                            if (_gameMap.map[(inky.pacman_position_plus_two_x + step), Convert.ToInt32(inky.pacman_position_plus_two_y - newy)] != 'w')
                                            {
                                                inky.finish_point_x = inky.pacman_position_plus_two_x + step;

                                                inky.finish_point_y = Convert.ToInt32(inky.pacman_position_plus_two_y - newy);
                                            }
                                        }
                                        catch
                                        {
                                            step = x;
                                        }
                                        step++;
                                    }
                                }
                                else if (x < y)
                                {
                                    int step = 0;
                                    while (step != y + 1)
                                    {
                                        double kof = (((step) * 100) / y);
                                        double newx = kof / 100 * x;

                                        try
                                        {
                                            if (_gameMap.map[Convert.ToInt32(inky.pacman_position_plus_two_x + newx), inky.pacman_position_plus_two_y - step] != 'w')
                                            {
                                                inky.finish_point_x = Convert.ToInt32(inky.pacman_position_plus_two_x + newx);

                                                inky.finish_point_y = inky.pacman_position_plus_two_y - step;
                                            }
                                        }
                                        catch
                                        {
                                            step = y;
                                        }
                                        step++;
                                    }

                                }
                            }
                            else if (inky.pacman_position_plus_two_y > blinky.position_y)
                            {
                                y = inky.pacman_position_plus_two_y - blinky.position_y;

                                if (x >= y)
                                {
                                    int step = 0;
                                    while (step != x + 1)
                                    {
                                        double kof = (((step) * 100) / x);
                                        double newy = kof / 100 * y;

                                        try
                                        {
                                            if (_gameMap.map[(inky.pacman_position_plus_two_x + step), Convert.ToInt32(inky.pacman_position_plus_two_y + newy)] != 'w')
                                            {
                                                inky.finish_point_x = inky.pacman_position_plus_two_x + step;

                                                inky.finish_point_y = Convert.ToInt32(inky.pacman_position_plus_two_y + newy);
                                            }
                                        }
                                        catch
                                        {
                                            step = x;
                                        }
                                        step++;
                                    }
                                }
                                else if (x < y)
                                {
                                    int step = 0;
                                    while (step != y + 1)
                                    {
                                        double kof = (((step) * 100) / y);
                                        double newx = kof / 100 * x;

                                        try
                                        {
                                            if (_gameMap.map[Convert.ToInt32(inky.pacman_position_plus_two_x + newx), inky.pacman_position_plus_two_y + step] != 'w')
                                            {
                                                inky.finish_point_x = Convert.ToInt32(inky.pacman_position_plus_two_x + newx);

                                                inky.finish_point_y = inky.pacman_position_plus_two_y + step;
                                            }
                                        }
                                        catch
                                        {
                                            step = y;
                                        }
                                        step++;
                                    }

                                }
                            }
                        }

                    }

                    if (inky.TimerType)
                    {
                        InkyTimer.Change(120, 120);
                        inky.TimerType = false;
                    }

                    // визначення напрямку через граф
                    if (_gameMap.map[inky.position_x, inky.position_y] == 'c')
                    {
                        try
                        {
                            var qwerty = new Init().Inite2(inky.finish_point_x, inky.finish_point_y, inky.position_x, inky.position_y, inky.move_X, inky.move_Y);
                            inky.move_X = qwerty.Item1;
                            inky.move_Y = qwerty.Item2;
                        }
                        catch { }
                        
                          
                    }

                }
                else
                {
                    // блінкі переходить у режим страху: зменшення швидкості, миттєво змінює напрямок, випадково визначає напрямок руху
                    if (_gameMap.map[inky.position_x, inky.position_y] == 'c')
                    {
                        inky.RandomMove();                      
                        inky.TimerType = true;
                    }
                }


                if (_gameMap.map[inky.position_x + inky.move_X, inky.position_y + inky.move_Y] != 'w')
                {
                    inky.position_x += inky.move_X;
                    inky.position_y += inky.move_Y;
                }

                // перевірка чи гост не зловив пакмена
                CheckPacmanTouchGhost(inky);


                hub.Clients.Clients(clients).SendAsync("ChangeInkyPosition", inky.position_x, inky.position_y, inky.IsFrightened, inky.MovingToHome);
            }
        }

        public void UpdateCloudy(object state)
        {
            if (clyde.IsMoving)
            {
                //Clyde logic
                if (clyde.MovingToHome)
                {
                    clyde.IsFrightened = false;

                    ClydeTimer.Change(50, 50);
                    var qwerty = new Init().Inite(11, 14, clyde.position_x, clyde.position_y);

                    clyde.move_X = qwerty.Item1;
                    clyde.move_Y = qwerty.Item2;

                    if ((clyde.position_x == 11) && (clyde.position_y == 14))
                    {
                        clyde.MovingToHome = false;
                        ClydeTimer.Change(120, 120);
                    }

                }
                else if (!clyde.IsFrightened)
                {
                    if (clyde.PersecutionOrRunaway)
                    {
                        //рух в кут, в точку розбігання
                        clyde.finish_point_x = clyde.run_point_x;
                        clyde.finish_point_y = clyde.run_point_y;
                    }
                    else if (!clyde.PersecutionOrRunaway)
                    {
                        // переслідування пакмена
                        if (_gameMap.map[clyde.position_x, clyde.position_y] == 'c')
                        {
                            int shot_way;

                            shot_way = new Init().Shortest_way(_pacman.position_x, _pacman.position_y, clyde.position_x, clyde.position_y, clyde.move_X, clyde.move_Y);
                            
                            if (shot_way <= 15)
                            {
                                clyde.finish_point_x = clyde.run_point_x;
                                clyde.finish_point_y = clyde.run_point_y;
                            }
                            else
                            {
                                clyde.finish_point_x = _pacman.position_x;
                                clyde.finish_point_y = _pacman.position_y;
                            }
                        }
                    }

                    if (clyde.TimerType)
                    {
                        ClydeTimer.Change(120, 120);
                        clyde.TimerType = false;
                    }

                    if (_gameMap.map[clyde.position_x, clyde.position_y] == 'c')
                    {                       
                        var qwerty = new Init().Inite2(clyde.finish_point_x, clyde.finish_point_y, clyde.position_x, clyde.position_y, clyde.move_X, clyde.move_Y);
                        clyde.move_X = qwerty.Item1;
                        clyde.move_Y = qwerty.Item2;
                         
                    }
                }
                else
                {
                    // клуді переходить у режим страху: зменшення швидкості, миттєво змінює напрямок, випадково визначає напрямок руху
                    if (_gameMap.map[clyde.position_x, clyde.position_y] == 'c')
                    {
                        clyde.RandomMove();
                       
                        clyde.TimerType = true;
                    }
                }

                clyde.position_x += clyde.move_X;
                clyde.position_y += clyde.move_Y;

                // перевірка чи клуді не зловив пакмена
                CheckPacmanTouchGhost(clyde);

                hub.Clients.Clients(clients).SendAsync("ChangeClydePosition", clyde.position_x, clyde.position_y, clyde.IsFrightened, clyde.MovingToHome);
            }
        }

        private void UpdatePinky(object state)
        {           
            if (pinky.IsMoving)
            {
                if (pinky.MovingToHome)
                {
                    pinky.IsFrightened = false;

                    PinkyTimer.Change(50, 50);
                    var qwerty = new Init().Inite(11, 14, pinky.position_x, pinky.position_y);

                    pinky.move_X = qwerty.Item1;
                    pinky.move_Y = qwerty.Item2;

                    if ((pinky.position_x == 11) && (pinky.position_y == 14))
                    {
                        pinky.MovingToHome = false;
                        PinkyTimer.Change(120, 120);
                    }

                }
                else if (!pinky.IsFrightened)
                {
                    //pinky_logic
                    if (pinky.PersecutionOrRunaway)
                    {
                        pinky.finish_point_x = pinky.run_point_x;
                        pinky.finish_point_y = pinky.run_point_y;

                    }
                    else if (!pinky.PersecutionOrRunaway)
                    {
                        pinky.finish_point_x = _pacman.position_x;
                        pinky.finish_point_y = _pacman.position_y;

                        for (int i = 0; i < 4; i++)
                        {
                            if ((_gameMap.map[pinky.finish_point_x + _pacman.move_X, pinky.finish_point_y + _pacman.move_Y] != 'w'))
                            {
                                pinky.finish_point_x += _pacman.move_X;
                                pinky.finish_point_y += _pacman.move_Y;
                            }
                        }
                    }

                    if (pinky.TimerType)
                    {
                        PinkyTimer.Change(120, 120);
                        pinky.TimerType = false;
                    }

                    if (_gameMap.map[pinky.position_x, pinky.position_y] == 'c')
                    {                        
                        var qwerty = new Init().Inite2(pinky.finish_point_x, pinky.finish_point_y, pinky.position_x, pinky.position_y, pinky.move_X, pinky.move_Y);

                        pinky.move_X = qwerty.Item1;
                        pinky.move_Y = qwerty.Item2;
                        
                    }

                }
                else if (pinky.IsFrightened)
                {
                    // пінкі переходить у режим страху: зменшення швидкості, миттєво змінює напрямок, випадково визначає напрямок руху
                    if (_gameMap.map[pinky.position_x, pinky.position_y] == 'c')
                    {
                        pinky.RandomMove();                        
                        pinky.TimerType = true;
                    }
                }
               
                if (_gameMap.map[pinky.position_x + pinky.move_X, pinky.position_y + pinky.move_Y] != 'w')
                {
                    pinky.position_x += pinky.move_X;
                    pinky.position_y += pinky.move_Y;
                }

                // перевірка чи пінкі не зловив пакмена               
                CheckPacmanTouchGhost(pinky);


                hub.Clients.Clients(clients).SendAsync("ChangePinkyPosition", pinky.position_x, pinky.position_y, pinky.IsFrightened, pinky.MovingToHome);
            }
        }

        private void UpdateBlinky(object state)
        {      
            //blinky_logic
            if (blinky.IsMoving)
            {
                if (blinky.MovingToHome)
                {
                    blinky.IsFrightened = false;
                    
                    BlinkyTimer.Change(50, 50);
                    var qwerty = new Init().Inite(11,14,blinky.position_x,blinky.position_y);

                    blinky.move_X = qwerty.Item1;
                    blinky.move_Y = qwerty.Item2;

                    if ((blinky.position_x == 11) && (blinky.position_y == 14))
                    {
                        blinky.MovingToHome = false;
                        BlinkyTimer.Change(120, 120);
                    }

                }
                else if(!blinky.IsFrightened)
                {
                    if (blinky.PersecutionOrRunaway)
                    {
                        blinky.finish_point_x = blinky.run_point_x;
                        blinky.finish_point_y = blinky.run_point_y;

                    }
                    else if (!blinky.PersecutionOrRunaway)
                    {
                        blinky.finish_point_x = _pacman.position_x;
                        blinky.finish_point_y = _pacman.position_y;
                    }

                    if (blinky.TimerType)
                    {
                        BlinkyTimer.Change(120, 120);
                        blinky.TimerType = false;
                    }

                    // визначення напрямку через граф
                    if (_gameMap.map[blinky.position_x, blinky.position_y] == 'c')
                    {
                        var qwerty = new Init().Inite2(blinky.finish_point_x, blinky.finish_point_y, blinky.position_x, blinky.position_y, blinky.move_X, blinky.move_Y);

                        blinky.move_X = qwerty.Item1;
                        blinky.move_Y = qwerty.Item2;
                        
                    }

                }
                else if (blinky.IsFrightened)
                {
                    // блінкі переходить у режим страху: зменшення швидкості, миттєво змінює напрямок, випадково визначає напрямок руху
                    if (_gameMap.map[blinky.position_x, blinky.position_y] == 'c')
                    {
                        blinky.RandomMove();
                        
                        blinky.TimerType = true;
                    }
                }
               


                if (_gameMap.map[blinky.position_x + blinky.move_X, blinky.position_y + blinky.move_Y] != 'w')
                {
                    blinky.position_x += blinky.move_X;
                    blinky.position_y += blinky.move_Y;
                }

                // перевірка чи пінкі не зловив пакмена     
                CheckPacmanTouchGhost(blinky);

                hub.Clients.Clients(clients).SendAsync("ChangeBlinkyPosition", blinky.position_x, blinky.position_y, blinky.IsFrightened, blinky.MovingToHome);
            }
        }
        
        public void Dispose()
        {
           
        }
    }
}
