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
    public class udpconnectie
    {


        public static void Connect(string naam, string adress, string postcodeenstad, string naampizza, int sumpizza, int sumtoppings, List<string> toppings, DateTime datumtijd)
        {

            UdpClient udpClient = new UdpClient();
            //connect naar de server met de juiste port en IPadress
            IPEndPoint RemoteIp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
         
            Byte[] Topping;
            byte[] DatumTijd;

            //data encyrpten voordat we het versturen
            var encryptpostcodeenstad = Encrypt.EncryptString(postcodeenstad);
            var encryptadress = Encrypt.EncryptString(adress);
            try
            {
                //met udpClient.Send versturen we de data
                //Voordat we het kunnen versturen moeten we het van een string naar een byte veranderen
                Byte[] sendBytes = Encoding.ASCII.GetBytes(naam + ";" + encryptadress + ";" + encryptpostcodeenstad + ";" + naampizza + ";" + sumpizza + ";" + sumtoppings);
                udpClient.Send(sendBytes, sendBytes.Length, RemoteIp);

                //om alle toppings te versturen bekijk je eerst hoeveel toppings er zijn
                //dit doe je met deze foreach loop en dan voor elke topping verstuur je die apart naar de server
                foreach (var item in toppings)
                {
                    Topping = System.Text.Encoding.ASCII.GetBytes(";" + item);
                    udpClient.Send(Topping, Topping.Length, RemoteIp);
                }
                //hier verstuur je de datumtijd van de bestelling
                DatumTijd = System.Text.Encoding.ASCII.GetBytes(";" + datumtijd);
                udpClient.Send(DatumTijd, DatumTijd.Length, RemoteIp);


                //dit laat de bestelling zien in de console van de client
                Console.WriteLine("Naam: {0}", naam);
                Console.WriteLine("Adress: {0}", adress);
                Console.WriteLine("Postcode en Stad: {0}", postcodeenstad);
                Console.WriteLine("Naam pizza: {0}", naampizza);
                Console.WriteLine("Aantal pizza's: {0}", sumpizza);
                Console.WriteLine("Hoeveel extra toppings: {0}", sumtoppings);


                //dit leest de message die de client ontvangt van de server
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIp);
                string bestelling = Encoding.ASCII.GetString(receiveBytes);
                Console.WriteLine(bestelling.ToString());

                //je verstuurd als laatste naar de server de message serverclose zodat de server er ook mee stopt
                //anders krijg je exception errors dat de client de verbinding stop zet 
                //hierdoor gaat de server zelf ook stoppen
                Byte[] serverclose = System.Text.Encoding.ASCII.GetBytes("serverclose");
                udpClient.Send(serverclose, serverclose.Length, RemoteIp);

                //hier sluit je de connectie vanaf de client naar de server
                udpClient.Close();
                Console.WriteLine("server closed");
                Console.ReadLine();

            }
            //je kijkt hier naar exceptions en als er een exception is dan laat je die zien in de console   
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
       

        }
    }
}
