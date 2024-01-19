namespace BM_Core.Helpers
{
    public static class FileHelper
    {
        //-1 - not exist, 0 - is directory, 1 - is file
        public static int IsFile(string path)
        {
            FileAttributes attr;

            try 
            { 
                attr = File.GetAttributes(path); 
            }
            catch (Exception ex)
            {
                //File / directory doesn`t exists
                if (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                    return -1;
                else
                    throw;
            }
            if (attr.HasFlag(FileAttributes.Directory))
                return 0;
            else
                return 1;
        }

        public static string GetNameFromPath(string path)
        {
            string name = "";
            for (int i = path.Length - 1; i >= 0; i--)
            {
                //Brake on slash or backshlash
                if (path[i] == '\\' || path[i] == '/')
                    break;

                name += path[i];
            }

            //Reverse directory name
            char[] charArray = name.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
