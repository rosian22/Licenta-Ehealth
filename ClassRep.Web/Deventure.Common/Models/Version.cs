using System;
using Deventure.Common.Interfaces;

namespace Deventure.Common.Models
{
    public class Version : IVersion
    {
        public int AppVersion { get; set; }
        public string WebApiUrl { get; set; }
        public string WebUrl { get; set; }
        public int DeviceType { get; set; }
        public int UserType { get; set; }
        public bool EnableLogging { get; set; }
    }
}
