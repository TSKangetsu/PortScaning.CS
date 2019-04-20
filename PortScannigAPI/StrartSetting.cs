using System;
using portscan.socket_send;
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
                SocketSend auto = new SocketSend(argsset[1], int.Parse(argsset[2]), argsset[4], trytimes);
            }
        }
        Task[] th { get; set; }
        SocketSend[] auto_thms;
        public void mthread(string[] argsset)
        {
            th = new Task[40];
            auto_thms = new SocketSend[40];
            for (int trytimes = int.Parse(argsset[6]); trytimes <= int.Parse(argsset[8]); trytimes++)
            {
                for (int i = 0; i <= int.Parse(argsset[10]); i++)
                {
                    th[i] = Task.Factory.StartNew(() =>
                    {
                        auto_thms[i] = new SocketSend(argsset[1], int.Parse(argsset[2]), argsset[4], trytimes);
                        Console.WriteLine(i);
                    });
                }
                Task.WaitAll();
            }
        }
    }
}