using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
namespace umodel_start
{
    class Program
    {
        public static string aeskey { get; set; }
        static void Main(string[] args)
        {
        Console.Title = "Fortnite umodel Starter - Get the latest AES Keys with ease";
            if (File.Exists("umodel.exe"))
            {
                string aes = "";
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Downloading Newest AES Key from API...");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    WebClient webClient = new WebClient();
                    string apidata = webClient.DownloadString("https://benbotfn.tk/api/v1/aes");
                    dynamic parseddata = JObject.Parse(apidata);
                    aeskey = parseddata.mainKey;
                    if (parseddata.dynamicKeys != null)
                    {
                    selection: Console.Clear();
                     Console.WriteLine("Dynamic AES Key's have been found! (Keys for encrypted paks) \n Do you want to use one of them? Y / N (Selecting N will use the main Fortnite AES Key)");
                        string selection = Console.ReadLine();
                         if (selection.ToLower() == "n")
                        {
                            MainKeyStart();
                        }
                        if (selection.ToLower() == "y")
                        {
                            Console.WriteLine("Which aes Key do you want to use?");
                            Console.WriteLine(parseddata.dynamicKeys);
                            Console.WriteLine("Copy the aes and paste it below");
                            string typedaes = Console.ReadLine();
                            using (StreamWriter writer = new StreamWriter("umodel.bat"))
                            {
                                writer.Write("umodel.exe -path=\"" + Directory.GetCurrentDirectory() + "\" -aes=" + typedaes);
                            }
                            Process.Start("umodel.bat");
                            Environment.Exit(0);
                            Console.Read();
                        }
                        goto selection;

                    }
                    
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    Console.WriteLine("umodel.exe -path=\"" + Directory.GetCurrentDirectory() + "\" -aes=" + aes);
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Can't find umodel.exe, is it in this folder?");
                Console.ReadKey();
            }
            
            void MainKeyStart()
            {
                string aes = aeskey;
                using (StreamWriter writer = new StreamWriter("umodel.bat"))
                {
                    writer.Write("umodel.exe -path=\"" + Directory.GetCurrentDirectory() + "\" -aes=" + aes);
                }
                Process.Start("umodel.bat");
                Environment.Exit(0);
            }
            
        }
    }
}
