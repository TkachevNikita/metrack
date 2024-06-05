using Amazon.S3.Model;
using Amazon.S3;
using metrack.Domain.Entities;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace metrack.Api.Services
{
    public class CloudService
    {
        public static async Task UploadFile(IFormFile file,string photoUuid)
        {
            var accessKeyId = "YCAJEgzXRxIkVBa_DxSEpWYAi";
            var secretAccessKey = "YCNEF93EENhTyggmGNXPNGNQ5jgWPPZKUjSkK1u_";
            var region = "ru-central1";
            var bucketName = "metrack-bucket";

            var confir = new AmazonS3Config
            {
                ServiceURL = "https://storage.yandexcloud.net",
                ForcePathStyle = true
            };

            using (var client = new AmazonS3Client(accessKeyId, secretAccessKey, confir))
            {
                using (var stream = file.OpenReadStream())
                {
                    var request = new PutObjectRequest
                    {
                        BucketName = bucketName,
                        Key = photoUuid + '.' + Path.GetExtension(file.FileName),
                        InputStream = stream,
                        ContentType = file.ContentType
                    };

                    await client.PutObjectAsync(request);
                }
            }
        }

        public static string DeleleFile(string fileName)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "/root/yandex-cloud/bin/yc",
                        Arguments = $"serverless function invoke d4eio0oguub0ej0rkdhl -d {fileName}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return result;
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }
    }
    }
}
