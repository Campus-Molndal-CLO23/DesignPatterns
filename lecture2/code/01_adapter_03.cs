using System;

namespace AdapterPatternExample3
{
    // ITarget interface - the standard interface expected by the client.
    public interface ICloudStorage
    {
        void UploadFile(string fileName);
        void DownloadFile(string fileName);
    }

    // Existing class for AWS S3 storage
    public class AwsS3
    {
        public void ConnectToS3()
        {
            Console.WriteLine("Connected to AWS S3.");
        }

        public void UploadToS3(string fileName)
        {
            Console.WriteLine($"File '{fileName}' uploaded to AWS S3.");
        }

        public void DownloadFromS3(string fileName)
        {
            Console.WriteLine($"File '{fileName}' downloaded from AWS S3.");
        }

        public void DisconnectFromS3()
        {
            Console.WriteLine("Disconnected from AWS S3.");
        }
    }

    // Existing class for Google Cloud Storage
    public class GoogleCloudStorage
    {
        public void ConnectToGoogleCloud()
        {
            Console.WriteLine("Connected to Google Cloud Storage.");
        }

        public void UploadToGoogleCloud(string fileName)
        {
            Console.WriteLine($"File '{fileName}' uploaded to Google Cloud Storage.");
        }

        public void DownloadFromGoogleCloud(string fileName)
        {
            Console.WriteLine($"File '{fileName}' downloaded from Google Cloud Storage.");
        }

        public void DisconnectFromGoogleCloud()
        {
            Console.WriteLine("Disconnected from Google Cloud Storage.");
        }
    }

    // Adapter class for AWS S3 storage
    public class AwsS3Adapter : ICloudStorage
    {
        private readonly AwsS3 _awsS3;

        // Constructor takes an instance of AwsS3
        public AwsS3Adapter(AwsS3 awsS3)
        {
            _awsS3 = awsS3;
        }

        // Connect, upload file, and then disconnect
        public void UploadFile(string fileName)
        {
            _awsS3.ConnectToS3();
            _awsS3.UploadToS3(fileName);
            _awsS3.DisconnectFromS3();
        }

        // Connect, download file, and then disconnect
        public void DownloadFile(string fileName)
        {
            _awsS3.ConnectToS3();
            _awsS3.DownloadFromS3(fileName);
            _awsS3.DisconnectFromS3();
        }
    }

    // Adapter class for Google Cloud Storage
    public class GoogleCloudStorageAdapter : ICloudStorage
    {
        private readonly GoogleCloudStorage _googleCloudStorage;

        // Constructor takes an instance of GoogleCloudStorage
        public GoogleCloudStorageAdapter(GoogleCloudStorage googleCloudStorage)
        {
            _googleCloudStorage = googleCloudStorage;
        }

        // Connect, upload file, and then disconnect
        public void UploadFile(string fileName)
        {
            _googleCloudStorage.ConnectToGoogleCloud();
            _googleCloudStorage.UploadToGoogleCloud(fileName);
            _googleCloudStorage.DisconnectFromGoogleCloud();
        }

        // Connect, download file, and then disconnect
        public void DownloadFile(string fileName)
        {
            _googleCloudStorage.ConnectToGoogleCloud();
            _googleCloudStorage.DownloadFromGoogleCloud(fileName);
            _googleCloudStorage.DisconnectFromGoogleCloud();
        }
    }

    // Client class - uses the ICloudStorage interface
    public class Client
    {
        private readonly ICloudStorage _cloudStorage;

        // Constructor takes an instance of ICloudStorage
        public Client(ICloudStorage cloudStorage)
        {
            _cloudStorage = cloudStorage;
        }

        // Upload and download files using the cloud storage interface
        public void PerformCloudStorageOperations(string fileName)
        {
            _cloudStorage.UploadFile(fileName);
            _cloudStorage.DownloadFile(fileName);
        }
    }

    // Main program to demonstrate the Adapter Pattern with different cloud storage adapters
    class Program
    {
        static void Main(string[] args)
        {
            // Using AWS S3
            AwsS3 awsS3 = new AwsS3();
            ICloudStorage awsS3Adapter = new AwsS3Adapter(awsS3);
            Client client1 = new Client(awsS3Adapter);
            client1.PerformCloudStorageOperations("file1.txt");

            // Using Google Cloud Storage
            GoogleCloudStorage googleCloudStorage = new GoogleCloudStorage();
            ICloudStorage googleCloudAdapter = new GoogleCloudStorageAdapter(googleCloudStorage);
            Client client2 = new Client(googleCloudAdapter);
            client2.PerformCloudStorageOperations("file2.txt");
        }
    }
}

// Output:
// Connected to AWS S3.
// File 'file1.txt' uploaded to AWS S3.
// Disconnected from AWS S3.
// Connected to AWS S3.
// File 'file1.txt' downloaded from AWS S3.
// Disconnected from AWS S3.
// Connected to Google Cloud Storage.
// File 'file2.txt' uploaded to Google Cloud Storage.
// Disconnected from Google Cloud Storage.
// Connected to Google Cloud Storage.
// File 'file2.txt' downloaded from Google Cloud Storage.
// Disconnected from Google Cloud Storage.
