﻿using System.Net.Sockets;

namespace DagaDev
{
    public class DagaTcpClient : IDisposable
    {
        private TcpClient? _client = null;

        public void Dispose()
        {
            _client?.Close();
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> ConnectAsync(string host, int port, int timeout = 0)
        {
            _client ??= new();

            try
            {
                Task connectTask = _client.ConnectAsync(host, port);
                return await Task.WhenAny(connectTask, Task.Delay(timeout)) == connectTask;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}