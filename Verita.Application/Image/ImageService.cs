using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verita.Application.Image
{
    public class ImageService :IImageService
    {
        public async Task<string> SaveImageAsync(Stream imageStream, string fileName)
        {
            // Paylaşılan klasör yolunu belirle
            var sharedFolderPath = Path.Combine("..", "SharedFiles");

            // Eğer dosya yolu yoksa oluştur
            if (!Directory.Exists(sharedFolderPath))
            {
                Directory.CreateDirectory(sharedFolderPath);
            }

            // Dosya adını benzersiz bir şekilde oluştur
            var uniqueFileName = Guid.NewGuid().ToString();

            // Dosyayı kaydet
            var filePath = Path.Combine(sharedFolderPath, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageStream.CopyToAsync(fileStream);
            }

            return Path.Combine("/SharedFiles", uniqueFileName).Replace("\\", "/");
        }
    }
}
