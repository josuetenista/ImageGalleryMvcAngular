using Abp.Notifications;
using Test.Test.Dto;

namespace Test.Test.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}