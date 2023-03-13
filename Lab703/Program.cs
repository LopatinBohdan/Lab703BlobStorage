// See https://aka.ms/new-console-template for more information
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

//Console.WriteLine("Hello, World!");

string connStr=Environment.GetEnvironmentVariable("AZURE_VALUE");
//string connStr = "DefaultEndpointsProtocol=https;AccountName=lopatinstorage;AccountKey=/ODnfrHlg66QT2fsuFLvKyr/YTB7OKbOMtr//EMSD/fvNgU7G6XLFeGsRoptNy37gy7pMZlhiI03+AStlq122Q==;EndpointSuffix=core.windows.net";

BlobServiceClient blobServiceClient= new BlobServiceClient(connStr);

string containerName = "con7a6cc101-cfc0-4a4d-b5a6-b80bb7fb178b";
BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);

//string fileName = "testing.txt";
//blobContainerClient.DeleteBlobAsync(fileName);
//blobContainerClient.DeleteAsync();
//BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);

await foreach (BlobItem item in blobContainerClient.GetBlobsAsync())
{
    Console.WriteLine(item.Name);
    BlobClient blobClient=blobContainerClient.GetBlobClient(item.Name);
    Console.WriteLine(blobClient.Uri.AbsoluteUri);
    Console.WriteLine(item.Properties.CreatedOn);
}




