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
            //connect naar de server met de juiste port en IPadress
            Int32 port = 13000;
            string server = "127.0.0.1";
            TcpClient client = new TcpClient(server, port);
            NetworkStream stream = client.GetStream();

            byte[] data;
            byte[] Topping;

            //data encyrpten voordat we het versturen
            var encryptpostcodeenstad = Encrypt.EncryptString(postcodeenstad);
            var encryptadress = Encrypt.EncryptString(adress);

            try
            {            
                //met stream.write versturen we de data
                //Voordat we het kunnen versturen moeten we het van een string naar een byte veranderen
                data = System.Text.Encoding.ASCII.GetBytes(naam + ";" + encryptadress + ";" + encryptpostcodeenstad + ";" + naampizza + ";" + sumpizza + ";" + sumtoppings);
                stream.Write(data, 0, data.Length);
                
                //om alle toppings te versturen bekijk je eerst hoeveel toppings er zijn
                //dit doe je met deze foreach loop en dan voor elke topping verstuur je die apart naar de server
                foreach (var item in toppings)
                    {
                        Topping = System.Text.Encoding.ASCII.GetBytes(";" + item);
                        stream.Write(Topping, 0, Topping.Length);
                    }     
                //hier verstuur je de datumtijd van de bestelling
                data = System.Text.Encoding.ASCII.GetBytes(";" + datumtijd);
                stream.Write(data, 0, data.Length);               

                //dit laat de bestelling zien in de console van de client
                Console.WriteLine("Naam: {0}", naam);
                Console.WriteLine("Adress: {0}", adress);
                Console.WriteLine("Postcode en Stad: {0}", postcodeenstad);
                Console.WriteLine("Naam pizza: {0}", naampizza);
                Console.WriteLine("Aantal pizza's: {0}", sumpizza);
                Console.WriteLine("Hoeveel extra toppings: {0}", sumtoppings);

                //dit leest de message die de client ontvangt van de server
                int i = stream.Read(bytes, 0, bytes.Length);                
                // Translate data bytes to a ASCII string.
                String ontvangen = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                string[] msg = ontvangen.Split(';');
                Console.WriteLine(msg[0]);

                //je verstuurd als laatste naar de server de message serverclose zodat de server er ook mee stopt
                //anders krijg je exception errors dat de client de verbinding stop zet 
                //hierdoor gaat de server zelf ook stoppen
                Byte[] serverclose = System.Text.Encoding.ASCII.GetBytes("serverclose");
                stream.Write(serverclose, 0, serverclose.Length);


                //hier sluit je de connectie vanaf de client naar de server
                stream.Close();
                client.Close();

            

            }
            //je kijkt hier naar exceptions en als er een exception is dan laat je die zien in de console   
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

