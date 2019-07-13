using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deventure.Common.Constants
{
    public class AppConstants
    {
        public const string ADMIN_ROLE_ID = "56CA5D4C-E55F-42CF-A4F5-D12A75D6D1F0";

        public const string GLOBAL_ADMIN_ID = "94586792-6BCB-4E9B-8BE8-49A5555ADA91";
        public const string GLOBAL_ADMIN_EMAIL = "deventureadmin@deventure.co";
        public const string GLOBAL_ADMIN_PASSWORD = "deventure1@";

        public const string DOCUMENT_BLOB_CONTAINER = "documents";

        public const string TRANSLATIONS_BLOB_CONTAINER = "translations";

        public static readonly Guid GlobalAdminManagerId = new Guid("F77EB68F-3C12-4C2A-8496-3E9C7F91398D");

        public const string STORAGE_BASE_URL = "https://bestprofilelive.blob.core.windows.net/";

        public const string STORAGE_DEFAULT_PROFILE_PICTURE = "https://bestprofilelive.blob.core.windows.net/default/DefaultProfilePic.png";

        public const string DATE_FORMAT = "dd.MM.yyyy";

        public const string DATE_TIME_FORMAT = "dd.MM.yyyy HH:mm";
    }
}
