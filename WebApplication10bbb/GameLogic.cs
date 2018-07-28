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
    public class GameLogic
    {
        public List<string> clients = new List<string>();

        private GameMap _gameMap = new GameMap();

        private Pacman _pacman = new Pacman();

        private Blinky blinky = new Blinky();

        internal void Disconnected(string connectionId, string username)
        {
            try
            {
                foreach (var item in dict)
                {
                    if (item.Key == username)
                    {                        
                        if (item.Value.clients.Count == 1)
                        {
                            dict.Remove(username);
                        } 
                        else
                        {
                            item.Value.clients.Remove(connectionId);
                        }
                    }
                }

            }
            catch (Exception)
            {
                
            }
           
        }

        private IHubContext<GameHub> Hub { get; set; }            

        public GameLogic(IHubContext<GameHub> hub)
        {
            Hub = hub;
        }

        internal Task Move(int move,string username)
        {
            foreach (var item in dict)
            {
                if (item.Key == username)
                {
                    item.Value.Move(move);
                }
            }
            
            return Task.CompletedTask;
        }

        internal Task StartGame(string username)
        {
            foreach (var item in dict)
            {
                if (item.Key == username)
                {
                    item.Value.StartGame();
                }
            }
            
            return Task.CompletedTask;
        }
        
        internal Task PauseGame(string username)
        {
            foreach (var item in dict)
            {
                if (item.Key == username)
                {
                    item.Value.PauseGame();
                }
            }

            return Task.CompletedTask;
        }

        List<string> ta = new List<string>();

        Dictionary<string, Class> dict = new Dictionary<string, Class>();

        public void Connected(string connectionId, string username)
        {
            if (dict.Count == 0)
            {
                dict.Add(username, new Class(connectionId, Hub));
            }
            else
            {
                foreach (var item in dict)
                {
                    if (item.Key == username)
                    {
                        item.Value.clients.Add(connectionId);
                    }
                    else
                    {
                        dict.Add(username, new Class(connectionId, Hub));
                    }
                }
            }
            
        }

    }
}
