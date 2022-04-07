using System;  
using System.IO;  
using System.Security.Cryptography;  
using System.Text;

namespace client
{
    public class Encrypt
    {
        public static string EncryptString(string encrypt)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916"; 
            byte[] VECTOR = new byte[16];
            byte[] array;
            //maak je een nieuwe instance van Aes object. Hier zet je de key die je wilt gebruiken.
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = VECTOR;
                //hier maak je een encryptor om de streamtransform uit te voeren
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                //hier maak je de stream die je dan gebruikt om te encrypten.
                using (MemoryStream memorystream = new MemoryStream())
                {
                    using (CryptoStream cryptostream = new CryptoStream((Stream)memorystream, encryptor, CryptoStreamMode.Write))
                    {
                        //de streamreader ga je g
                        using (StreamWriter writer = new StreamWriter((Stream)cryptostream))
                        {
                            //schrijft alle data naar de stream
                            writer.Write(encrypt);
                        }

                        array = memorystream.ToArray();
                    }
                }
            }
            //returned de encrypted bytes van de memory stream en convert die naar een string
            return Convert.ToBase64String(array);
        }
    }
}