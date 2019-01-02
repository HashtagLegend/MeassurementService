using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpBroadcastReceiver
{
    class Program
    {
        private const int Port = 7000;
        static string uri = "";
        
        static void Main(string[] args)
        {
            //Oprettet en tom udpreciever, så der kan modtages UDP broadcasts, tager en Port som parameter
            UdpClient udpReciever = new UdpClient(Port);

            //IPEndpoint er den ipadresse der bliver sendt fra, altså den source der broadcaster
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, Port);

            Console.WriteLine("Receiver not open");

            try
            {

                while (true)
                {

                    Byte[] recieveBytes = udpReciever.Receive(ref remoteIpEndPoint);

                    string recievedData = Encoding.ASCII.GetString(recieveBytes);

                    string[] data = recievedData.Split(' ');
                    
                    foreach (var line in data)
                    {
                        Console.WriteLine(line);

                    }
                    
                    
                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        
    }
}
