using BM_Data;

namespace BM_Core.Helpers
{
    public static class DirectoryHelper
    {
        //Returns paths to all files in directory and subdirectories
        public static List<Element> GetFiles(string path, string offset = "")
        {
            List<Element> result = [];

            string parentDirectory = offset + FileHelper.GetNameFromPath(path);

            foreach (var filePath in Directory.GetFiles(path))
                result.Add(new Element(filePath, parentDirectory));

            //Do for other directories
            foreach (string directory in Directory.GetDirectories(path))
                result.AddRange(GetFiles(directory, parentDirectory + '\\'));

            return result;
        }

        //Returns paths to all directories and subdirectories
        public static List<Element> GetDirectories(string path, string offset = "")
        {
            List<Element> result = [];

            string parentDirectory = offset + FileHelper.GetNameFromPath(path);

            //Add directory and do for other directories
            foreach (string directory in Directory.GetDirectories(path))
            {
                result.Add(new Element(directory, parentDirectory));
                result.AddRange(GetDirectories(directory, parentDirectory + '\\'));
            }

            return result;
        }
    }
}
