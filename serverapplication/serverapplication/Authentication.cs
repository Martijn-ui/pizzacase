using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverapplication
{
    public class Authentication
    {
        public void authorize(string Key, string Postcodeenstad, string Adress)
        {
            
            //de juiste key 
            string key = "b14ca5898a4e4133bbce2ea2315a1916";
            //hier controleer je of de meegegeven key gelijk is aan de juiste key
            if (Key == key)
            {
                //hier decrypt je de meegegeven postcodeenstad en address
                string decryptadress = Decrypt.DecryptString(Adress, Key);
                string decryptpostcodeenstad = Decrypt.DecryptString(Postcodeenstad, Key);
                
                //hier geef je aan dat het wachtwoord juist was en laat je zien wat de postcode, stad en adress is gedecrypt.
                Console.WriteLine("Wachtwoord juist");
                Console.WriteLine("Adress en postcode en stad gedecrypt: ");
                Console.WriteLine("Adress: " + decryptadress);
                Console.WriteLine("Postcode en Stad: " + decryptpostcodeenstad);               
            }
            //als het meegegeven key toch niet gelijk is aan de juiste key dan geeft hij aan in de console verkeerde wachtwoord!
            else
            {
                Console.WriteLine("Verkeerde wachtwoord!!");
            }
        }

     

    }
}
