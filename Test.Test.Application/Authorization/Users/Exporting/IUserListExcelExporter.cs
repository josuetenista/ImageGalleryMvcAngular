using System.Collections.Generic;
using Test.Test.Authorization.Users.Dto;
using Test.Test.Dto;

namespace Test.Test.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}