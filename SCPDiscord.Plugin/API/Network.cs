using GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCPDiscord.Plugin.API
{
    public class Network : IDisposable
    {

        /// <summary>
        /// Gets the active <see cref="System.Net.Sockets.TcpClient"/> instance.
        /// </summary>
        public TcpClient TcpClient { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="TcpClient"/> is connected or not.
        /// </summary>
        public bool IsConnected => TcpClient?.Connected ?? false;

        /// <summary>
        /// Initialize a new instance of <see cref="Network"/>.
        /// </summary>
        public Network(IPEndPoint ip, int reconnectTime)
        {
            // W H O ?
            IPEndPoint = ip;
            ReconnectTime = new TimeSpan(reconnectTime);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Network"/> class.
        /// </summary>
        ~Network() => Dispose();

        public void Dispose()
        {
            // YEEEEEEET
        }

        private async Task Start()
        {
            TcpClient = new();

            await TcpClient.ConnectAsync(IPEndPoint.Address, IPEndPoint.Port);

            if (!TcpClient.Connected)
            {
                PluginAPI.Core.Log.Error($"Error on {nameof(Start)}: Error on connectiong to server {IPEndPoint.Address}:{IPEndPoint.Port}");
                Dispose();
                return;
            }
        }

        public async ValueTask SendAsync<T>(T data, CancellationToken cancellationToken)
        {
            if (!TcpClient.Connected)
                return;


        }



        public IPEndPoint IPEndPoint { get; private set; }

        public TimeSpan ReconnectTime { get; }

    }
}
