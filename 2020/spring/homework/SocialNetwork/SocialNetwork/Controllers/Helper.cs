using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    public static class Helper
    {
        public static byte[] ConvertFileToBytes(IFormFile image)
        {
            if (image == null) return null;
            var bytes = new List<byte>();
            var tempBytes = new byte[1024];
            using (var stream = image.OpenReadStream())
            {
                var count = stream.Length;
                while (count > 0)
                {
                    count = stream.Read(tempBytes, 0, 1024);
                    bytes.AddRange(tempBytes.Take((int)count));
                }
            }
            return bytes.ToArray();
        }
    }
}
