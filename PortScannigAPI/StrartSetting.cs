using portscan.socket_send;

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
        public void mthread()
        {

        }
    }
}