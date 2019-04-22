using System;
using portscan.socket_send;
using System.Threading;
using System.Threading.Tasks;

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
                SocketSend auto = new SocketSend();
                auto.SocketSendor(argsset[1], int.Parse(argsset[2]), argsset[4], trytimes);
            }
        }
        Thread[] threadm;
        // SocketSend[] auto_thms;
        Task[] thm;
        public void mthread(string[] argsset)
        {
            threadm = new Thread[int.Parse(argsset[10] + 5)];

            SocketSend[] auto_thms = new SocketSend[int.Parse(argsset[8]) + 5];
            // thm = new Task[int.Parse(argsset[8]) + 5];
            for (int trytimes = int.Parse(argsset[6]); trytimes <= int.Parse(argsset[8]);)
            {
                for (int i = 0; i <= int.Parse(argsset[10]); i++)
                {
                    Console.WriteLine(i + "+" + trytimes);
                    auto_thms[i] = new SocketSend();
                    thm[i] = Task.Factory.StartNew(() => { auto_thms[i].SocketSendor(argsset[1], trytimes, argsset[4], trytimes); });
                    // threadm[i] = new Thread(new ThreadStart(delegate { auto_thms[i].SocketSendor(argsset[1], trytimes, argsset[4], trytimes); }));
                    // threadm[i].Start();
                    // threadm[i].Join();
                    trytimes++;
                }
                Task.WaitAll();
                // Thread.Sleep(2000);
            }
        }
    }
}