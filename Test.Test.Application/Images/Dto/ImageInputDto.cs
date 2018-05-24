using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Test.Images.Dto
{
    public class ImageInputDto 
    {
        public int? ImageId { get; set; }
        public byte[] ImageBytes { get; set; }
        public long UserId { get; set; }
    }
}
