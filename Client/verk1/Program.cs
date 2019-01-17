﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace verk1
{
    class Program
    {
        static TcpClient tcpClient;
        static void Main(string[] args)
        {
            ConnectToServer();
            Console.WriteLine("main 2");
            while (true) ;
        }

        static void ConnectToServer()
        {
            Console.WriteLine("byrjun connect 2 server()");

            tcpClient = new TcpClient();

            //IPAddress ipAddress = Dns.GetHostEntry("tsuts.tskoli.is/2t/0812003270").AddressList[0];
            IPAddress ipAddress = IPAddress.Parse("10.220.226.70");
            tcpClient.Connect(ipAddress, 1103);

            Console.WriteLine("NW STREAM");

            NetworkStream networkStream = tcpClient.GetStream();
            networkStream.ReadTimeout = 5000; // Mili secs

            

            byte[] bytes = new byte[1024];
            
            Console.WriteLine("NW stream read");

            networkStream.Read(bytes, 0, 1024);
            string data = Encoding.UTF8.GetString(bytes);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Server sent message: {0}", data);
            //networkStream.Close();
            //tcpClient.Close();
            return;
        }
    }
}