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

        private GameMap _gameMap = new GameMap();

        private Pacman _pacman = new Pacman();

        private Blinky blinky;

        private Pinky pinky;

        private Clyde clyde;

        private Timer PacmanTimer, ClydeTimer, PinkyTimer, BlinkyTimer;

        private bool pause = false;

        private Init init = new Init();

        public string ConnectionID { get; set; }

        private IHubContext<GameHub> hub { get; set; }

        public Class(string connectionID, IHubContext<GameHub> hub)
        {
            this.ConnectionID = connectionID;
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

            start_time = DateTime.Now;
            PacmanTimer = new Timer(UpdatePacman, null, 0, 100);
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

                blinky.last_move_X = blinky.move_X;
                blinky.last_move_Y = blinky.move_Y;


                _pacman.move_X = 0;
                _pacman.move_Y = 0;

                blinky.move_X = 0;
                blinky.move_Y = 0;
                pause = true;
            }
            else
            {
                pause = false;
                _pacman.move_X = _pacman.last_move_X;
                _pacman.move_Y = _pacman.last_move_Y;

                blinky.move_X = blinky.last_move_X;
                blinky.move_Y = blinky.last_move_Y;
            }

          

            return Task.CompletedTask;
        }

        


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
                    if ((score >= 30)&&(pinky.IsMoving == false))
                    {
                        pinky.StartMoving();
                    }
                    if ((score >= 70) && (clyde.IsMoving == false))
                    {
                        clyde.StartMoving();
                    }
                    if (score == 284)
                    {
                        hub.Clients.Client(ConnectionID).SendAsync("EndGame");
                    }

                }
                else if (_gameMap.CoinMap[_pacman.position_x, _pacman.position_y] == 'k')
                {
                    //score = score + 10;
                    blinky.Frightened();
                    if (pinky.IsMoving)
                    {
                        pinky.Frightened();
                    }
                    if (clyde.IsMoving)
                    {
                        clyde.Frightened();
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
                        object a = new object();
                        blinky.FrightenedChange(a);
                        blinky.position_x = 11;
                        blinky.position_y = 13;
                        blinky.move_X = 0;
                        blinky.move_Y = -1;
                    }
                    else 
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 1;
                        _pacman.move_Y = 0;
                    }
                }

                // перевірка чи пакмен не натрапив на пінкі
                if ((_pacman.position_x == pinky.position_x) && (_pacman.position_y == pinky.position_y))
                {
                    if (pinky.IsFrightened == true)
                    {
                        object a = new object();
                        pinky.FrightenedChange(a);
                        pinky.position_x = 11;
                        pinky.position_y = 13;
                        pinky.move_X = 0;
                        pinky.move_Y = 1;
                    }
                    else
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 1;
                        _pacman.move_Y = 0;
                    }
                }

                // перевірка чи пакмен не натрапив на клуді
                if ((_pacman.position_x == clyde.position_x) && (_pacman.position_y == clyde.position_y))
                {
                    if (pinky.IsFrightened == true)
                    {
                        object a = new object();
                        clyde.FrightenedChange(a);
                        clyde.position_x = 11;
                        clyde.position_y = 13;
                        clyde.move_X = 0;
                        clyde.move_Y = 1;
                    }
                    else if (clyde.IsMoving)
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 1;
                        _pacman.move_Y = 0;
                    }
                }

                DateTime moment2 = DateTime.Now;

                hub.Clients.Client(ConnectionID).SendAsync("ChangePacmanPosition", _pacman.position_x, _pacman.position_y, score * 10);

            }

        }

        public void UpdateCloudy(object state)
        {
            if (clyde.IsMoving)
            {
                int length_to_left = 1;
                int length_to_right = 1;
                int length_to_top = 1;
                int length_to_bottom = 1;

                string pacman_left = "";
                string pacman_right = "";

                //Clyde logic
                if (!clyde.IsFrightened)
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

                            if (_gameMap.map[_pacman.position_x, _pacman.position_y] == 'c')
                            {
                                shot_way = new Init().Shortest_way(_pacman.position_x, _pacman.position_y, clyde.position_x, clyde.position_y, clyde.move_X, clyde.move_Y);

                            }
                            else
                            {
                                if (_pacman.move_Y == 1 || _pacman.move_Y == -1)
                                {
                                    while ((_gameMap.map[_pacman.position_x, _pacman.position_y - length_to_left] == ' '))
                                    {
                                        length_to_left++;
                                    }

                                    while ((_gameMap.map[_pacman.position_x, _pacman.position_y + length_to_right] == ' '))
                                    {
                                        length_to_right++;
                                    }

                                    pacman_left = (_pacman.position_x + 100).ToString() + "_" + (_pacman.position_y + length_to_right + 100).ToString();
                                    pacman_right = (_pacman.position_x + 100).ToString() + "_" + (_pacman.position_y - length_to_left + 100).ToString();

                                    shot_way = new Init().Shortest_way2(_pacman.position_x, _pacman.position_y, pacman_left, pacman_right, length_to_left, length_to_right, clyde.position_x, clyde.position_y, clyde.move_X, clyde.move_Y);

                                }
                                else
                                {
                                    while ((_gameMap.map[_pacman.position_x - length_to_top, _pacman.position_y] == ' '))
                                    {
                                        length_to_top++;
                                    }

                                    while ((_gameMap.map[_pacman.position_x + length_to_bottom, _pacman.position_y] == ' '))
                                    {
                                        length_to_bottom++;
                                    }


                                    pacman_left = (_pacman.position_x + 100 - length_to_top).ToString() + "_" + (_pacman.position_y + 100).ToString();
                                    pacman_right = (_pacman.position_x + 100 + length_to_bottom).ToString() + "_" + (_pacman.position_y + 100).ToString();

                                    shot_way = new Init().Shortest_way2(_pacman.position_x, _pacman.position_y, pacman_left, pacman_right, length_to_top, length_to_bottom, clyde.position_x, clyde.position_y, clyde.move_X, clyde.move_Y);

                                }


                            }

                            length_to_left = 1;
                            length_to_right = 1;
                            length_to_bottom = 1;
                            length_to_top = 1;

                            if (shot_way <= 12)
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
                        if (_gameMap.map[clyde.finish_point_x, clyde.finish_point_y] == 'c')
                        {
                            try
                            {
                                var qwerty = new Init().Inite2(clyde.finish_point_x, clyde.finish_point_y, clyde.position_x, clyde.position_y, clyde.move_X, clyde.move_Y);
                                clyde.move_X = qwerty.Item1;
                                clyde.move_Y = qwerty.Item2;
                            }
                            catch (Exception)
                            {

                                throw;
                            }


                            //hub.Clients.Client(ConnectionID).SendAsync("SendSomeThing", qwerty.Item1, qwerty.Item2);
                        }
                        else
                        {
                            if (_pacman.move_Y == 1 || _pacman.move_Y == -1)
                            {
                                while ((_gameMap.map[_pacman.position_x, _pacman.position_y - length_to_left] == ' '))
                                {
                                    length_to_left++;
                                }

                                while ((_gameMap.map[_pacman.position_x, _pacman.position_y + length_to_right] == ' '))
                                {
                                    length_to_right++;
                                }

                                pacman_left = (_pacman.position_x + 100).ToString() + "_" + (_pacman.position_y + length_to_right + 100).ToString();
                                pacman_right = (_pacman.position_x + 100).ToString() + "_" + (_pacman.position_y - length_to_left + 100).ToString();

                                var qwerty = new Init().Inite(_pacman.position_x, _pacman.position_y, pacman_left, pacman_right, length_to_left, length_to_right, clyde.position_x, clyde.position_y, clyde.move_X, clyde.move_Y);

                                clyde.move_X = qwerty.Item1;
                                clyde.move_Y = qwerty.Item2;
                                //hub.Clients.Client(ConnectionID).SendAsync("SendSomeThing", qwerty.Item1, qwerty.Item2);


                            }
                            else
                            {
                                while ((_gameMap.map[_pacman.position_x - length_to_top, _pacman.position_y] == ' '))
                                {
                                    length_to_top++;
                                }

                                while ((_gameMap.map[_pacman.position_x + length_to_bottom, _pacman.position_y] == ' '))
                                {
                                    length_to_bottom++;
                                }


                                pacman_left = (_pacman.position_x + 100 - length_to_top).ToString() + "_" + (_pacman.position_y + 100).ToString();
                                pacman_right = (_pacman.position_x + 100 + length_to_bottom).ToString() + "_" + (_pacman.position_y + 100).ToString();

                                var qwerty = new Init().Inite(_pacman.position_x, _pacman.position_y, pacman_left, pacman_right, length_to_top, length_to_bottom, clyde.position_x, clyde.position_y, clyde.move_X, clyde.move_Y);

                                clyde.move_X = qwerty.Item1;
                                clyde.move_Y = qwerty.Item2;

                                //hub.Clients.Client(ConnectionID).SendAsync("SendSomeThing", qwerty.Item1, qwerty.Item2);

                            }


                        }

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
                    if (pinky.IsFrightened == true)
                    {
                        object a = new object();
                        clyde.FrightenedChange(a);
                        clyde.position_x = 11;
                        clyde.position_y = 13;
                        clyde.move_X = 0;
                        clyde.move_Y = 1;
                    }
                    else if (clyde.IsMoving)
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 1;
                        _pacman.move_Y = 0;
                    }
                }

                hub.Clients.Client(ConnectionID).SendAsync("ChangeClydePosition", clyde.position_x, clyde.position_y, clyde.IsFrightened);
            }
        }

        private void UpdatePinky(object state)
        {           
            if (pinky.IsMoving)
            {
                int length_to_left = 1;
                int length_to_right = 1;
                int length_to_top = 1;
                int length_to_bottom = 1;

                string pacman_left = "";
                string pacman_right = "";

                if (!pinky.IsFrightened)
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
                        if (_gameMap.map[pinky.finish_point_x, pinky.finish_point_y] == 'c')
                        {
                            var qwerty = new Init().Inite2(pinky.finish_point_x, pinky.finish_point_y, pinky.position_x, pinky.position_y, pinky.move_X, pinky.move_Y);

                            pinky.move_X = qwerty.Item1;
                            pinky.move_Y = qwerty.Item2;
                            //hub.Clients.Client(ConnectionID).SendAsync("SendSomeThing", qwerty.Item1, qwerty.Item2);
                        }
                        else
                        {
                            if (_pacman.move_Y == 1 || _pacman.move_Y == -1)
                            {
                                while ((_gameMap.map[pinky.finish_point_x, pinky.finish_point_y - length_to_left] == ' '))
                                {
                                    length_to_left++;
                                }

                                while ((_gameMap.map[pinky.finish_point_x, pinky.finish_point_y + length_to_right] == ' '))
                                {
                                    length_to_right++;
                                }

                                pacman_left = (pinky.finish_point_x + 100).ToString() + "_" + (pinky.finish_point_y + length_to_right + 100).ToString();
                                pacman_right = (pinky.finish_point_x + 100).ToString() + "_" + (pinky.finish_point_y - length_to_left + 100).ToString();

                                var qwerty = new Init().Inite(pinky.finish_point_x, pinky.finish_point_y, pacman_left, pacman_right, length_to_left, length_to_right, pinky.position_x, pinky.position_y, pinky.move_X, pinky.move_Y);

                                pinky.move_X = qwerty.Item1;
                                pinky.move_Y = qwerty.Item2;
                                //hub.Clients.Client(ConnectionID).SendAsync("SendSomeThing", qwerty.Item1, qwerty.Item2);


                            }
                            else
                            {
                                while ((_gameMap.map[pinky.finish_point_x - length_to_top, pinky.finish_point_y] == ' '))
                                {
                                    length_to_top++;
                                }

                                while ((_gameMap.map[pinky.finish_point_x + length_to_bottom, pinky.finish_point_y] == ' '))
                                {
                                    length_to_bottom++;
                                }


                                pacman_left = (pinky.finish_point_x + 100 - length_to_top).ToString() + "_" + (pinky.finish_point_y + 100).ToString();
                                pacman_right = (pinky.finish_point_x + 100 + length_to_bottom).ToString() + "_" + (pinky.finish_point_y + 100).ToString();

                                var qwerty = new Init().Inite(pinky.finish_point_x, pinky.finish_point_y, pacman_left, pacman_right, length_to_top, length_to_bottom, pinky.position_x, pinky.position_y, pinky.move_X, pinky.move_Y);

                                pinky.move_X = qwerty.Item1;
                                pinky.move_Y = qwerty.Item2;

                                //hub.Clients.Client(ConnectionID).SendAsync("SendSomeThing", qwerty.Item1, qwerty.Item2);

                            }


                        }

                        length_to_left = 1;
                        length_to_right = 1;
                        length_to_bottom = 1;
                        length_to_top = 1;
                    }

                }
                else
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
                        object a = new object();
                        pinky.FrightenedChange(a);
                        pinky.position_x = 11;
                        pinky.position_y = 13;
                        pinky.move_X = 0;
                        pinky.move_Y = 1;
                    }
                    else
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 1;
                        _pacman.move_Y = 0;
                    }
                }
                
                hub.Clients.Client(ConnectionID).SendAsync("ChangePinkyPosition", pinky.position_x, pinky.position_y, pinky.IsFrightened);
            }
        }

        private void UpdateBlinky(object state)
        {      
            //blinky_logic
            if (blinky.IsMoving)
            {
                int length_to_left = 1;
                int length_to_right = 1;
                int length_to_top = 1;
                int length_to_bottom = 1;

                string pacman_left = "";
                string pacman_right = "";

                if (!blinky.IsFrightened)
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

                    

                    if (_gameMap.map[blinky.position_x, blinky.position_y] == 'c')
                    {
                        if (_gameMap.map[blinky.finish_point_x, blinky.finish_point_y] == 'c')
                        {
                            var qwerty = new Init().Inite2(blinky.finish_point_x, blinky.finish_point_y, blinky.position_x, blinky.position_y, blinky.move_X, blinky.move_Y);

                            blinky.move_X = qwerty.Item1;
                            blinky.move_Y = qwerty.Item2;
                            //hub.Clients.Client(ConnectionID).SendAsync("SendSomeThing", qwerty.Item1, qwerty.Item2);
                        }
                        else
                        {
                            if (_pacman.move_Y == 1 || _pacman.move_Y == -1)
                            {
                                while ((_gameMap.map[_pacman.position_x, _pacman.position_y - length_to_left] == ' '))
                                {
                                    length_to_left++;
                                }

                                while ((_gameMap.map[_pacman.position_x, _pacman.position_y + length_to_right] == ' '))
                                {
                                    length_to_right++;
                                }

                                pacman_left = (_pacman.position_x + 100).ToString() + "_" + (_pacman.position_y + length_to_right + 100).ToString();
                                pacman_right = (_pacman.position_x + 100).ToString() + "_" + (_pacman.position_y - length_to_left + 100).ToString();

                                var qwerty = new Init().Inite(_pacman.position_x, _pacman.position_y, pacman_left, pacman_right, length_to_left, length_to_right, blinky.position_x, blinky.position_y, blinky.move_X, blinky.move_Y);

                                blinky.move_X = qwerty.Item1;
                                blinky.move_Y = qwerty.Item2;
                                //hub.Clients.Client(ConnectionID).SendAsync("SendSomeThing", qwerty.Item1, qwerty.Item2);


                            }
                            else
                            {
                                while ((_gameMap.map[_pacman.position_x - length_to_top, _pacman.position_y] == ' '))
                                {
                                    length_to_top++;
                                }

                                while ((_gameMap.map[_pacman.position_x + length_to_bottom, _pacman.position_y] == ' '))
                                {
                                    length_to_bottom++;
                                }


                                pacman_left = (_pacman.position_x + 100 - length_to_top).ToString() + "_" + (_pacman.position_y + 100).ToString();
                                pacman_right = (_pacman.position_x + 100 + length_to_bottom).ToString() + "_" + (_pacman.position_y + 100).ToString();

                                var qwerty = new Init().Inite(_pacman.position_x, _pacman.position_y, pacman_left, pacman_right, length_to_top, length_to_bottom, blinky.position_x, blinky.position_y, blinky.move_X, blinky.move_Y);

                                blinky.move_X = qwerty.Item1;
                                blinky.move_Y = qwerty.Item2;

                                //hub.Clients.Client(ConnectionID).SendAsync("SendSomeThing", qwerty.Item1, qwerty.Item2);

                            }


                        }

                        length_to_left = 1;
                        length_to_right = 1;
                        length_to_bottom = 1;
                        length_to_top = 1;
                    }

                }
                else
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
                        object a = new object();
                        blinky.FrightenedChange(a);
                        blinky.position_x = 11;
                        blinky.position_y = 13;
                        blinky.move_X = 0;
                        blinky.move_Y = -1;
                    }
                    else
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 1;
                        _pacman.move_Y = 0;
                    }
                }

                hub.Clients.Client(ConnectionID).SendAsync("ChangeBlinkyPosition", blinky.position_x, blinky.position_y, blinky.IsFrightened);
            }
        }
        
        public void Dispose()
        {
           
        }
    }
}
