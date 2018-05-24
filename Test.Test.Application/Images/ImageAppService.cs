using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Test.Test.Images.Dto;

namespace Test.Test.Images
{
    public class ImageAppService: TestAppServiceBase, IImageAppService
    {
        private readonly IRepository<Image> _imageRepository;

        public ImageAppService(IRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task<bool> SaveImage(ImageInputDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResultDto<ImageOutputDto>> ListAllUserImages()
        {
            var userId = AbpSession.UserId;
            var userImages = _imageRepository.GetAll().Where(i => i.UserId == userId);
            return new ListResultDto<ImageOutputDto>(userImages.MapTo<List<ImageOutputDto>>());
        }

        public async Task<bool> DeleteImage(ImageInputDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditImage(ImageInputDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ImageOutputDto> GetImage(int id)
        {
            return _imageRepository.Get(id).MapTo<ImageOutputDto>();

        }
    }
}
