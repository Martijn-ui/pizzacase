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
            Console.Clear();
            Console.WriteLine("Via welke socket wil je de server runnen : ");
            Console.WriteLine("tcp = 1");
            Console.WriteLine("udp = 0");
            int con = Convert.ToInt32(Console.ReadLine());
            while (con > 1 | con < 0)
            {
                if (true)
                {
                    Console.WriteLine("Fout!! U moet kiezen uit 0 of 1");
                    Console.WriteLine("Via welke socket wil je de server runnen : ");
                    Console.WriteLine("tcp = 1");
                    Console.WriteLine("udp = 0");
                    con = Convert.ToInt32(Console.ReadLine());
                }
            }
            //dit is voor udp
            if (con == 1)
            {
                tcpconnect();
                Main();
            }

            //dit is voor UDP
            if (con == 0)
            {
                udpconnect();
                Main();
            }


        }

        public static void tcpconnect()
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
                        string[] bestelling = data.Split(';');
                    foreach (var item in bestelling)
                    {
                        Console.WriteLine(item);
                    }

                        // hierbij pak je de data om naar de client te sturen
                        var ontvangen = "Uw bestelling is ontvangen!!;";
                        //hier converteer je de data naar bytes
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(ontvangen);
                        // dit stuurt het naar de client
                        stream.Write(msg, 0, msg.Length);
                        //Console.WriteLine("Sent: {0}", ontvangen);
                    }
                server.Stop();
                }

                catch (Exception e)
                {

                    Console.WriteLine("ArgumentNullException: {0}", e);
                }
           

        }

        public static void udpconnect()
        {
            Console.Write("Waiting for a connection... ");
            UdpClient udpServer = new UdpClient(11000);
            
            var remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            //var info = udpServer.Receive(ref remoteEP); 
            Byte[] sendBytes;
            string ontvangen = "Uw bestelling is ontvangen!!";
            sendBytes = System.Text.Encoding.ASCII.GetBytes(ontvangen);
            udpServer.Send(sendBytes, sendBytes.Length, remoteEP);
          
            try
                {

                while (true)
                {
                    Byte[] receiveBytes = udpServer.Receive(ref remoteEP);
                    string data = Encoding.ASCII.GetString(receiveBytes);
                    string[] bestelling = data.Split(';');
                    foreach (var item in bestelling)
                    {
                        Console.WriteLine(item);
                    }
                }
               

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            udpServer.Close();


        }
    }
}
         


















