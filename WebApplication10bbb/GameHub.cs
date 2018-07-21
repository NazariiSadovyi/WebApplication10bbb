using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebApplication10bbb
{
    public class GameHub:Hub
    {
        private readonly GameLogic _gameLogic;
            
        public GameHub(GameLogic gameLogic)
        {
            _gameLogic = gameLogic;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _gameLogic.Disconnected(Context.ConnectionId.ToString());
            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            _gameLogic.Connected(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task MovePacmen(int move)
        {            
            await _gameLogic.Move(move,Context.ConnectionId.ToString());            
        }

        public async Task Pause()
        {
            await _gameLogic.PauseGame(Context.ConnectionId.ToString());
        }

        public async Task StartGame()
        {
            await _gameLogic.StartGame(Context.ConnectionId.ToString());
        }

    }
}
