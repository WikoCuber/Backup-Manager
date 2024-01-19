namespace BM_Core
{
    public class DirectoryInformation(CancellationTokenSource source)
    {
        public int FilesCount { get; set; }
        public long FilesSize { get; set; } //Negative if error occurred

        //To cancel multithreading recreation when error occurred
        private readonly CancellationToken token = source.Token;

        //To do multithreading search
        private readonly List<Task> workerTasks = [];

        public void CheckDirectory(string path)
        {
            //Gets info about files, but its multithreading recreation
            GetInfo(path);

            //Waits to end of multithreading recreation
            while (workerTasks.Count != 0)
            {
                //Waits to end all tasks that started before call this
                Task[] taskArray;

                lock (workerTasks)
                {
                    taskArray = [.. workerTasks];
                }

                try
                {
                    Task.WaitAll(taskArray);
                }
                catch (Exception ex)
                {
                    if(ex.InnerException is not TaskCanceledException)
                        throw;
                }

                //Removes all completed tasks
                lock (workerTasks)
                {
                    List<Task> copy = new(workerTasks);
                    foreach (var task in copy)
                    {
                        if (task.IsCompleted == true)
                            workerTasks.Remove(task);
                    }
                }

                //Makes sure next task(s) is called
                Thread.Sleep(100);
            }
        }

        private void GetInfo(string path)
        {
            //Return is cancel was clicked
            if (token.IsCancellationRequested)
                return;

            DirectoryInfo di = new(path);

            try
            {
                FileInfo[] fis = di.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    FilesCount++;
                    FilesSize += fi.Length;
                }

                DirectoryInfo[] dis = di.GetDirectories();
                foreach (DirectoryInfo directory in dis)
                {
                    lock (workerTasks)
                    {
                        //New task for another directory
                        workerTasks.Add(Task.Run(() => GetInfo(directory.FullName), token));
                    }
                }
            }
            catch (Exception ex)
            {
                source.Cancel();

                //Set size to the lowest possible value for information about error
                FilesSize = long.MinValue;

                //Protected file
                if (ex is not UnauthorizedAccessException)
                    throw;
            }
        }
    }
}
