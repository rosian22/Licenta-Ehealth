using System.Collections.Generic;
using Deventure.Common.Enums;

namespace Deventure.Common.Extensions
{
    public static class NotificationTypeExtensions
    {
        private static NotificationTypeMessageManager MessageManager => NotificationTypeMessageManager.Instance;

        public static string GetMessage(this NotificationType notificationType, params object[] values)
        {
            if (!MessageManager.NotificationMessagesMap.ContainsKey(notificationType))
            {
                return string.Empty;
            }

            var description = MessageManager.NotificationMessagesMap[notificationType];
            return string.Format(description, values);
        }
    }
    internal class NotificationTypeMessageManager
    {
        private static NotificationTypeMessageManager mInstance;

        private NotificationTypeMessageManager()
        {
            InitializeMessagesMap();
        }

        public IDictionary<NotificationType, string> NotificationMessagesMap { get; private set; }

        public static NotificationTypeMessageManager Instance => mInstance ?? (mInstance = new NotificationTypeMessageManager());

        private void InitializeMessagesMap()
        {
            if (NotificationMessagesMap != null)
            {
                return;
            }

            NotificationMessagesMap = new Dictionary<NotificationType, string>
            {
                //eg
                //{
                //    NotificationType.EmployeeApproved, NotificationHelper.COMMON_ACCOUNT_APPROVED
                //},
            };
        }
    }
}
