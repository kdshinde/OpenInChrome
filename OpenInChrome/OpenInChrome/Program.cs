using System;
using System.Diagnostics;
using System.IO;

namespace OpenInChrome
{
    class Program
    {
        static void Main()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"C:\FileToRead.txt"))
                {
                    string line;
                    int total = Int32.MaxValue;
                    int count = 0;
                    string chromeExePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                    //We can set a conditional breakpoint here to stop at a certain count
                    while ((line = sr.ReadLine()) != null && count <= total)
                    {
                        //Making sure it is a link starting with http
                        if (line.StartsWith("http"))
                        {
                            var url = line;

                            using (var process = new Process())
                            {
                                process.StartInfo.FileName = chromeExePath;
                                process.StartInfo.Arguments = url + " --incognito";
                                process.Start();
                            }
                        }
                        count++;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }


    }
}
