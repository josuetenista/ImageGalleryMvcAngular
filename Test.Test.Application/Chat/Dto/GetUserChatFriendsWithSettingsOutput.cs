using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Castle.Components.DictionaryAdapter;
using Test.Test.Friendships.Dto;

namespace Test.Test.Chat.Dto
{
    public class GetUserChatFriendsWithSettingsOutput
    {
        public DateTime ServerTime { get; set; }

        public List<FriendDto> Friends { get; set; }

        public GetUserChatFriendsWithSettingsOutput()
        {
            Friends = new EditableList<FriendDto>();
        }
    }
}