using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebApplication10bbb
{
    [Authorize]
    public class GameHub:Hub
    {
        private readonly GameLogic _gameLogic;
            
        public GameHub(GameLogic gameLogic)
        {
            _gameLogic = gameLogic;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _gameLogic.Disconnected(Context.ConnectionId.ToString(), Context.User.Identity.Name);
            
            return base.OnDisconnectedAsync(exception);
        }


        public override Task OnConnectedAsync()
        {
            //var frt = Context.User.Identity.Name;
            _gameLogic.Connected(Context.ConnectionId, Context.User.Identity.Name);
            return base.OnConnectedAsync();
        }

        public async Task MovePacmen(int move)
        {
            await _gameLogic.Move(move, Context.User.Identity.Name);            
        }

        public async Task Pause()
        {
            await _gameLogic.PauseGame(Context.User.Identity.Name);
        }

        public async Task StartGame()
        {
            await _gameLogic.StartGame(Context.User.Identity.Name);
        }

    }
}
