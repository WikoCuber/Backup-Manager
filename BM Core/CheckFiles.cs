using BM_Core.Helpers;
using BM_Data;

namespace BM_Core
{
    public class CheckFiles
    {
        public event Action<string>? InfoEvent;

        public string ErrorMessage { get; set; }
        public bool IsDone { get; set; }
        public long TotalSize { get; set; }
        public int TotalElements { get; set; }

        private readonly List<DirectoryInformation> taskExecutors;
        private int filesCount;
        private long filesSize;

        public CheckFiles()
        {
            ErrorMessage = "";
            taskExecutors = [];
        }

        public string GetStatus()
        {
            TotalSize = filesSize;
            TotalElements = filesCount;

            //Gets sizes and count of elements from workers
            if (taskExecutors.Count != 0)
            {
                lock (taskExecutors)
                {
                    foreach (var taskExecutor in taskExecutors)
                    {
                        TotalElements += taskExecutor.FilesCount;
                        TotalSize += taskExecutor.FilesSize;
                    }
                }
            }

            //Don't division by 0
            if(TotalElements == 0 || TotalSize == 0)
            {
                TotalElements = 1;
                TotalSize = 1;
            }

            //Not displays when directory has protected file
            if (TotalSize < 0)
                return "";
            else
                return TotalElements.ToString() + " (" + TotalSize / 1000000000 + "GB)";
        }

        public List<Element> Check(List<Element> elements)
        {
            List<Element> existingElements = GetExistingElements(elements);

            //Split elements which have subelements to single paths list
            List<Element> chosenElements = new(existingElements);
            foreach (Element mainElement in existingElements)
            {
                if (mainElement.Subelements.Count == 0)
                    continue;

                //Apply white or black list rules
                List<string> pathes = ApplyWhiteOrBlackList(mainElement);

                //Remove main directory
                chosenElements.Remove(mainElement);

                //Add main directory to create it in copy
                foreach (string path in pathes)
                    chosenElements.Add(new Element(path, FileHelper.GetNameFromPath(mainElement.Path)));
            }

            //Get info about elements
            GetInfo(chosenElements);

            IsDone = true;

            GetStatus(); //Make sure that total size and elements count are current

            return chosenElements;
        }

        private List<Element> GetExistingElements(List<Element> elements)
        {
            //Elements which exist
            List<Element> existingElements = new(elements);
            string elementsToSkip = "";

            //Checks are elements exist
            foreach (var element in SaveFile.Data.Elements)
            {
                //If isn't exists
                if (FileHelper.IsFile(element.Path) == -1)
                {
                    existingElements.Remove(element);
                    elementsToSkip += ", " + FileHelper.GetNameFromPath(element.Path);
                }
            }

            //If minimum 1 element was skipped then warn user 
            if (elementsToSkip.Length > 0)
                InfoEvent?.Invoke("Elementy: " + elementsToSkip.Remove(0, 2) + " nie istnieją. Zostaną one pominięte.");

            return existingElements;
        }

        private static List<string> ApplyWhiteOrBlackList(Element mainElement)
        {
            List<string> pathes = [];

            if (mainElement.IsWhiteList)
                pathes.AddRange(mainElement.Subelements);
            else
            {
                pathes.AddRange(Directory.GetDirectories(mainElement.Path));
                pathes.AddRange(Directory.GetFiles(mainElement.Path));

                foreach (string subelement in mainElement.Subelements)
                    pathes.Remove(subelement);
            }

            return pathes;
        }

        private void GetInfo(List<Element> chosenElements)
        {
            List<Task> workerTasks = [];

            foreach (Element element in chosenElements)
            {
                if (FileHelper.IsFile(element.Path) == 1)
                {
                    FileInfo fi = new(element.Path);
                    filesCount++;
                    filesSize += fi.Length;
                }
                else if (FileHelper.IsFile(element.Path) == 0)
                {
                    //Same cancellation token in all tasks
                    CancellationTokenSource source = new();
                    Task task = new(() =>
                    {
                        DirectoryInformation di = new(source);
                        lock (taskExecutors)
                        {
                            taskExecutors.Add(di);
                        }
                        di.CheckDirectory(element.Path);

                        //Protected file
                        if (di.FilesSize < 0)
                            ErrorMessage = "W ścieżce: " + element.Path + " są pliki do których dostęp jest zabroniony.";
                    });
                    task.Start();

                    //Add task to wait list
                    workerTasks.Add(task);
                }
            }

            Task.WaitAll([.. workerTasks]);
        }
    }
}
