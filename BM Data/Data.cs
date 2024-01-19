namespace BM_Data
{
    public class Data
    {
        public bool IsCheckFileSize { get; set; }
        public bool IsDeleteAdditionalElements { get; set; }
        public string? CopyDirectory { get; set; }
        public List<Element> Elements { get; set; } = []; //Directorys or files
    }
}
