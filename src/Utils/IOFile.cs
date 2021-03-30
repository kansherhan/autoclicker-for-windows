using System.IO;

namespace AutoClicker.Utils
{
    public static class IOFile
    {
        public const string DateTimeFormat = "yyyy_MM_d_hh_mm_ss";

        public const string SaveFolder = "Data";
        public const string QueueSaveFolder = SaveFolder + @"\Quete";
        public const string ReusableSaveFolder = SaveFolder + @"\Reusable";

        public static string GetJsonFilePath(string directory, string filename)
        {
            return Path.Combine(directory, filename + ".json");
        }

        public static string[] GetFiles(string directory, bool withoutPathAndExtension = false)
        {
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);

                if (withoutPathAndExtension)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        files[i] = Path.GetFileNameWithoutExtension(files[i]);
                    }
                }

                return files;
            }
            else return new string[0];
        }

        public static void CreateSaveFolders()
        {
            void CreateDirectory(string path)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }

            CreateDirectory(SaveFolder);
            CreateDirectory(QueueSaveFolder);
            CreateDirectory(ReusableSaveFolder);
        }
    }
}
