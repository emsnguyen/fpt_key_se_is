using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q2
{
    public class MyClient
    {
        MyServer server;
        public MyClient(MyServer server)
        {
            this.server = server;
        }

        public void ExecuteCommand(string command)
        {
            server.Command = command;
        }
        public void RaiseInvalidCommand(string message)
        {
            Console.WriteLine("Handler:" + message);
        }

    }
    public class MyServer
    {
        private string _command;
        public string Command
        {
            get
            {
                return _command;
            }
            set
            {
                if (value.Contains("-truncate"))
                {
                    if (MaliciousAlarm != null)
                    {
                        MaliciousAlarm.Invoke(value);
                    }
                }
                _command = value;
            }
        }
        public delegate void NotifyDelegate(string message);
        public event NotifyDelegate MaliciousAlarm;
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyServer server = new MyServer();
            MyClient client = new MyClient(server);
            server.MaliciousAlarm += client.RaiseInvalidCommand;
            client.ExecuteCommand("Nothing happends");
            client.ExecuteCommand("-truncate Something happend");
            Console.ReadKey();
        }
    }
}
