using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Test.Test.Authorization.Users;

namespace Test.Test.Images.Dto
{
    public class ImageOutputDto : FullAuditedEntityDto
    {
        public string FileName { get; set; }
        public string FileFormat { get; set; }
        public byte[] ImageByte { get; set; }
        //Not required since it can be saved only in DB
        public string FileLocation { get; set; }
        public long UserId { get; set; }
    }
}
