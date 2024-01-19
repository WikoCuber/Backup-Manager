using BM_Core.Helpers;
using BM_Data;

namespace BM_Core
{
    public class CopyWorker
    {
        public int Files { get; set; }
        public long Size { get; set; }
        public string CurrentFile { get; set; } = "";
        public bool IsDeleting { get; set; } //Is worker now deleting additional files

        private readonly CopyTool copyTool;

        public CopyWorker()
        {
            copyTool = new CopyTool();
            copyTool.StatusChanged += (s, c) =>
            {
                Size += s;
                CurrentFile = c;
                Files++;
            };
        }

        public Task Start(List<Element> elements, string directoryPath, CancellationToken token)
        {
            return Task.Run(() =>
            {
                foreach (var element in elements)
                {
                    if (token.IsCancellationRequested)
                        return;

                    string path = element.Path;

                    //If it is file
                    if (FileHelper.IsFile(path) == 1)
                    {
                        if (element.ParentDirName != null)
                        {
                            string directoryName = element.ParentDirName;
                            Directory.CreateDirectory(directoryPath + '\\' + directoryName);
                            copyTool.CopyFile(path, directoryPath + '\\' + directoryName, token);
                        }
                        else
                            copyTool.CopyFile(path, directoryPath, token);
                    }
                    else if (FileHelper.IsFile(path) == 0) //If it is directory
                    {
                        //Gets name of directory from path to do directory with same name in copy directory
                        string directoryName = FileHelper.GetNameFromPath(path);

                        if (element.ParentDirName != null)
                            directoryName = element.ParentDirName + '\\' + directoryName;

                        Directory.CreateDirectory(directoryPath + '\\' + directoryName);
                        copyTool.CopyDirectory(path, directoryPath + '\\' + directoryName, token);
                    }
                }

                if (SaveFile.Data.IsDeleteAdditionalElements && !token.IsCancellationRequested)
                {
                    IsDeleting = true; //Set status
                    DeleteAddtionalElements.Delete(elements, directoryPath);
                }

            }, token);
        }
    }
}
