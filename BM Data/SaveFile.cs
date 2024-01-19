using System.Text;
using System.Text.Json;

namespace BM_Data
{
    public static class SaveFile
    {
        private static readonly string FILE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Backup Manager/save.json";

        public static Data Data { get; set; }

        static SaveFile()
        {
            if (!File.Exists(FILE_PATH))
            {
                Directory.CreateDirectory(FILE_PATH.Replace("/save.json", ""));

                Data = new();

                Save(); //Write in file
            }
            else
                Data = Load();
        }

        //Saves data to file
        public static void Save()
        {
            string json = JsonSerializer.Serialize(Data);
            File.WriteAllBytes(FILE_PATH, Encoding.UTF8.GetBytes(json));
        }

        //Load data from file
        private static Data Load()
        {
            Data? data = JsonSerializer.Deserialize<Data>(File.ReadAllBytes(FILE_PATH));

            //Empty file
            data ??= new();

            return data;
        }
    }
}
