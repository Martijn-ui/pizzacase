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


    class client
    {
        
        public static void Main()
        {
            bestelling bestelling = new bestelling();
            Console.WriteLine("Kies via welke je wilt connecten : ");
            Console.WriteLine("tcp = 1");
            Console.WriteLine("udp = 0");
            int con = Convert.ToInt32(Console.ReadLine());
            if (con == 1)
            {
                Console.Clear();
                Console.WriteLine("Maak uw bestelling: ");
                Console.WriteLine("Naam: ");
                bestelling.Naam = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Adress: ");
                bestelling.Adress = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Postcode en stad: ");
                bestelling.Postcodeenstad = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Naam pizza: ");
                bestelling.Naampizza = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Aantal pizza's: ");
                bestelling.Sumpizza = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Hoeveel extra toppings: ");
                bestelling.Sumtoppings = Convert.ToInt32(Console.ReadLine());
                int count = bestelling.Sumtoppings;
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("topping " + i);
                    bestelling.addtopping(Convert.ToString(Console.ReadLine()));
                }
                Console.WriteLine(bestelling.topping);
                Console.WriteLine("");
                tcpconnectie.Connect("127.0.0.1", "hey");
            }
            if (con == 0)
            {

                udpconnectie.Connect("127.0.0.1", "hey");
            }              
        }
    }
}

