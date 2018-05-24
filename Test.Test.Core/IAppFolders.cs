namespace Test.Test
{
    public interface IAppFolders
    {
        string TempFileDownloadFolder { get; }

        string SampleProfileImagesFolder { get; }

        string WebLogsFolder { get; set; }
    }
}