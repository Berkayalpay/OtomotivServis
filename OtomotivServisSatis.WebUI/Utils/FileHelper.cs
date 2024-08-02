namespace OtomotivServisSatis.WebUI.Utils
{
    //Resim Dosyaları static oldugu için wwwroot klasorune gidiyor.
    public class FileHelper
    {
        // static direkt sınıf adıyla cagırılabilmesini saglar instance olusturulmadan.
        // Dosya Yükleme Metodu.

        //formFile controllerdan gelicek olan Resim1 mesela , filePath ise default olarak dosyanın nereye yükleniceği.Başlangıc /Img/
        public static async Task<string> FileLoaderAsync(IFormFile formFile , string filePath = "/Img/")
        {
            var fileName = ""; //dosya adı başta boş , formFile alıcağı dosya
            if (formFile != null && formFile.Length>0)
            {
                fileName = formFile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/" + filePath + fileName;
                using var stream = new FileStream(directory, FileMode.Create); //stream oluşturuyoruz bu directoryde Dosya Akışı
                //pcden seçilen bir dosyayı sunucuya akış ile yolluyoruz.
                await formFile.CopyToAsync(stream); // ve dosyamızı yarattıgımız directory içerisine kopyalıyoruz.
            }
            return fileName;
            //yüklenen dosyanın adının string değer olarak donduruyoruz. yüklenicek konum da path ile alıyoruz.
        }
    }
}
