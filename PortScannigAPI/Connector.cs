using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Text;

namespace portscan.socket_send
{
    class SocketSend
    {
        private Socket[] Clienter { get; set; }
        public SocketSend(string IPD, int IPPort, string BIPD, int BIPPort)
        {
            Clienter = new Socket[0];
            Clienter[0] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                Clienter[0].Bind(new IPEndPoint(IPAddress.Parse(IPD), IPPort));
                try
                {
                    Clienter[0].Connect(BIPD, BIPPort);
                    Console.WriteLine("remote ip " + BIPD + "on port" + BIPPort + "is running");
                    Clienter[0].Close();
                }
                catch
                {
                    Clienter[0].Close();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("port " + BIPPort + " dose't avalible");
                }
            }
            catch
            {
                Clienter[0].Close();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NetworkAdpator dons't avalible , or port has been binded");
            }
        }
        public SocketSend(string IPD, int IPPort, string BIPD, int BIPPort, int i)
        {
            Clienter = new Socket[i];
            Clienter[i] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                Clienter[i].Bind(new IPEndPoint(IPAddress.Parse(IPD), IPPort));
                try
                {
                    Clienter[i].Connect(BIPD, BIPPort);
                    Console.WriteLine("remote ip " + BIPD + "on port" + BIPPort + "is running");
                    Clienter[i].Close();
                }
                catch
                {
                    Clienter[i].Close();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("port " + BIPPort + " dose't avalible");
                }
            }
            catch
            {
                Clienter[i].Close();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NetworkAdpator dons't avalible , or port has been binded");
            }
        }
    }
}
