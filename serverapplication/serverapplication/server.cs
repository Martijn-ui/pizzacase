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
            //hier wil je configureren via welke socket je wilt dat er verbinding gemaakt gaat worden
            Console.WriteLine("Via welke socket wil je de server runnen : ");
            Console.WriteLine("tcp = 1");
            Console.WriteLine("udp = 0");
            int con = Convert.ToInt32(Console.ReadLine());
            //hier controleer je of je een keuze hebt gemaakt tussen tcp of udp, je moet een keuze maken.
            //Anders word het je nog een keer gevraagd.
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
            //hier heb je voor tcp gekozen
            if (con == 1)
            {
                //maak je een server die draait op tcp
                tcpconnect();
                con = 3;
            }

            //hier heb je voor udp gekozen
            if (con == 0)
            {
                //maak je een server die draait op udp
                udpconnect();
                con = 3;

            }
            //hierdoor begint de applicatie weer vanaf het begin
            if (con == 3)
            {
                Console.ReadLine();
                Main();
            }
        }

        public static void tcpconnect()
        {
            //Hierdoor kan je de bestelling list class gebruiken
            Bestelling Bestelling = new Bestelling();

            //hier zet je de juiste port en ipadress waarop je wilt dat de server gaat runnen
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            
            //hier geef je aan op welke IpAddress en port de server draait
            TcpListener server = new TcpListener(localAddr, port);
            // Start met luisteren naar buitenstaanders
            server.Start();

            //een buffer om de data te kunnen lezen
            Byte[] bytes = new Byte[256];
            bool check = true;


            try
                {
                Console.Write("Waiting for a connection... ");
                //bekijkt of er een connectie plaats vind tussen de client en server
                TcpClient clienttcp = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                // Een stream object voor het lezen en schrijven van data
                NetworkStream stream = clienttcp.GetStream();

                int i;

                    //Een while loop die alle data die de client stuurd ontvangt
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                         // Vertaal databytes naar een ASCII string
                         String data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                         //hier splits je de string data in meerdere kolommen data
                         string[] bestelling = data.Split(';');

                    //hierbij kijk je hoeveel items er in de array bestelling zitten
                    //elke item in de array bestelling add je aan de list van bestelling class
                    //en laat je de data zien in de console met console.writeline
                    foreach (var item in bestelling)
                    {
                        Bestelling.addbestelling(item);
                        Console.WriteLine(item);
                    }

                    //omdat we maar 1 keer uw bestelling is ontvangen willen sturen doen we dat door
                    //1 keer door deze if heen te gaan. 
                    //dit zorgt er dus voor dat Uw bestelling is ontvagen!! word verstuurd naar de client
                    if (check)
                    {
                        // hierbij pak je de data om naar de client te sturen
                        var ontvangen = "Uw bestelling is ontvangen!!;";
                        //hier converteer je de data naar bytes
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(ontvangen);
                        // dit stuurt het naar de client
                        stream.Write(msg, 0, msg.Length);
                        //en hier verander je check naar false zodat je niet nog een keer dit bericht verstuurd
                        check = false;
                    }
                    //als de server ontvagnt van de client het bericht serverclose
                    //dan stopt de server ermee 
                    if (data == "serverclose")
                    {
                        server.Stop();
                        Console.WriteLine();
                        Console.WriteLine("server stopped");
                   
                        Console.WriteLine("vul in uw wachtwoord");
                        //je pakt de gemaakte bestelling en zet die gelijk aan list
                        List<string> list = Bestelling.ShowBestelling();
                        //hierbij pas je authentication toe en gebruik je de methode in Authentication class authorize
                        //je geeft hierbij mee het ingevoerde wachtwoord en het encrypte adress, postcode en stad
                        Authentication.authorize(Convert.ToString(Console.ReadLine()), list[1], list[2]);
                    }
                    
                    }             
              
                } 
            //je kijkt hier naar exceptions en als er een exception is dan laat je die zien in de console        
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void udpconnect()
        {
            //Hierdoor kan je de bestelling list class gebruiken
            Bestelling Bestelling = new Bestelling();
            //hier geef je aan op welke port de server draait
            UdpClient udpServer = new UdpClient(11000);   
            var remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            try
                {
                //Een while loop die alle data die de client stuurd ontvangt
                while (true)
                {
                    //hierbij kijk je wat de client stuurt naar de server en dat ontvang je via de code hieronder
                    //je moet de received informatie eerst van byte naar string converteren 
                    Byte[] ReceiveBytes = null;
                    ReceiveBytes = udpServer.Receive(ref remoteEP);
                    string Data = Encoding.ASCII.GetString(ReceiveBytes);
                    string[] bestelling = Data.Split(';');

                    //hierbij kijk je hoeveel items er in de array bestelling zitten
                    //elke item in de array bestelling add je aan de list van bestelling class
                    //en laat je de data zien in de console met console.writeline
                    foreach (var item in bestelling)
                    {
                        Bestelling.addbestelling(item);
                        Console.WriteLine(item);
                    }

                    //hierbij verstuur je het bericht naar de client uw bestelling is ontvangen!!
                    Byte[] sendBytes;
                    string ontvangen = "Uw bestelling is ontvangen!!";
                    sendBytes = System.Text.Encoding.ASCII.GetBytes(ontvangen);
                    udpServer.Send(sendBytes, sendBytes.Length, remoteEP);

                    //als de server ontvagnt van de client het bericht serverclose
                    //dan stopt de server ermee 
                    if (Data == "serverclose")
                    {
                        udpServer.Close();
                        Console.WriteLine();
                        Console.WriteLine("server stopped");

                        Console.WriteLine("vul in uw wachtwoord");
                        //je pakt de gemaakte bestelling en zet die gelijk aan list
                        List<string> list = Bestelling.ShowBestelling();
                        //hierbij pas je authentication toe en gebruik je de methode in Authentication class authorize
                        //je geeft hierbij mee het ingevoerde wachtwoord en het encrypte adress, postcode en stad
                        Authentication.authorize(Convert.ToString(Console.ReadLine()), list[1], list[2]);
                    }
                }
               


            }
            //je kijkt hier naar exceptions en als er een exception is dan laat je die zien in de console   
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        
        }          
    }
}

         


















