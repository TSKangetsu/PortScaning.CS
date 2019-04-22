using System;
using portscan.socket_send;
using System.Threading;

namespace portscan.startsetting
{
    class StartSetting
    {
        public void autotry(string[] argsset)
        {
            //args[1] is local ip args[3] , is local port,
            // args[4] is remote ip , args[6] to args[9] is the port start to end62
            for (int trytimes = int.Parse(argsset[6]); trytimes <= int.Parse(argsset[8]); trytimes++)
            {
                SocketSend auto = new SocketSend(argsset[1], int.Parse(argsset[2]), argsset[4], trytimes);
            }
        }
        Thread[] threadm;
        // SocketSend[] auto_thms;
        public void mthread(string[] argsset)
        {
            threadm = new Thread[int.Parse(argsset[10]+5)];
            SocketSend[] auto_thms = new SocketSend[int.Parse(argsset[8]) + 5];
            for (int trytimes = int.Parse(argsset[6]); trytimes <= int.Parse(argsset[8]); trytimes++)
            {
                for (int i = 0; i <= int.Parse(argsset[10]); i++)
                {
                    Console.WriteLine(i);
                    threadm[i] = new Thread(new ThreadStart(delegate { auto_thms[i] = new SocketSend(argsset[1], int.Parse(argsset[2]), argsset[4], trytimes); }));
                }
                for (int i = 0; i <= int.Parse(argsset[10]); i++)
                {
                    threadm[i].Start();
                    threadm[i].Join();
                }
            }
        }
    }
}