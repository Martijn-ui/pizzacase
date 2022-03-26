using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace client
{
    public class tcpconnectie
    {
        public static void Connect(string server, string message)
        {
            try
            {
                //connect naar de server
                Int32 port = 13000;
                TcpClient client = new TcpClient(server, port);
         
                Console.ReadKey();


                //hier stuur je de message naar de server
                //naar je moet er eerst een byte van maken anders
                //kan je het niet versturen en gaat het fout
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // hier lees je wat de server stuurt en geef je aan dat het een byte is
                //dan kun je daarna de byte converteren naar een string
                
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // sluit de connectie tussen
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}

