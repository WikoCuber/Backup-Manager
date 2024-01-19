using BM_Core.Helpers;
using BM_Data;

namespace BM_Core
{
    public static class DeleteAddtionalElements
    {
        public static void Delete(List<Element> elements, string directoryPath)
        {
            string copyDirecotryName = FileHelper.GetNameFromPath(directoryPath);

            //Elements from copy directory
            List<string> currentFilesPathes = [];
            List<string> currentDirectoriesPathes = [];

            //Remove full path to can compare two lists
            foreach (var file in DirectoryHelper.GetFiles(directoryPath))
            {
                string relativePath = file.ParentDirName + '\\' + FileHelper.GetNameFromPath(file.Path);
                relativePath = relativePath.Remove(0, copyDirecotryName.Length + 1); //Remove main directory
                currentFilesPathes.Add(relativePath);
            }
            foreach (var directory in DirectoryHelper.GetDirectories(directoryPath))
            {
                string relativePath = directory.ParentDirName + '\\' + FileHelper.GetNameFromPath(directory.Path);
                relativePath = relativePath.Remove(0, copyDirecotryName.Length + 1); //Remove main directory
                currentDirectoriesPathes.Add(relativePath);
            }

            //All paths to elements in list and remove full path to can compare two lists
            List<string> filesPathes = [];
            List<string> directoriesPathes = [];
            foreach (Element element in elements)
            {
                //If element is directory
                if (FileHelper.IsFile(element.Path) == 0)
                {
                    foreach (Element file in DirectoryHelper.GetFiles(element.Path, element.ParentDirName == null ? "" : element.ParentDirName + '\\'))
                        filesPathes.Add(file.ParentDirName + '\\' + FileHelper.GetNameFromPath(file.Path));

                    foreach (Element directory in DirectoryHelper.GetDirectories(element.Path, element.ParentDirName == null ? "" : element.ParentDirName + '\\'))
                        directoriesPathes.Add(directory.ParentDirName + '\\' + FileHelper.GetNameFromPath(directory.Path));

                    //Add itself
                    directoriesPathes.Add((element.ParentDirName == null ? "" : element.ParentDirName + '\\') + FileHelper.GetNameFromPath(element.Path));
                }
                else
                    filesPathes.Add((element.ParentDirName == null ? "" : element.ParentDirName + '\\') + FileHelper.GetNameFromPath(element.Path)); //Add itself

                //Add main directory
                if (!directoriesPathes.Contains(element.ParentDirName!))
                    directoriesPathes.Add(element.ParentDirName!);
            }

            //Remaining pathes
            List<string> deleteFilesPathes = currentFilesPathes.Where(x => !filesPathes.Any(y => x == y)).ToList();
            foreach (string path in deleteFilesPathes)
            {
                try
                {
                    File.Delete(directoryPath + '\\' + path);
                }
                catch (Exception ex)
                {
                    //If file not exist or user don't have access skip it
                    if (!(ex is UnauthorizedAccessException || ex is FileNotFoundException))
                        throw;
                }
            }

            List<string> deleteDirectoriesPathes = currentDirectoriesPathes.Where(x => !directoriesPathes.Any(y => x == y)).ToList();
            foreach (string path in deleteDirectoriesPathes)
            {
                try
                {
                    DirectoryInfo di = new(directoryPath + '\\' + path);
                    di.Delete(true);
                }
                catch (Exception ex)
                {
                    //If directory not exist or user don't have access skip it
                    if (!(ex is UnauthorizedAccessException || ex is DirectoryNotFoundException))
                        throw;
                }
            }
        }
    }
}
