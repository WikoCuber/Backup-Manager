namespace BM_Core.Helpers
{
    public static class DriveHelper
    {
        //Returns amount of free space in bytes
        public static long GetFreeSpace(char diskLetter)
        {
            DriveInfo drive = new(diskLetter.ToString());
            return drive.AvailableFreeSpace;
        }
    }
}
