﻿using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace DagaDev
{
    public class DagaTcpServer : IDisposable
    {
        private TcpListener? _listener = null;

        private List<TcpClient>? _clients = null;

        private bool _isRunning = false;

        public void Dispose()
        {
            _isRunning = false;

            _listener?.Dispose();
            
            if(null!=_clients)
            {
                foreach (var client in _clients)
                {
                    client.Close();
                    client.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }

        public async Task ListenAsync(int port)
        {
            if (_isRunning)
            {
                return;
            }

            _isRunning = true;

            _listener = new(IPAddress.Any, port);
            _listener.Start();

            await AcceptAsync();
        }

        public void Stop()
        {
            _isRunning = false;
            _listener?.Stop();

            if(null == _clients)
            {
                return;
            }

            foreach (var client in _clients)
            {
                if(client.Connected)
                {
                    client.Close();
                }
            }

            _clients.Clear();
        }

        private async Task AcceptAsync()
        {
            Debug.Assert(_listener != null);

            while (_isRunning)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                if(null == _clients)
                {
                    _clients = [];
                }
                _clients.Add(client);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            int offset = 0;
            int lengthSize = sizeof(ushort);
            byte[] lengthBuffer = new byte[lengthSize];
            try
            {
                while(client.Connected)
                {
                    int bytesRead = await stream.ReadAsync(lengthBuffer.AsMemory(offset, lengthSize));
                    if (bytesRead <= lengthSize)
                    {
                        break;
                    }

                    offset += bytesRead;
                    ushort packetLength = BitConverter.ToUInt16(lengthBuffer);
                    byte[] packetBuffer = new byte[packetLength];
                    bytesRead = await stream.ReadAsync(packetBuffer.AsMemory(offset, packetLength));
                    if (bytesRead <= packetLength)
                    {
                        break;
                    }

                    string message = System.Text.Encoding.UTF8.GetString(packetBuffer, 0, bytesRead);
                    IPacket? packet = JsonSerializer.Deserialize<IPacket>(message);
                    packet?.Execute();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                client.Close();
            }
        }
    }
}