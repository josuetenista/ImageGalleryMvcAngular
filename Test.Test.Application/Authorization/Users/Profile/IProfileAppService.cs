﻿using System.Threading.Tasks;
using Abp.Application.Services;
using Test.Test.Authorization.Users.Profile.Dto;

namespace Test.Test.Authorization.Users.Profile
{
    public interface IProfileAppService : IApplicationService
    {
        Task<CurrentUserProfileEditDto> GetCurrentUserProfileForEdit();

        Task UpdateCurrentUserProfile(CurrentUserProfileEditDto input);
        
        Task ChangePassword(ChangePasswordInput input);

        Task UpdateProfilePicture(UpdateProfilePictureInput input);

        Task<GetPasswordComplexitySettingOutput> GetPasswordComplexitySetting();
    }
}
