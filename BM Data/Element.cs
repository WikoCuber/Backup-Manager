namespace BM_Data
{
    public class Element(string path, string? parentDirName = null)
    {
        public string Path { get; set; } = path;
        public bool IsWhiteList { get; set; } = false; //Otherwise blacklist
        public List<string> Subelements { get; set; } = [];
        public string? ParentDirName { get; set; } = parentDirName;
    }
}
