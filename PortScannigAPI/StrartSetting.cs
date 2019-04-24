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
        public void mthread(string[] argsset)
        {
            Task[] taskm = new Task[int.Parse(argsset[10] + 1)];
            SocketSend[] auto_thms = new SocketSend[int.Parse(argsset[8]) + 1];
            for (int trytimes = int.Parse(argsset[6]); trytimes <= int.Parse(argsset[8]);)
            {
                for (int i = 1; i <= int.Parse(argsset[10]); i++)
                {
                    taskm[i] = Task.Run(() =>
                    {
                        Console.WriteLine("线程编号:" + i + " 端口号：" + trytimes);
                        auto_thms[i] = new SocketSend();
                        auto_thms[i].SocketSendor(argsset[1], trytimes, argsset[4], trytimes);
                    });
                    trytimes++;
                }
                Task.WaitAll();
                Console.Read();
            }
            Console.Read();
            for (int i = 0; i <= int.Parse(argsset[10] + 1); i++)
            {
                Console.WriteLine(taskm[i].Status);
            }
            Console.Read();
        }
    }
}