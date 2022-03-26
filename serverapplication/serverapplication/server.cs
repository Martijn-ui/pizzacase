using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace serverapplication
{
    public class Program
    {
        public static void Main()
        {
            TcpListener server = null;
            // Set the TcpListener on port 13000.
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);
            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            String data = null;

            while (server != null)
            {
                try
                {
                    Console.Write("Waiting for a connection... ");

                    TcpClient clienttcp = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = clienttcp.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // hierbij pak je de data om naar de client te sturen
                        data = data.ToUpper();
                        //hier converteer je de data naar bytes
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                        // dit stuurt het naar de client
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine("ArgumentNullException: {0}", e);
                }
                Console.Write("Waiting for a connection... ");
                UdpClient udpServer = new UdpClient(11000);
                var remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
                var info = udpServer.Receive(ref remoteEP);

                while (info != null)
                {
                    Console.WriteLine("joo");
                    Console.Write("receive data from " + remoteEP.ToString());
                    udpServer.Send(new byte[] { 1 }, 1, remoteEP);
                    udpServer.Close();
                    info = null;
                }
            }
        }
    }
}

               

                 
                
            
       

        
    
   

