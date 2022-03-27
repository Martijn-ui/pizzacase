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
            Console.Clear();
            Console.WriteLine("Kies via welke je wilt connecten : ");
            Console.WriteLine("tcp = 1");
            Console.WriteLine("udp = 0");
            int con = Convert.ToInt32(Console.ReadLine());
            Boolean check = true;
            while (con > 1 | con < 0)
            {           
                if(check)
                {
                    Console.WriteLine("Fout!! U moet kiezen uit 0 of 1");
                    Console.WriteLine("Kies via welke je wilt connecten : ");
                    Console.WriteLine("tcp = 1");
                    Console.WriteLine("udp = 0");
                    con = Convert.ToInt32(Console.ReadLine());
                }         
            }
            //dit is voor tcp
            if (con == 1)
            {
                bestellingvragenenversturentcp();

                Console.WriteLine("Press enter om een nieuwe bestelling te maken?");
                Console.ReadLine();
                Main();
            }

            //dit is voor UDP
            if (con == 0)
            {
                bestellingvragenenversturenudp();
                Console.WriteLine("Press enter om een nieuwe bestelling te maken?");
                Console.ReadLine();
                Main();
            }
        }

        private static void bestellingvragenenversturentcp()
        {
            bestelling bestelling = new bestelling();
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

            tcpconnectie.Connect(bestelling.Naam, bestelling.Adress, bestelling.Postcodeenstad, bestelling.Naampizza, bestelling.Sumpizza, bestelling.Sumtoppings, bestelling.Topping, bestelling.Datumtijd);


        }
        private static void bestellingvragenenversturenudp()
        {
            bestelling bestelling = new bestelling();
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

            udpconnectie.Connect(bestelling.Naam, bestelling.Adress, bestelling.Postcodeenstad, bestelling.Naampizza, bestelling.Sumpizza, bestelling.Sumtoppings, bestelling.Topping, bestelling.Datumtijd);


        }


    }
}

