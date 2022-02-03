using System;
using System.IO;
using System.Linq;

namespace URLShorteningService
{

    //Im using file system instead of database.
    class Program
    {
       
        //This function is responsible for creating unique file names which would map to URL ID
        public static string RandomString()
        {
            var chars = "ABCDEFGHIJKLMNOP23456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return  new String(stringChars);
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter URL to Shorten");
            string LongURL = Console.ReadLine();

            

            //taking input url and storing it in the file system with name of file being a unique ID
            try
            {
                string fileName = RandomString();
                
                StreamWriter sr = new StreamWriter(@"C:\Users\mualvi\Documents\Cronofy\URLShorteningService\URLShorteningService\DB\"+ fileName+".txt");
              
                sr.Write(LongURL);
              
                sr.Close();

                //Outputing an API EndPoint which will take that unique Id input and that end point will redirect to link that is 
                // stored in that filename file
                Console.WriteLine("Short URL =>  https://localhost:44365/URLShortener/" + fileName);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Final block: "  );
            }
        }
    }
}
