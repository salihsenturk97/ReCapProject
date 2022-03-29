using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot"; // Environment.CurrentDirectory; //Uygunlamamnın çalıştıgı aktif klasör yoludur.
        private static string _folderName = "\\images\\"; // Klasör ismini images yaptık.

        public static IResult Upload(IFormFile file) //IFormFile HttpRequest ile gönderilen bir dosyayı temsil eder.
        {
            var fileExists = CheckFileExists(file); // Dosya varsa, bize success şeklinde içi boş mesaj verecek, eğer dolu değilse asıl mesajı burda alacağız hatayı yani fileExists içi dolu olacak
            if (fileExists.Message != null) // içi boş değilse hata vermiştir yukarıdaki söylediğim gibi.
            {
                return new ErrorResult(fileExists.Message); // iç.indeki olan hata mesajını göndeririz.
            }

            var type = Path.GetExtension(file.FileName); // Belirtilen yol dizesinin uzantısını döndürür mesela meslea.jpeg
            var typeValid = CheckFileTypeValid(type); // uzantısını kontrol ediyoruz.
            var randomName = Guid.NewGuid().ToString(); // Guid.NewGuid() metodu ile yeni bir guid oluşturulabilir ve bununla ilgili işlemler yapılabilir. yani bir random name kullandık.

            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message); // kontrol ederken içi dolu mesaj varsa bizde hatayı gösteriyoruz.
            }

            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file); 
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/")); 



        }

        public static IResult Update(IFormFile file, string imagePath)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }

            //var type = Path.GetExtension(file.FileName);
            //var typeValid = CheckFileTypeValid(type);
            //var randomName = Guid.NewGuid().ToString();

            //if (typeValid.Message != null)
            //{
            //    return new ErrorResult(typeValid.Message);
            //}

            DeleteOldImageFile((_currentDirectory + imagePath).Replace("/", "\\"));
           

            return new SuccessResult(Upload(file).Message);
            //CheckDirectoryExists(_currentDirectory + _folderName);



            //CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            //return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessResult();
        }




        private static IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0) //file.Length=>Dosya uzunluğunu bayt olarak alır. dosya gönderilmiş mi gönderilmemişmi ona bakarız.
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doesn't exists."); // Dosya mevcut değil dedik. 
        }


        private static IResult CheckFileTypeValid(string type) // Uzantısını kontrol ediyoruz.
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("Wrong file type.");
            }
            return new SuccessResult();
        }

        private static void CheckDirectoryExists(string directory) 
        {
            if (!Directory.Exists(directory)) //klasör yolunun varolup olmadığı ile ilgili boolean bir değer döndürüp ona göre işlem yapmamız için yardımcı olan bir metot'dur.
            {
                Directory.CreateDirectory(directory); // eğer yoksa dosyaların kayıt edilecek dizini oluşturur
            }
        }
        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs); //Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen IFromFile türündeki file dosyasınınnereye kopyalacağını söyledik.
                fs.Flush(); //arabellekten siler.
            }
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\"))) // dosyayı bulur
            {
                File.Delete(directory.Replace("/", "\\")); // varsa dosyayı siler
            }

        }
    }
}