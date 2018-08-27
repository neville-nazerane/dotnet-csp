using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotnetCsp.Core
{
    public class Package
    {

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public IEnumerable<ClientPackage> ClientPackages { get; set; }

        public IEnumerable<ServerPackage> ServerPackages { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        [Required, ForeignKey(nameof(CreatedBy))]
        public int? CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public int? UpdatedById { get; set; }
        public User UpdatedBy { get; set; }


    }
}
