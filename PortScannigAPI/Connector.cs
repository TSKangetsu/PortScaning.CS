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
        private Socket Clienter { get; set; }
        public SocketSend(string IPD, int IPPort, string BIPD, int BIPPort)
        {
            Clienter = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                Clienter.Bind(new IPEndPoint(IPAddress.Parse(IPD), IPPort));
                try
                {
                    Clienter.Connect(BIPD, BIPPort);
                    Console.WriteLine("remote ip " + BIPD + "on port" + BIPPort + "is running");
                    Clienter.Close();
                }
                catch
                {
                    Clienter.Close();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("port " + BIPPort + " dose't avalible");
                }
            }
            catch
            {
                Clienter.Close();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NetworkAdpator dons't avalible , or port has been binded");
            }
        }
    }
}
