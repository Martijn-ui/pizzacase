using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace serverapplication
{
    public class Decrypt
    {
        //deze methode zorgt ervoor dat de meegegeven string cipherText word gedecrypt.
        //Daarnaast geef je ook een Key mee en als het de juiste key is dan wordt de ciphertext goed gedecrypt.
        public static string DecryptString(string cipherText, string Key)
        {

            var key = Key;
            byte[] vector = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            //maak je een nieuwe instance van Aes object. Hier zet je de key die je wilt gebruiken en die ook gebruikt is bij het encrypten. 
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
               
                aes.IV = vector;
                //hier maak je een decryptor om de streamtransform uit te voeren
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                //hier maak je de stream die je dan gebruikt om te decrypten.
                using (MemoryStream memorystream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptostream = new CryptoStream((Stream)memorystream, decryptor, CryptoStreamMode.Read))
                    {
                        //de streamreader ga je gebruiken om van bytes naar een string te gaan
                        using (StreamReader streamreader = new StreamReader((Stream)cryptostream))
                        {

                            //hier converter je de decrypted bytes naar een string en die string return je.
                            return streamreader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
