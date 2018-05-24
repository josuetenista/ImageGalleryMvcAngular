using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Test.Test.Images.Dto;

namespace Test.Test.Images
{
    public interface IImageAppService : IApplicationService
    {
        Task<bool> SaveImage(ImageInputDto input);
        Task<ListResultDto<ImageOutputDto>> ListAllUserImages();
        Task<bool> DeleteImage(ImageOutputDto input);
        Task<bool> EditImage(ImageInputDto input);
        Task<ImageOutputDto> GetImage(int id);

    }
}
