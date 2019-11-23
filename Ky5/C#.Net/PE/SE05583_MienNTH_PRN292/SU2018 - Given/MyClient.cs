using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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