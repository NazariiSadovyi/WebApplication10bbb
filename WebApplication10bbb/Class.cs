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
    public class Class:IDisposable
    {
        public List<string> clients = new List<string>();

        public string UserName;

        const int height = 29;
        const int width = 26;

        private GameMap _gameMap = new GameMap();

        private Pacman _pacman = new Pacman();

        private Blinky blinky;

        private Pinky pinky;

        private Clyde clyde;

        private Inky inky;

        private Timer PacmanTimer, ClydeTimer, PinkyTimer, BlinkyTimer, InkyTimer;

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
            blinky = new Blinky();
            pinky = new Pinky();
            clyde = new Clyde();
            inky = new Inky();

            start_time = DateTime.Now;
            PacmanTimer = new Timer(UpdatePacman, null, 0, 100);
            InkyTimer = new Timer(UpdateInky, null, 0, 120);
            ClydeTimer = new Timer(UpdateCloudy, null, 0, 120);
            PinkyTimer = new Timer(UpdatePinky, null, 0, 120);
            BlinkyTimer = new Timer(UpdateBlinky, null, 0, 120);

            return Task.CompletedTask;
        }

        private int score;

        internal Task PauseGame()
        {
            if (pause == false)
            {
                _pacman.last_move_X = _pacman.move_X;
                _pacman.last_move_Y = _pacman.move_Y;
                              
                _pacman.move_X = 0;
                _pacman.move_Y = 0;

                blinky.IsMoving = false;
                if (blinky.IsFrightened)
                {
                    blinky.StopFrightened();
                }
                else
                {
                    blinky.StopPersecutionOrRunaway();
                }

                pinky.IsMoving = false;
                if (pinky.IsFrightened)
                {
                    pinky.StopFrightened();
                }
                else
                {
                    pinky.StopPersecutionOrRunaway();
                }


                inky.IsMoving = false;
                if (inky.IsFrightened)
                {
                    inky.StopFrightened();
                }
                else
                {
                    inky.StopPersecutionOrRunaway();
                }


                clyde.IsMoving = false;
                if (clyde.IsFrightened)
                {
                    clyde.StopFrightened();
                }
                else
                {
                    clyde.StopPersecutionOrRunaway();
                }

                pause = true;
            }
            else
            {
                pause = false;
                _pacman.move_X = _pacman.last_move_X;
                _pacman.move_Y = _pacman.last_move_Y;

                blinky.IsMoving = true;
                if (blinky.IsFrightened)
                {
                    blinky.ContinuousFrightened();
                }
                else
                {
                    blinky.ContinuousMoving();
                }

                pinky.IsMoving = true;
                if (pinky.IsFrightened)
                {
                    pinky.ContinuousFrightened();
                }
                else
                {
                    pinky.ContinuousMoving();
                }

                inky.IsMoving = true;
                if (inky.IsFrightened)
                {
                    inky.ContinuousFrightened();
                }
                else
                {
                    inky.ContinuousMoving();
                }

                clyde.IsMoving = true;
                if (clyde.IsFrightened)
                {
                    clyde.ContinuousFrightened();
                }
                else
                {
                    clyde.ContinuousMoving();
                }

            }

            return Task.CompletedTask;
        }

        List<string> ited_coin = new List<string>();

        DateTime start_time;
        DateTime current_time;
        
        bool m = true;
       


        private void UpdatePacman(object state)
        {
            DateTime moment = DateTime.Now;

            if (pause == false)
            {
                if (_gameMap.CoinMap[_pacman.position_x , _pacman.position_y ] == 'c')
                {
                    _gameMap.CoinMap[_pacman.position_x, _pacman.position_y] = ' ';
                    score++;
                    if (score == 1)
                    {
                        blinky.StartMoving();
                    }
                    if ((score == 10) && (pinky.IsMoving == false))
                    {
                        pinky.StartMoving();
                    }
                    if ((score == 30) && (clyde.IsMoving == false))
                    {
                        clyde.StartMoving();
                    }
                    if ((score == 30) && (inky.IsMoving == false))
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
                    if (blinky.IsFrightened)
                    {
                        blinky.FrightenedChange(new object());
                        blinky.Frightened();
                    }
                    else
                    {
                        blinky.Frightened();
                    }
                    
                    if (pinky.IsMoving)
                    {
                        if (pinky.IsFrightened)
                        {
                            pinky.FrightenedChange(new object());
                            pinky.Frightened();
                        }
                        else
                        {
                            pinky.Frightened();
                        }
                        
                    }

                    if (clyde.IsMoving)
                    {
                        if (clyde.IsFrightened)
                        {
                            clyde.FrightenedChange(new object());
                            clyde.Frightened();
                        }
                        else
                        {
                            clyde.Frightened();
                        }
                       
                    }

                    if (inky.IsMoving)
                    {
                        if (inky.IsFrightened)
                        {
                            inky.FrightenedChange(new object());
                            inky.Frightened();
                        }
                        else
                        {
                            inky.Frightened();
                        }
                        
                    }

                    _gameMap.CoinMap[_pacman.position_x, _pacman.position_y] = ' ';
                }


                //pacman logic
                if (_gameMap.map[_pacman.position_x + _pacman.move_X, _pacman.position_y + _pacman.move_Y] != 'w')
                {
                    _pacman.position_x += _pacman.move_X;
                    _pacman.position_y += _pacman.move_Y;
                }

                // перевірка чи пакмен не натрапив на блінкі
                if ((_pacman.position_x == blinky.position_x) && (_pacman.position_y == blinky.position_y))
                {
                    if (blinky.IsFrightened == true)
                    {
                        blinky.FrightenedChange(new object());
                        blinky.MovingToHome = true;
                    }
                    else if ((blinky.IsFrightened == false) && (blinky.MovingToHome == false))
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 0;
                        _pacman.move_Y = 1;
                    }
                }

                // перевірка чи пакмен не натрапив на пінкі
                if ((_pacman.position_x == pinky.position_x) && (_pacman.position_y == pinky.position_y))
                {
                    if (pinky.IsFrightened == true)
                    {
                        pinky.FrightenedChange(new object());
                        pinky.MovingToHome = true;
                    }
                    else if ((pinky.IsFrightened == false) && (pinky.MovingToHome == false))
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 0;
                        _pacman.move_Y = 1;
                    }
                }

                // перевірка чи пакмен не натрапив на клуді
                if ((_pacman.position_x == clyde.position_x) && (_pacman.position_y == clyde.position_y))
                {
                    if (clyde.IsFrightened == true)
                    {
                        clyde.FrightenedChange(new object());
                        clyde.MovingToHome = true;
                    }
                    else if ((clyde.IsFrightened == false) && (clyde.MovingToHome == false))
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 0;
                        _pacman.move_Y = 1;
                    }
                }

                if ((_pacman.position_x == inky.position_x) && (_pacman.position_y == inky.position_y))
                {
                    if (inky.IsFrightened == true)
                    {
                        inky.FrightenedChange(new object());
                        inky.MovingToHome = true;
                    }
                    else if ((inky.IsFrightened == false) && (inky.MovingToHome == false))
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 0;
                        _pacman.move_Y = 1;
                    }
                }


                DateTime moment2 = DateTime.Now;

                hub.Clients.Clients(clients).SendAsync("ChangePacmanPosition", _pacman.position_x, _pacman.position_y, score * 10, 1);

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
                        catch { }

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
                        var qwerty = new Init().Inite2(inky.finish_point_x, inky.finish_point_y, inky.position_x, inky.position_y, inky.move_X, inky.move_Y);

                        inky.move_X = qwerty.Item1;
                        inky.move_Y = qwerty.Item2;
                          
                    }

                }
                else
                {
                    // блінкі переходить у режим страху: зменшення швидкості, миттєво змінює напрямок, випадково визначає напрямок руху
                    if (_gameMap.map[inky.position_x, inky.position_y] == 'c')
                    {
                        inky.RandomMove();
                        InkyTimer.Change(300, 300);
                        inky.TimerType = true;
                    }
                }


                if (_gameMap.map[inky.position_x + inky.move_X, inky.position_y + inky.move_Y] != 'w')
                {
                    inky.position_x += inky.move_X;
                    inky.position_y += inky.move_Y;
                }

                // перевірка чи гост не зловив пакмена
                if ((_pacman.position_x == inky.position_x) && (_pacman.position_y == inky.position_y))
                {
                    if (inky.IsFrightened == true)
                    {
                        inky.FrightenedChange(new object());
                        inky.MovingToHome = true;
                    }
                    else if ((inky.IsFrightened == false) && (inky.MovingToHome == false))
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 1;
                        _pacman.move_Y = 0;
                    }
                }

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
                        //рух в кут в точку розбігання
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
                        ClydeTimer.Change(300, 300);
                        clyde.TimerType = true;
                    }
                }

                clyde.position_x += clyde.move_X;
                clyde.position_y += clyde.move_Y;

                // перевірка чи клуді не зловив пакмена
                if ((_pacman.position_x == clyde.position_x) && (_pacman.position_y == clyde.position_y))
                {
                    if (clyde.IsFrightened == true)
                    {
                        clyde.FrightenedChange(new object());
                        clyde.MovingToHome = true;
                    }
                    else if ((clyde.IsFrightened == false) && (clyde.MovingToHome == false))
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 1;
                        _pacman.move_Y = 0;
                    }
                }

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
                        PinkyTimer.Change(300, 300);
                        pinky.TimerType = true;
                    }
                }
               
                if (_gameMap.map[pinky.position_x + pinky.move_X, pinky.position_y + pinky.move_Y] != 'w')
                {
                    pinky.position_x += pinky.move_X;
                    pinky.position_y += pinky.move_Y;
                }

                // перевірка чи пінкі не зловив пакмена
                if ((_pacman.position_x == pinky.position_x) && (_pacman.position_y == pinky.position_y))
                {
                    if (pinky.IsFrightened == true)
                    {
                        pinky.FrightenedChange(new object());
                        pinky.MovingToHome = true;
                    }
                    else if ((pinky.IsFrightened == false) && (pinky.MovingToHome == false))
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 1;
                        _pacman.move_Y = 0;
                    }
                }

                hub.Clients.Clients(clients).SendAsync("ChangePinkyPosition", pinky.position_x, pinky.position_y, pinky.IsFrightened);
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
                        BlinkyTimer.Change(300,300);
                        blinky.TimerType = true;
                    }
                }
               


                if (_gameMap.map[blinky.position_x + blinky.move_X, blinky.position_y + blinky.move_Y] != 'w')
                {
                    blinky.position_x += blinky.move_X;
                    blinky.position_y += blinky.move_Y;
                }

                // перевірка чи гост не зловив пакмена
                if ((_pacman.position_x == blinky.position_x) && (_pacman.position_y == blinky.position_y))
                {
                    if (blinky.IsFrightened == true)
                    {
                        blinky.FrightenedChange(new object());
                        blinky.MovingToHome = true;
                    }
                    else if ((blinky.IsFrightened == false) && (blinky.MovingToHome == false))
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 0;
                        _pacman.move_Y = 1;
                    }
                }

                hub.Clients.Clients(clients).SendAsync("ChangeBlinkyPosition", blinky.position_x, blinky.position_y, blinky.IsFrightened, blinky.MovingToHome, blinky.PersecutionOrRunawayWatch.ElapsedMilliseconds.ToString(), blinky.IsFrightenedWatch.ElapsedMilliseconds.ToString());
            }
        }
        
        public void Dispose()
        {
           
        }
    }
}
