﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace client
{
    public class udpconnectie
    {


        public static void Connect(string naam, string adress, string postcodeenstad, string naampizza, int sumpizza, int sumtoppings, List<string> toppings, DateTime datumtijd)
        {

            UdpClient udpClient = new UdpClient();
            IPEndPoint RemoteIp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            Byte[] sendBytes = Encoding.ASCII.GetBytes(naam + ";" + adress + ";" + postcodeenstad + ";" + naampizza + ";" + sumpizza + ";" + sumtoppings);
            Byte[] Topping;
            byte[] DatumTijd;
            Byte[] bytes = new Byte[256];
            try
            {
                
                udpClient.Send(sendBytes, sendBytes.Length, RemoteIp);
                foreach (var item in toppings)
                {
                    Topping = System.Text.Encoding.ASCII.GetBytes(";" + item);
                    udpClient.Send(Topping, Topping.Length, "127.0.0.1", 11000);
                }
                DatumTijd = System.Text.Encoding.ASCII.GetBytes(";" + datumtijd);
                udpClient.Send(DatumTijd, DatumTijd.Length, RemoteIp);

                Console.WriteLine("Naam: {0}", naam);
                Console.WriteLine("Adress: {0}", adress);
                Console.WriteLine("Postcode en Stad: {0}", postcodeenstad);
                Console.WriteLine("Naam pizza: {0}", naampizza);
                Console.WriteLine("Aantal pizza's: {0}", sumpizza);
                Console.WriteLine("Hoeveel extra toppings: {0}", sumtoppings);

                
                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIp);
                string bestelling = Encoding.ASCII.GetString(receiveBytes);
                Console.WriteLine(bestelling.ToString());
                
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            udpClient.Close();

        }
    }
}
