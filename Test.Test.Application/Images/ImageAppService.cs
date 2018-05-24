using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.IO;
using Abp.Runtime.Session;
using Abp.UI;
using Test.Test.Images.Dto;
using Test.Test.Storage;

namespace Test.Test.Images
{
    public class ImageAppService : TestAppServiceBase, IImageAppService
    {
        private readonly IRepository<Image> _imageRepository;
        private readonly IBinaryObjectManager _binaryObjectManager;
        private readonly IAppFolders _appFolders;


        public ImageAppService(IRepository<Image> imageRepository, IAppFolders appFolders,IBinaryObjectManager binaryObjectManager)
        {

            _appFolders = appFolders;
            _binaryObjectManager = binaryObjectManager;
            _imageRepository = imageRepository;
        }
        public async Task<bool> SaveImage(ImageInputDto input)
        {
            try
            {
                var tempProfilePicturePath = Path.Combine(_appFolders.TempFileDownloadFolder, input.FileName);

                byte[] byteArray;

                using (var fsTempProfilePicture = new FileStream(tempProfilePicturePath, FileMode.Open))
                {
                    using (var bmpImage = new Bitmap(fsTempProfilePicture))
                    {
                        var width = input.Width == 0 ? bmpImage.Width : input.Width;
                        var height = input.Height == 0 ? bmpImage.Height : input.Height;
                        var bmCrop = bmpImage.Clone(new Rectangle(input.X, input.Y, width, height), bmpImage.PixelFormat);

                        using (var stream = new MemoryStream())
                        {
                            bmCrop.Save(stream, bmpImage.RawFormat);
                            stream.Close();
                            byteArray = stream.ToArray();
                        }
                    }
                }

                if (byteArray.LongLength > 10002400) //100 MB
                {
                    throw new UserFriendlyException(L("ResizedProfilePicture_Warn_SizeLimit"));
                }

                var user = await UserManager.GetUserByIdAsync(AbpSession.GetUserId());

                var storedFile = new BinaryObject(AbpSession.TenantId, byteArray);
                await _binaryObjectManager.SaveAsync(storedFile);


                FileHelper.DeleteIfExists(tempProfilePicturePath);



                _imageRepository.InsertAndGetId(new Image()
                {
                    FileLocation = tempProfilePicturePath,
                    FileFormat = input.FileExtension,
                    FileName = input.FileName,
                    ImageByte = byteArray,
                    ImageString = Convert.ToBase64String(byteArray),
                    UserId = user.Id,

                });
                return true;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
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
