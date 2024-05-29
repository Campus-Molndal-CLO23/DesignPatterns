using System;

namespace FacadePatternExample3
{
    // Subsystem classes
    public class AwsS3Uploader
    {
        public void Upload(string fileName)
        {
            Console.WriteLine($"File {fileName} uploaded to AWS S3.");
        }
    }

    public class AzureBlobUploader
    {
        public void Upload(string fileName)
        {
            Console.WriteLine($"File {fileName} uploaded to Azure Blob Storage.");
        }
    }

    public class GoogleCloudUploader
    {
        public void Upload(string fileName)
        {
            Console.WriteLine($"File {fileName} uploaded to Google Cloud Storage.");
        }
    }

    // Facade class
    public class CloudStorageFacade
    {
        private AwsS3Uploader _awsS3;
        private AzureBlobUploader _azureBlob;
        private GoogleCloudUploader _googleCloud;

        public CloudStorageFacade()
        {
            _awsS3 = new AwsS3Uploader();
            _azureBlob = new AzureBlobUploader();
            _googleCloud = new GoogleCloudUploader();
        }

        public void UploadToAll(string fileName)
        {
            _awsS3.Upload(fileName);
            _azureBlob.Upload(fileName);
            _googleCloud.Upload(fileName);
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageFacade cloudStorage = new CloudStorageFacade();
            cloudStorage.UploadToAll("myfile.txt");
        }
    }
}

// Output:
// File myfile.txt uploaded to AWS S3.
// File myfile.txt uploaded to Azure Blob Storage.
// File myfile.txt uploaded to Google Cloud Storage.
