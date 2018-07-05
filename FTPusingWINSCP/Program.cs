using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WinSCP;

namespace ConsoleApplicationToDownloadFolderWINSCP
{
    class Program
    {
        static void Main(string[] args)
        {
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = "134.251.30.243",
                UserName = "test",
                Password = "test",
            };
            string remoteDir = "test";
            string path = "C:\\Users\\suyambu\\Desktop\\" + remoteDir;
            try
            {
                if (!Directory.Exists(path))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
            }
            catch (IOException ioex)
            {
                //MessageBox.Show(ioex.Message);
                Console.WriteLine(ioex.Message);
            }

            using (Session session = new Session())
            {
                // Connect
                session.Open(sessionOptions);

                // Download files
                session.GetFiles("/" + remoteDir + "/*", @"C:\Users\suyambu\Desktop\" + remoteDir + "\\*").Check();
            }
            string name = "test";
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectory("C:\\Users\\suyambu\\Desktop\\" + name);//File to Zip

                // System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);

                // zip.SaveProgress += Zip_SaveProgress;
                // zip.Save(string.Format("{0}{1}.zip", di.Parent.FullName,di.Name));
                zip.Save("C:\\Users\\suyambu\\Desktop\\" + name + ".zip");


            }
        }
    }
}
//using System;  
//using System.IO;  
//using System.Net;  
//using System.Text;  

//namespace Examples.System.Net  
//{  
//    public class WebRequestGetExample  
//    {  
//        public static void Main ()  
//        {  
//            // Get the object used to communicate with the server.  
//            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://134.251.30.243/");  
//            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;  

//            // This example assumes the FTP site uses anonymous logon.  
//            request.Credentials = new NetworkCredential ("test","test");  

//            FtpWebResponse response = (FtpWebResponse)request.GetResponse();  

//            Stream responseStream = response.GetResponseStream();  
//            StreamReader reader = new StreamReader(responseStream);  
//            Console.WriteLine(reader.ReadToEnd());  

//            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);  

//            reader.Close();  
//            response.Close();  
//        }  
//    }  
//}