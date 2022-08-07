using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager : IFileHelper
    {
        public string Add(string root, IFormFile file)
        {

            // Directory sınıfı dosya oluşturma, silme, taşıma ve kopyalama gibi işlemleri yapmamızı sağlar. Static bir class tır.

            if (!Directory.Exists(root))  // Exists metodu ile dosyanın var olup olmadığı ile ilgili boolean bir değer döndürebiliriz
            {
                Directory.CreateDirectory(root);  // bu if bloğunda eklenmek istenen dizin'in var olup olmadığını kontrol ediyoruz. 
                // eğer dizin yoksa CreateDirectory ile verilen root adında yeni bir dizin oluşturuyoruz
            }

            // Path : Dosya veya dizin yolu bilgileri üzerinde işlemler gerçekleştirir.
            string imageExtension = Path.GetExtension(file.FileName); // GetExtension ile bir dosyanın veya klasörün uzantısını alabiliriz
            string imageName = Guid.NewGuid().ToString() + imageExtension; //Gudi benzersiz değerler oluşturmak için kullanılır
                                                                            //Eğer birden fazla kullanıcı aynı isimde dosya oluşturursa Guid benzersiz değerler üretir 
                                                                            // Böylelikle verilerin birbirini ezmesini önlemiş oluruz.

            using (FileStream fileStream = File.Create(root + imageName))  // FileStream belirtilen dosya üzerinde yazma,ekleme gibi operasyonları yapar.
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return imageName;
            }
            
            return null;
            
        }

        public void Delete(string fielPath)
        {
            if (File.Exists(fielPath))   // File = tek bir dosyanın silinmesi, taşınması gibi yöntemleri sağlar. 
            {
                File.Delete(fielPath);
            }
        }

        public string Update(string root, IFormFile file, string fielPath)
        {
            if (!File.Exists(fielPath))
            {
                return "Böyle bir resim yok";
            }
            File.Delete(fielPath);
            
            return Add(root, file);


        }
    }
}
