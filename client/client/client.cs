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
            //hier wil je configureren via welke socket je wilt dat er verbinding gemaakt gaat worden
            Console.WriteLine("Kies via welke je wilt connecten : ");
            Console.WriteLine("tcp = 1");
            Console.WriteLine("udp = 0");
            int con = Convert.ToInt32(Console.ReadLine());
            Boolean check = true;
            //hier controleer je of je een keuze hebt gemaakt tussen tcp of udp, je moet een keuze maken.
            //Anders word het je nog een keer gevraagd.
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
            //hier heb je voor tcp gekozen
            if (con == 1)
            {
                bestellingvragenenversturentcp();

                Console.WriteLine("Press enter om een nieuwe bestelling te maken?");
                Console.ReadLine();
                Main();
            }
            //hier heb je voor udp gekozen
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
            try
            {
                //Dit is een vragenlijst en word er gevraagd wat je wilt voor je bestelling
                //de ingevulde data word naar de class bestelling opgeslagen
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
                //hier bekijk je hoeveel extra toppings erbij moeten
                //en zo vaak ga je door deze for loop 
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("topping " + i);
                    bestelling.addtopping(Convert.ToString(Console.ReadLine()));
                }

                PrijsVisitor prijsCalc = new();
                Console.WriteLine("Totaalprijs: " + bestelling.accept(prijsCalc));
                //hierbij maak je de connectie met de server via tcp en geef je de ingevulde bestelling mee
                tcpconnectie.Connect(bestelling.Naam, bestelling.Adress, bestelling.Postcodeenstad, bestelling.Naampizza, bestelling.Sumpizza, bestelling.Sumtoppings, bestelling.Topping, bestelling.Datumtijd);


            }
            //je kijkt hier naar exceptions en als er een exception is dan laat je die zien in de console   
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }
        private static void bestellingvragenenversturenudp()
        {
            try
            {
                //Dit is een vragenlijst en word er gevraagd wat je wilt voor je bestelling
                //de ingevulde data word naar de class bestelling opgeslagen
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

                PrijsVisitor prijsCalc = new();
                Console.WriteLine("Totaalprijs: " + bestelling.accept(prijsCalc));
                //hierbij maak je de connectie met de server via tcp en geef je de ingevulde bestelling mee
                udpconnectie.Connect(bestelling.Naam, bestelling.Adress, bestelling.Postcodeenstad, bestelling.Naampizza, bestelling.Sumpizza, bestelling.Sumtoppings, bestelling.Topping, bestelling.Datumtijd);

            }
            //je kijkt hier naar exceptions en als er een exception is dan laat je die zien in de console   
            catch (Exception e)
            {
               Console.WriteLine(e.ToString());
            }
         

        }



    }
}

