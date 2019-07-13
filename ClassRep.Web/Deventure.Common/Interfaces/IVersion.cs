namespace Deventure.Common.Interfaces
{
    public interface IVersion
    {
         int AppVersion { get; set; }
         string WebApiUrl { get; set; }
         string WebUrl { get; set; }
         int DeviceType { get; set; }
         int UserType { get; set; }
         bool EnableLogging { get; set; }
    }
}
