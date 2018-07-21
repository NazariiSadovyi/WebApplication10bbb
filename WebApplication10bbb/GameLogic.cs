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

        internal void Disconnected(string connectionId)
        {
            try
            {
                foreach (var item in dict)
                {
                    if (item.Key == connectionId)
                    {
                        item.Value.Dispose();
                        dict.Remove(connectionId);
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

        internal Task Move(int move,string connectionId)
        {
            foreach (var item in dict)
            {
                if (item.Key == connectionId)
                {
                    item.Value.Move(move);
                }
            }
            
            return Task.CompletedTask;
        }

        internal Task StartGame(string connectionId)
        {
            foreach (var item in dict)
            {
                if (item.Key == connectionId)
                {
                    item.Value.StartGame();
                }
            }
            
            return Task.CompletedTask;
        }
        
        internal Task PauseGame(string connectionId)
        {
            foreach (var item in dict)
            {
                if (item.Key == connectionId)
                {
                    item.Value.PauseGame();
                }
            }

            return Task.CompletedTask;
        }

        List<string> ta = new List<string>();

        Dictionary<string, Class> dict = new Dictionary<string, Class>();

        public void Connected(string connectionId)
        {
            if (ta.Contains(connectionId))
            {
                
            }
            else
            {
                dict.Add(connectionId, new Class(connectionId, Hub));
            }
        }

    }
}
