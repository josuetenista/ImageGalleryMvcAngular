using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Test.Test.Authorization.Users;

namespace Test.Test.Images
{
    [Table("dbImages")]
    public class Image : FullAuditedEntity
    {
        public const int MaxImageNameLength = 32;
        public const int MaxImageFileLocationLength = 256;
        public const int MaxImageFormatLength = 6;

        [Required]
        [MaxLength(MaxImageNameLength)]
        public virtual string FileName { get; set; }

        [Required]
        [MaxLength(MaxImageFormatLength)]
        public virtual string FileFormat { get; set; }
        public virtual byte[] ImageByte { get; set; }
        public virtual string ImageString { get; set; }
        //Not required since it can be saved only in DB
        [MaxLength(MaxImageFileLocationLength)]
        public virtual string FileLocation { get; set; }

        //Every image needs 1 user
        [ForeignKey("User")]
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }

    }
}
