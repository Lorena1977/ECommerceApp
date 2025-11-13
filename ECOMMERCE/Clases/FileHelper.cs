using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Clases
{
    public class FileHelper
    {
        public static bool UploadPhoto(HttpPostedFileBase file, string folder, string name)
        {
            if (file == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(name))
            {
                return false;
            }

            try 
            { 
            string path = string.Empty; //Nombre de la ruta completa.
            //string pic = string.Empty; //Nombre del archivo

            if(file != null)
            {
                //pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name); //Lo graba en la ruta del servidor con el nombre name.
                file.SaveAs(path); //Sube el fihero al servidor
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }
                return true;
            }
            catch
            {
                return false;
            }



        }
            
    }
}