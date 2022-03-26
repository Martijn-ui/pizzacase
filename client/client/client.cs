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
            
            Console.WriteLine("Kies via welke je wilt connecten : ");
            Console.WriteLine("tcp = 1");
            Console.WriteLine("udp = 0");
            int con = Convert.ToInt32(Console.ReadLine());
            if (con == 1)
            {
                tcpconnectie.Connect("127.0.0.1", "hey");
            }
            if (con == 0)
            {
                udpconnectie.Connect("127.0.0.1", "hey");
            }
         
          
        }

    }
}

