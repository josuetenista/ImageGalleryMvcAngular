using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Test.Images.Dto
{
    public class ImageInputDto 
    {
        //public int? ImageId { get; set; }
        //public string FileName { get; set; }
        //public string FileFormat { get; set; }
        //public string FileLocation { get; set; }
        //public byte[] ImageBytes { get; set; }
        //public long UserId { get; set; }


        [Required]
        [MaxLength(256)]
        public string FileName { get; set; }
        public string FileExtension { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
        public int ImageId { get; set; }
    }
}
