using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace ResizeImage
{
    public static class InputArchiveImages
    {
        /// <summary>
        /// Чтение всех изображений в архиве
        /// </summary>
        private static List<string> Input()
        {
            string path = "C:/Users/marve/source/repos/ResizeImage/ResizeImage/input.txt";

            StreamReader file = new StreamReader(path); // Загружаем файл
            string line = "";
            List<string> images = new List<string>();

            while ((line = file.ReadLine()) != null)
            {
                images.Add(line);
            }
            file.Close();

            return images;
        }

        /// <summary>
        /// Преобразует все изображения в список битмапов
        /// </summary>
        /// <param name="imagesName"></param>
        /// <returns></returns>
        private static List<Bitmap> ImagesToResize(List<string> imagesName)
        {
            List<Bitmap> images = new List<Bitmap>();
            string path = "C:/Users/marve/source/repos/ResizeImage/ResizeImage/PODD_JPG/";
            for (int i = 0; i < imagesName.Count; i++)
            {
                string InputFileName = path + imagesName[i];
                Bitmap res = new Bitmap(InputFileName);
                images.Add(res);
            }

            return images;
        }

        public static List<Bitmap> Resize ()
        {
            List<string> imageNames = Input();
            List<Bitmap> images = ImagesToResize(imageNames);

            for(int i = 0; i < images.Count; i++)
            {
                int width = images[i].Width / 2;
                int hight = images[i].Height / 2;

                Bitmap finishImage = new Bitmap(images[i], width, hight);

                images[i] = finishImage;
            }

            SaveImage(images);

            return images;
        }

        private static void SaveImage(List<Bitmap> images)
        {
            string path = "C:/Users/marve/source/repos/ResizeImage/ResizeImage/assets/image";
            for(int count = 0; count < images.Count; count++)
            {
                string finishPath = path + Convert.ToString(count) + ".jpg";
                images[count].Save(finishPath);
            }
        }
    }
}
