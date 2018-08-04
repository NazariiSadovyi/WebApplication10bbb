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

        Timer UserRemoveTimer;

        internal void Disconnected(string connectionId, string username)
        {
            try
            {   
                dict[username].clients.Remove(connectionId);
                dict[username].PauseGame();
                dict[username].stopwatch.Restart();
                
            }
            catch (Exception)
            {
                
            }
           
        }

        private void DeleteUser(object state)
        {
            if (dict != null)
            {
                try
                {
                    foreach (var item in dict)
                    {
                        if ((item.Value.clients.Count == 0) && (item.Value.stopwatch.ElapsedMilliseconds > 50000))
                        {
                            dict[item.Key].Dispose();
                            dict.Remove(item.Key);
                        }
                    }
                }
                catch { }
            }
        }

        private IHubContext<GameHub> Hub { get; set; }            

        public GameLogic(IHubContext<GameHub> hub)
        {
            Hub = hub;
            UserRemoveTimer = new Timer(DeleteUser, null, 60000, 60000);
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



        internal Task StartGame(string username, string con_id)
        {            
            if (dict[username].IsGameStarted == false)
            {
                dict[username].StartGame();
                dict[username].IsGameStarted = true;
                dict[username].stopwatch.Stop();
            }
            else
            {
                dict[username].StartNewGame();
                dict[username].stopwatch.Stop();
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
                try
                {
                   
                    if (dict.ContainsKey(username))
                    {
                        dict[username].clients.Add(connectionId);
                        dict[username].ContGameAfterReconect();
                    }
                    else
                    {
                        dict.Add(username, new Class(connectionId, Hub));
                    }
                    
                }
                catch { }
            }
            
        }

    }
}
