using System;
using portscan.socket_send;
using portscan.startsetting;
using System.Net.NetworkInformation;
using System.Net;

namespace portscan
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "set-bind":
                    if (args[3] == "bind-to")
                    {
                        SocketSend ins = new SocketSend(args[1], int.Parse(args[2]), args[4], int.Parse(args[5]));
                    }
                    break;
                case "auto-try":
                    if (args[3] == "bind-to")
                    {
                        if (args[5] == "from")
                        {
                            if (args[7] == "to")
                            {
                                try
                                {
                                    if (args[9] == "-mthread")
                                    {

                                    }
                                }
                                catch
                                {
                                    StartSetting autorun = new StartSetting();
                                    autorun.autotry(args);
                                }
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("no args works");
                    break;
            }
        }
    }
}