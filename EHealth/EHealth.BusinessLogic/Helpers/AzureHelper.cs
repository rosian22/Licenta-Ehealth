using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EHealth.BusinessLogic.Helpers
{
    public class AzureHelper
    {
        public static string UploadPicture(HttpPostedFileBase file, string name, Guid pictureName)
        {
            CloudStorageAccount AzureStorage = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=ehealthlicenta;AccountKey=5KkH5yEILJX9oe4JEBMUDBRTgoC4Za4z5ywqyQ00x7Zvtsuyprat1F6d1ckDqUeuT+5tol4Z6TwdE2TRnJXVMQ==;EndpointSuffix=core.windows.net");
            CloudBlobClient BlobClient = AzureStorage.CreateCloudBlobClient();
            CloudBlobContainer Container = BlobClient.GetContainerReference("profilepictures");
            var extension = Path.GetExtension(file.FileName);

            CloudBlockBlob BlockBlob = Container.GetBlockBlobReference($"{pictureName}{extension}"); //picture name is the id of the enetity that has that profile picture set.

            var fileStream = file.InputStream;
            BlockBlob.UploadFromStream(fileStream);

            return BlockBlob.Uri.AbsoluteUri;
        }
    }
}

