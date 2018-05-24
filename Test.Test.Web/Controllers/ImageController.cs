using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Models;
using Test.Test.Authorization.Users;
using Test.Test.Friendships;
using Test.Test.Images;
using Test.Test.Images.Dto;
using Test.Test.IO;
using Test.Test.Storage;
using Image = System.Drawing.Image;

namespace Test.Test.Web.Controllers
{
    public class ImageController : TestControllerBase 
    {
        private readonly UserManager _userManager;
        private readonly IBinaryObjectManager _binaryObjectManager;
        private readonly IAppFolders _appFolders;
        private readonly IFriendshipManager _friendshipManager;
        private readonly IImageAppService _imageAppService;

        public ImageController(
            UserManager userManager,
            IBinaryObjectManager binaryObjectManager,
            IImageAppService imageAppService,
            IAppFolders appFolders,
            IFriendshipManager friendshipManager)
        {
            _userManager = userManager;
            _binaryObjectManager = binaryObjectManager;
            _appFolders = appFolders;
            _friendshipManager = friendshipManager;
            _imageAppService = imageAppService;
        }
        // GET: Image
        public JsonResult UploadImage()
        {
            try
            {
                //Check input
                if (Request.Files.Count <= 0 || Request.Files[0] == null)
                {
                    throw new UserFriendlyException(L("Image_Change_Info_Change_Error"));
                }

                var file = Request.Files[0];

                if (file.ContentLength > 1048576) //1MB.
                {
                    throw new UserFriendlyException(L("Image_Change_Info_Warn_SizeLimit"));
                }

                //Check file type & format
                var fileImage = Image.FromStream(file.InputStream);
                var acceptedFormats = new List<ImageFormat>
                {
                    ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Gif
                };

                if (!acceptedFormats.Contains(fileImage.RawFormat))
                {
                    throw new ApplicationException("Uploaded file is not an accepted image file !");
                }

                //Delete old temp profile pictures
                AppFileHelper.DeleteFilesInFolderIfExists(_appFolders.TempFileDownloadFolder, "imagesUpload_" + AbpSession.GetUserId());

                //Save new picture
                var fileInfo = new FileInfo(file.FileName);
                var tempFileName = "imagesUpload_" + AbpSession.GetUserId() + fileInfo.Extension;
                var tempFilePath = Path.Combine(_appFolders.TempFileDownloadFolder, tempFileName);

                file.SaveAs(tempFilePath);
                using ( var bmpImage = new Bitmap(tempFilePath))
                {
                    return Json(new AjaxResponse(new { fileName = tempFileName, width = bmpImage.Width, height = bmpImage.Height , fileFormat = fileInfo.Extension,}));
                }
            }
            catch (UserFriendlyException ex)
            {
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
    }
}