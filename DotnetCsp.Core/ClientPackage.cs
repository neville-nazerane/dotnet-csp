using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotnetCsp.Core
{
    public class ClientPackage
    {

        public int Id { get; set; }

        [Required, MaxLength(300)]
        public string Source { get; set; }

        [MaxLength(800)]
        public string OnlyFiles { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        [Required, ForeignKey(nameof(CreatedBy))]
        public int? CreatedById { get; set; }
        public UserDisplay CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public int? UpdatedById { get; set; }
        public UserDisplay UpdatedBy { get; set; }



    }
}
