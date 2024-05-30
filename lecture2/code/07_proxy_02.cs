
using System;

namespace ProxyPatternExample2
{
    // Subject interface
    public interface IFileDownloader
    {
        void DownloadFile(string url);
    }

    // RealSubject - the actual file downloader
    public class RealFileDownloader : IFileDownloader
    {
        public void DownloadFile(string url)
        {
            Console.WriteLine($"Downloading file from {url}");
            // Simulate file download
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("File downloaded successfully.");
        }
    }

    // Proxy - controls access to the RealFileDownloader
    public class FileDownloaderProxy : IFileDownloader
    {
        private RealFileDownloader _realFileDownloader;
        private int _downloadLimit;
        private int _downloadsPerformed;

        public FileDownloaderProxy(int downloadLimit)
        {
            _downloadLimit = downloadLimit;
            _downloadsPerformed = 0;
        }

        public void DownloadFile(string url)
        {
            if (_downloadsPerformed < _downloadLimit)
            {
                if (_realFileDownloader == null)
                {
                    _realFileDownloader = new RealFileDownloader();
                }
                _realFileDownloader.DownloadFile(url);
                _downloadsPerformed++;
            }
            else
            {
                Console.WriteLine("Download limit reached. Access denied.");
            }
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            IFileDownloader downloader = new FileDownloaderProxy(2);
            downloader.DownloadFile("http://example.com/file1.zip");
            downloader.DownloadFile("http://example.com/file2.zip");
            downloader.DownloadFile("http://example.com/file3.zip");
        }
    }
}

// Output:
// Downloading file from http://example.com/file1.zip
// File downloaded successfully.
// Downloading file from http://example.com/file2.zip
// File downloaded successfully.
// Download limit reached. Access denied.

// Förklaring:
// Proxy pattern ger dig möjlighet att kontrollera åtkomst till ett objekt. 
// Detta kan vara användbart för att begränsa åtkomst till resurser,
// för att skjuta upp skapandet av ett objekt tills det behövs, eller för 
// att lägga till extra funktionalitet till ett objekt. I exemplet ovan
// begränsar FileDownloaderProxy åtkomsten till RealFileDownloader genom att
// begränsa antalet nedladdningar som kan göras. När nedladdningsgränsen
// har nåtts nekas åtkomst till RealFileDownloader.

// Proxy pattern kan användas för att skapa en proxy för ett objekt som
// är dyrt att skapa eller som kräver speciella åtkomstkontroller.
// Proxy pattern kan också användas för att lägga till extra funktionalitet
// till ett objekt, till exempel att logga anrop till objektet eller att
// cachning av resultat från anrop till objektet. Proxy pattern kan också
// användas för att skapa en proxy för ett objekt som är på en annan plats
// (t.ex. en proxy för ett objekt som finns på en annan dator).
