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
        public static void Connect(string naam, string adress, string postcodeenstad, string naampizza, int sumpizza, int sumtoppings, List<string> toppings, DateTime datumtijd)
        {
            Byte[] bytes = new Byte[256];
            try
            {
                //connect naar de server
                Int32 port = 13000;
                string server = "127.0.0.1";
                TcpClient client = new TcpClient(server, port);
         
                Console.ReadKey();
                
                NetworkStream stream = client.GetStream();
                byte[] data;
                byte[] Topping;
                data = System.Text.Encoding.ASCII.GetBytes(naam + ";" + adress + ";" + postcodeenstad + ";" + naampizza + ";" + sumpizza + ";" + sumtoppings);
                stream.Write(data, 0, data.Length);
                
                    foreach (var item in toppings)
                    {
                        Topping = System.Text.Encoding.ASCII.GetBytes(";" + item);
                        stream.Write(Topping, 0, Topping.Length);
                    }     
                data = System.Text.Encoding.ASCII.GetBytes(";" + datumtijd);
                stream.Write(data, 0, data.Length);               

                Console.WriteLine("Naam: {0}", naam);
                Console.WriteLine("Adress: {0}", adress);
                Console.WriteLine("Postcode en Stad: {0}", postcodeenstad);
                Console.WriteLine("Naam pizza: {0}", naampizza);
                Console.WriteLine("Aantal pizza's: {0}", sumpizza);
                Console.WriteLine("Hoeveel extra toppings: {0}", sumtoppings);
              
                foreach (var item in toppings)
                    {
                        Console.WriteLine("Toppings {0}", item);
                    }
                            
                Console.WriteLine("Tijd van bestelling {0}", datumtijd);

                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    String ontvangen = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    string[] msg = ontvangen.Split(';');
                    Console.WriteLine(msg[0]);
                }
                
                // sluit de connectie tussen de server en client
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
        }
    }
}

