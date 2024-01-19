using BM_Core.Helpers;
using BM_Data;

namespace BM_Core
{
    public class CopyTool
    {
        public event Action<long, string>? StatusChanged; //Invoke when file is modified

        public void CopyFile(string from, string to, CancellationToken token)
        {
            //Return is cancel button was clicked
            if (token.IsCancellationRequested)
                return;

            to += '\\' + FileHelper.GetNameFromPath(from);

            //For progress bar
            StatusChanged?.Invoke(new FileInfo(from).Length, from);

            try
            {
                //If file exists check if size is different.
                if (!File.Exists(to))
                    File.Copy(from, to, true);
                else
                {
                    if (SaveFile.Data.IsCheckFileSize)
                    {
                        FileInfo fromFI = new(from);
                        FileInfo toFI = new(to);

                        if (fromFI.Length != toFI.Length)
                            File.Copy(from, to, true);
                    }
                    else
                        File.Copy(from, to, true);
                }

            }
            catch (Exception ex)
            {
                StreamWriter sw = new(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Backup Manager\Error.log", true);
                sw.WriteLine(DateTime.Now.ToString() + "          " + ex.Message);
                sw.Close();
            }
        }
        public void CopyDirectory(string from, string to, CancellationToken token)
        {
            //Return is cancel button was clicked
            if (token.IsCancellationRequested)
                return;

            DirectoryInfo source = new(from);
            DirectoryInfo target = new(to);

            foreach (FileInfo file in source.GetFiles())
                CopyFile(file.FullName, target.FullName, token);

            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyDirectory(dir.FullName, target.CreateSubdirectory(dir.Name).FullName, token);
        }
    }
}
