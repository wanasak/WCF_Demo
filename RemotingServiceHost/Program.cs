using IRemotingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace RemotingServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloRemotingService remotingService = new HelloRemotingService();
            TcpChannel channel = new TcpChannel(8080);
            ChannelServices.RegisterChannel(channel);
            RemotingConfiguration.RegisterWellKnownServiceType(
               typeof(HelloRemotingService), "GetMessage",
               WellKnownObjectMode.Singleton);


            Console.WriteLine($"Host started @{DateTime.Now.ToString()}");
            Console.ReadLine();
        }
    }
}
