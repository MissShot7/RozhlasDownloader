using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace RozhlasDownloader
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.Title = "Rozhlas Downloader 1.0 - Pavel Hobza";

            Console.WriteLine("RozhlasDownloader - Pavel Hobza 2021");
            Console.WriteLine("");
            //ask for URL
            Console.WriteLine("Napiš odkaz (url) stránky");
            string url = Console.ReadLine();


            int filenumber = 0;
            
            //Get web source code

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var client = new WebClient())
            {
                //Console.WriteLine(client.DownloadString(url));
                string contents = client.DownloadString(url).Replace(@"\", "");

                


                //filter only urls
                foreach (Match match in Regex.Matches(contents, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"))
                {
                    
                    
                    //Console.WriteLine(match.ToString());

                    //filter mp3 urls
                    if (match.ToString().Contains(".mp3"))
                    {
                        filenumber += 01;
                        //write url name
                        Console.WriteLine(match.ToString());
                        //download file
                        Console.WriteLine("stahuju...");
                        Console.WriteLine(match.ToString());
                        client.DownloadFile(match.ToString(), filenumber.ToString() + ".mp3");
                    }
                    
                    

                }
                Console.WriteLine("úspěch!");
                Console.WriteLine("uloženo v " + AppDomain.CurrentDomain.BaseDirectory + "\\mp3");
                
                
            }

            
            

        }
    }
}
