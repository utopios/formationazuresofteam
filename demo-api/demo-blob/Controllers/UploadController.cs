using System;
using System.IO;
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_blob.Controllers
{
    [ApiController]
    [Route("/upload")]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(IFormFile image)
        {
            //Accéder au storage blob
            // BlobContainerClient containerClient = new BlobContainerClient(new Uri("https://utopiosstorage.blob.core.windows.net/images"),
            //     new DefaultAzureCredential());
            
            //Accéder au storage par la chaine de connexion.
             BlobServiceClient blobServiceClient = new BlobServiceClient(@"");
             BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("images");
            // //Avoir notre image en bytes
            // byte[] blobFileBytes = new byte[256];
            // using MemoryStream memoryStream = new MemoryStream(blobFileBytes);
            BlobClient blob = containerClient.GetBlobClient(image.FileName);
            blob.Upload(image.OpenReadStream(), true);
            
            
            return Ok();
        }
        
    }
}